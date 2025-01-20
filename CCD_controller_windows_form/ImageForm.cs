using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMCD64CS;

using MessageBox = System.Windows.Forms.MessageBox;
using ReadMode = ATMCD64CS.AndorSDK.ReadMode;
using AcquisitionMode = ATMCD64CS.AndorSDK.AcquisitionMode;
using System.Security.Permissions;

namespace CCD_controller_windows_form
{
    public partial class ImageForm : Form
    {
        private ushort[] Frame_16bit;
        private ushort[] Frame_16bit_Background;
        private int XDim;
        private int YDim;
        private int pre_pos_X = 0;
        private int pre_pos_Y = 0;
        private int start_pos_X = 0;
        private int start_pos_Y = 0;
        private int ROI_XSize = 1600;
        private int ROI_YSize = 400;
        private bool mouse_clicked = false;
        private Bitmap bmp;
        private Bitmap tmp_bmp;
        private Graphics objGrp;
        private Pen objPen;

        public ushort[] CCD_Data
        {
            get
            {
                return Frame_16bit;
            }
            set
            {
                Frame_16bit = (ushort[])value.Clone();
                plotDataBackgroundSubtractCheck();
            }
        }

        public ImageForm(ushort[] ccd_Data,int XDimension, int YDimension)
        {
            InitializeComponent();
            objPen = new Pen(Color.Blue, 1);
            objPen.DashStyle = DashStyle.Dash;
            XDim = XDimension;
            YDim = YDimension;
            Frame_16bit = (ushort[])ccd_Data.Clone();
            Frame_16bit_Background = new ushort[XDim * YDim];
            plotDataBackgroundSubtractCheck();
            tmp_bmp = (Bitmap)bmp.Clone();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void changeImage(ushort[] ccd_Data, int XDimension, int YDimension)
        {
            XDim = XDimension;
            YDim = YDimension;
            Frame_16bit = (ushort[])ccd_Data.Clone();
            plotDataBackgroundSubtractCheck();
            tmp_bmp = (Bitmap)bmp.Clone();
        }

        private void plotDataBackgroundSubtractCheck()
        {
            int[] array = new int[Frame_16bit.Length];
            for (int i = 0; i < Frame_16bit.Length; i++)
            {

                //if (chkSubtractBackground.Checked)
                //{
                //  array[i] = Frame_16bit[i] - Frame_16bit_Background[i];   
                //}
                //else
                //{
                   array[i] = Frame_16bit[i];
                //}
            }
            byte[] pixelValues = Convert16BitGrayScaleToRgb48(array, XDim, YDim);
            bmp = CreateBitmapFromBytes(pixelValues, XDim, YDim);
            pctrBx_Image_Display.Image = bmp;
        }

        private byte[] Convert16BitGrayScaleToRgb48(int[] inBuffer, int width, int height)
        {
            int num = 6;
            byte[] array = new byte[width * height * num];
            int num2 = inBuffer.Min();
            int num3 = inBuffer.Max();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int num4 = i * width + j;
                    int num5 = i * width * num + j * num;
                    double a = ((num3 == num2) ? ((double)((inBuffer[num4] - num2) * 16384)) : ((double)((inBuffer[num4] - num2) * 16384 / (num3 - num2))));
                    ushort value = (ushort)Math.Round(a);
                    byte b = BitConverter.GetBytes(value)[1];
                    byte b2 = BitConverter.GetBytes(value)[0];
                    array[num5] = b2;
                    array[num5 + 1] = b;
                    array[num5 + 2] = b2;
                    array[num5 + 3] = b;
                    array[num5 + 4] = b2;
                    array[num5 + 5] = b;
                }
            }
            return array;
        }

        private Bitmap CreateBitmapFromBytes(byte[] pixelValues, int width, int height)
        {
            bmp = new Bitmap(width, height, PixelFormat.Format48bppRgb);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr scan = bitmapData.Scan0;
            Marshal.Copy(pixelValues, 0, scan, pixelValues.Length);
            bmp.UnlockBits(bitmapData);

            return bmp;
        }

        public int get_ROI_XSize()
        {
            return ROI_XSize;
        }

        public int get_ROI_YSize()
        {
            return ROI_YSize;
        }

        private void pctrBx_Image_Display_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouse_clicked = true;

                pre_pos_X = e.X;
                pre_pos_Y = e.Y;
                start_pos_X = e.X;
                start_pos_Y = e.Y;

