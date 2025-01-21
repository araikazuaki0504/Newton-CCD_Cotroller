using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCD_controller_windows_form
{
    public partial class Import_Image_Viewer : Form
    {
        private bool _Do_create_bmp = false;
        private int _Image_Width;
        private int _Image_Height;
        private ushort[] _Image;
        private Bitmap _bmp;
        private CCDImage_View_Form _CCDImage_View_form;

        public Import_Image_Viewer(ushort[] Image, int Image_width, int Image_height)
        {
            InitializeComponent();
            this._Image_Width = Image_width;
            this._Image_Height = Image_height;
            this._Image = (ushort[])Image.Clone();

            plotDataBackgroundSubtractCheck();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void change_Image(ushort[] Image, int Image_width, int Image_height)
        {
            this._Image_Width = Image_width;
            this._Image_Height = Image_height;
            this._Image = (ushort[])Image.Clone();

            plotDataBackgroundSubtractCheck();

            _CCDImage_View_form.change_Image(_bmp);
        }

        private void plotDataBackgroundSubtractCheck()
        {
            int[] array = new int[_Image.Length];
            for (int i = 0; i < _Image.Length; i++)
            {
                array[i] = _Image[i];
            }
            byte[] pixelValues = Convert16BitGrayScaleToRgb48(array, _Image_Width, _Image_Height);
            _bmp = CreateBitmapFromBytes(pixelValues, _Image_Width, _Image_Height);
            pctrBx_CCD_Image.Image = _bmp;
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
            _bmp = new Bitmap(width, height, PixelFormat.Format48bppRgb);
            Rectangle rect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
            BitmapData bitmapData = _bmp.LockBits(rect, ImageLockMode.ReadWrite, _bmp.PixelFormat);
            IntPtr scan = bitmapData.Scan0;
            Marshal.Copy(pixelValues, 0, scan, pixelValues.Length);
            _bmp.UnlockBits(bitmapData);

            return _bmp;
        }

        private void pctrBx_CCD_Image_Click(object sender, EventArgs e)
        {
            if (_Do_create_bmp && _CCDImage_View_form == null)
            {
                _CCDImage_View_form = new CCDImage_View_Form(_bmp);
                _CCDImage_View_form.Show();
            }
            else if (_CCDImage_View_form == null)
            {
                _CCDImage_View_form = new CCDImage_View_Form(_bmp);
                _CCDImage_View_form.Show();
            }
            else if (_Do_create_bmp && !_CCDImage_View_form.Visible)
            {
                _CCDImage_View_form.Dispose();
                _CCDImage_View_form = new CCDImage_View_Form(_bmp);
                _CCDImage_View_form.Show();
            }
            else if (!_CCDImage_View_form.Visible)
            {
                _CCDImage_View_form = new CCDImage_View_Form(_bmp);
                _CCDImage_View_form.Show();
            }
        }
    }
}