                nmrcUpDwn_X_offset.Value = (decimal)((int)(start_pos_X * XDim / this.pctrBx_Image_Display.ClientSize.Width));
                nmrcUpDwn_Y_offset.Value = (decimal)((int)(start_pos_Y * YDim / this.pctrBx_Image_Display.ClientSize.Height));
            }
        }

        private void pctrBx_Image_Display_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_clicked)
            {
                int limit_Width = this.pctrBx_Image_Display.Width - start_pos_X;
                int limit_Height = this.pctrBx_Image_Display.Height - start_pos_Y;

                tmp_bmp.Dispose();
                tmp_bmp = (Bitmap)bmp.Clone();
                objGrp = Graphics.FromImage(tmp_bmp);

                if (start_pos_X <= e.Location.X && 0 <= e.Location.X && e.Location.X <= limit_Width)
                {
                    if (start_pos_Y <= e.Location.Y && 0 <= e.Location.Y && e.Location.Y <= limit_Height)
                    {
                        objGrp.DrawRectangle(objPen, start_pos_X, start_pos_Y, e.Location.X - start_pos_X, e.Location.Y - start_pos_Y);
                    }
                    else if (0 <= e.Location.Y && e.Location.Y <= limit_Height)
                    {
                        objGrp.DrawRectangle(objPen, start_pos_X, e.Location.Y, e.Location.X - start_pos_X, start_pos_Y - e.Location.Y);
                    }
                }
                else if (0 <= e.Location.X && e.Location.X <= limit_Width)
                {
                    if (start_pos_Y <= e.Location.Y && 0 <= e.Location.Y && e.Location.Y <= limit_Height)
                    {
                        objGrp.DrawRectangle(objPen, start_pos_X, start_pos_Y, start_pos_X - e.Location.X, e.Location.Y - start_pos_Y);
                    }
                    else if (0 <= e.Location.Y && e.Location.Y <= limit_Height)
                    {
                        objGrp.DrawRectangle(objPen, e.Location.X, e.Location.Y, start_pos_X - e.Location.X, start_pos_Y - e.Location.Y);
                    }
                }

                objGrp.Dispose();
                pre_pos_X = (int)(e.Location.X * XDim / this.pctrBx_Image_Display.ClientSize.Width);
                pre_pos_Y = (int)(e.Location.Y * YDim / this.pctrBx_Image_Display.ClientSize.Height);
                pctrBx_Image_Display.Image = tmp_bmp;
            }
        }

        private void pctrBx_Image_Display_MouseUp(object sender, MouseEventArgs e)
        {
            int limit_Width = this.pctrBx_Image_Display.Width - start_pos_X;
            int limit_Height = this.pctrBx_Image_Display.Height - start_pos_Y;

            mouse_clicked = false;
            tmp_bmp.Dispose();
            tmp_bmp = (Bitmap)bmp.Clone();
            objGrp = Graphics.FromImage(tmp_bmp);

            if (start_pos_X <= e.Location.X && 0 <= e.Location.X && e.Location.X <= limit_Width)
            {
                if (start_pos_Y <= e.Location.Y && 0 <= e.Location.Y && e.Location.Y <= limit_Height)
                {
                    objGrp.DrawRectangle(objPen, start_pos_X, start_pos_Y, e.Location.X - start_pos_X, e.Location.Y - start_pos_Y);
                }
                else if(0 <= e.Location.Y && e.Location.Y <= limit_Height)
                {
                    objGrp.DrawRectangle(objPen, start_pos_X, e.Location.Y, e.Location.X - start_pos_X, start_pos_Y - e.Location.Y  );
                }
            }
            else if(0 <= e.Location.X && e.Location.X <= limit_Width)
            {
                if (start_pos_Y <= e.Location.Y && 0 <= e.Location.Y && e.Location.Y <= limit_Height)
                {
                    objGrp.DrawRectangle(objPen, start_pos_X, start_pos_Y, start_pos_X - e.Location.X, e.Location.Y - start_pos_Y);
                }
                else if(0 <= e.Location.Y && e.Location.Y <= limit_Height)
                {
                    objGrp.DrawRectangle(objPen, e.Location.X, e.Location.Y, start_pos_X - e.Location.X, start_pos_Y - e.Location.Y);
                }
            }

            objGrp.Dispose();
            pre_pos_X = (int)(e.Location.X * XDim / this.pctrBx_Image_Display.ClientSize.Width);
            pre_pos_Y = (int)(e.Location.Y * YDim / this.pctrBx_Image_Display.ClientSize.Height);
            pctrBx_Image_Display.Image = tmp_bmp;
            nmrcUpDwn_X_size.Value = (decimal)Math.Abs(pre_pos_X - start_pos_X);
            nmrcUpDwn_Y_size.Value = (decimal)Math.Abs(pre_pos_Y - start_pos_Y);
        }

        private void nmrcUpDwn_X_offset_ValueChanged(object sender, EventArgs e)
        {
            if (nmrcUpDwn_X_offset.Value + nmrcUpDwn_X_size.Value > XDim)
            {
                return;
            }

            tmp_bmp.Dispose();
            tmp_bmp = (Bitmap)bmp.Clone();
            objGrp = Graphics.FromImage(tmp_bmp);
            objPen = new Pen(Color.Blue, 1);
            objPen.DashStyle = DashStyle.Dash;

            float X = (float)nmrcUpDwn_X_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Y = (float)nmrcUpDwn_Y_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;
            float Width = (float)nmrcUpDwn_X_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Height = (float)nmrcUpDwn_Y_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;

            objGrp.DrawRectangle(objPen, X, Y, Width - 1, Height - 1);

            objGrp.Dispose();
            pctrBx_Image_Display.Image = tmp_bmp;
        }

        private void nmrcUpDwn_Y_offset_ValueChanged(object sender, EventArgs e)
        {
            if (nmrcUpDwn_Y_offset.Value + nmrcUpDwn_Y_size.Value > YDim)
            {
                return;
            }

            tmp_bmp.Dispose();
            tmp_bmp = (Bitmap)bmp.Clone();
            objGrp = Graphics.FromImage(tmp_bmp);
            objPen = new Pen(Color.Blue, 1);
            objPen.DashStyle = DashStyle.Dash;

            float X = (float)nmrcUpDwn_X_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Y = (float)nmrcUpDwn_Y_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;
            float Width = (float)nmrcUpDwn_X_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Height = (float)nmrcUpDwn_Y_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;

            objGrp.DrawRectangle(objPen, X, Y, Width - 1, Height - 1);

            objGrp.Dispose();
            pctrBx_Image_Display.Image = tmp_bmp;
        }

        private void nmrcUpDwn_X_size_ValueChanged(object sender, EventArgs e)
        {
            if(nmrcUpDwn_X_offset.Value + nmrcUpDwn_X_size.Value > XDim)
            {
                return;
            }

            tmp_bmp.Dispose();
            tmp_bmp = (Bitmap)bmp.Clone();
            objGrp = Graphics.FromImage(tmp_bmp);
            objPen = new Pen(Color.Blue, 1);
            objPen.DashStyle = DashStyle.Dash;

            float X = (float)nmrcUpDwn_X_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Y = (float)nmrcUpDwn_Y_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;
            float Width = (float)nmrcUpDwn_X_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Height = (float)nmrcUpDwn_Y_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;

            objGrp.DrawRectangle(objPen, X, Y, Width - 1, Height - 1);

            objGrp.Dispose();
            pctrBx_Image_Display.Image = tmp_bmp;
        }

        private void nmrcUpDwn_Y_size_ValueChanged(object sender, EventArgs e)
        {
            if (nmrcUpDwn_Y_offset.Value + nmrcUpDwn_Y_size.Value > YDim)
            {
                return;
            }

            tmp_bmp.Dispose();
            tmp_bmp = (Bitmap)bmp.Clone();
            objGrp = Graphics.FromImage(tmp_bmp);
            objPen = new Pen(Color.Blue, 1);
            objPen.DashStyle = DashStyle.Dash;

            float X = (float)nmrcUpDwn_X_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Y = (float)nmrcUpDwn_Y_offset.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;
            float Width = (float)nmrcUpDwn_X_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Width / (float)XDim;
            float Height = (float)nmrcUpDwn_Y_size.Value * (float)this.pctrBx_Image_Display.ClientSize.Height / (float)YDim;

            objGrp.DrawRectangle(objPen, X, Y, Width - 1, Height - 1);

            objGrp.Dispose();
            pctrBx_Image_Display.Image = tmp_bmp;
        }

        private void bttn_ROI_Setting_Click(object sender, EventArgs e)
        {
            uint errorValue = 0;

            int X_offset = (int)nmrcUpDwn_X_offset.Value;
            int Y_offset = (int)nmrcUpDwn_Y_offset.Value;
            int X_size = (int)nmrcUpDwn_X_size.Value;
            int Y_size = (int)nmrcUpDwn_Y_size.Value;

            errorValue = AndorSDK.SetReadMode(ReadMode.Image);
            if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("ReadModeを変更できませんでした。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            errorValue = AndorSDK.SetImage(1, 1, X_offset, X_offset + X_size, Y_offset, Y_offset + Y_size);
            if(errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("Binningを変更できませんでした。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void bttn_full_width_Click(object sender, EventArgs e)
        {
            nmrcUpDwn_X_offset.Value = 0;
            nmrcUpDwn_X_size.Value = (decimal)XDim;
        }

        private void bttn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
