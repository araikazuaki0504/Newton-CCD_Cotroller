using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CCD_controller_windows_form
{
    public partial class SerialFiberAcquisitionForm : Form
    {
        private bool _Do_create_bmp = false;
        private ushort[] _Image;
        private float[] _Data;
        private float[] _BackGroundData;
        private float[,] _Several_Spectrum_Datum;
        private int _Image_Width;
        private int _Image_Height;
        private int _Fiber_qty = 37;
        private int _first_point = 20;
        private int _end_point = 373;
        private float[] _Horizon_Bining_Image_Data;
        private float[] _Linspace_forX_Axis;
        private int _Calibration = 0;
        private Bitmap _bmp;
        private Bitmap _tmp_bmp;
        private Graphics _objGrp;
        private Pen _objPen;
        private CCDImage_View_Form _CCDImage_View_form;
        private SeveralSpectrumForm _SeveralSpectrumform;


        public SerialFiberAcquisitionForm(float[] Image, int Image_Width, int Image_Height)
        {
            InitializeComponent();
            _Image = Array.ConvertAll<float, ushort>((float[])Image.Clone(), (float i) => { return (ushort)Math.Abs(i); });
            _Data = (float[])Image.Clone();
            _Image_Width = Image_Width;
            _Image_Height = Image_Height;
            _Horizon_Bining_Image_Data = new float[_Image_Height + 1];
            _Linspace_forX_Axis = new float[_Image_Height + 1];
            _objPen = new Pen(Color.Blue, 1);
            _objPen.DashStyle = DashStyle.Dash;
            for (int i = 0; i < _Image_Height; i++) _Linspace_forX_Axis[i] = i;
            plotDataBackgroundSubtractCheck();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public SerialFiberAcquisitionForm(ushort[] Image, int Image_Width, int Image_Height)
        {
            InitializeComponent();
            _Image = (ushort[])Image.Clone();
            _Data = Array.ConvertAll<ushort, float>((ushort[])Image.Clone(), (ushort i) => { return (float)i; });
            _Image_Width = Image_Width;
            _Image_Height = Image_Height;
            _Horizon_Bining_Image_Data = new float[_Image_Height + 1];
            _Linspace_forX_Axis = new float[_Image_Height + 1];
            _objPen = new Pen(Color.Blue, 1);
            _objPen.DashStyle = DashStyle.Dash;
            for (int i = 0; i < _Image_Height; i++) _Linspace_forX_Axis[i] = i;
            plotDataBackgroundSubtractCheck();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public float[,] Get_Several_Spectrum_Datum()
        {
            return _Several_Spectrum_Datum;
        }

        public void calculate_separetePoint()
        {
            Convert_Y_Binning_Data();
            PlotData("Spectrum");
        }

        public void set_BackGround_Image_for_ushort(ushort[] BackGround_Image)
        {
            _BackGroundData = Array.ConvertAll<ushort, float>((ushort[])BackGround_Image.Clone(), (ushort i) => { return (float)i; });
        }

        public void set_BackGround_Image_for_float(float[] BackGround_Image)
        {
            _BackGroundData = (float[])BackGround_Image.Clone();
        }

        private void DrawLine_To_CCDImage(float[] Separete_Point)
        {
            _tmp_bmp = (Bitmap)_bmp.Clone();
            _objGrp = Graphics.FromImage(_tmp_bmp);
            float correction_coff = _tmp_bmp.Height / _Image_Height;

            foreach(float Point in Separete_Point)
            {
                _objGrp.DrawLine(_objPen, 0,Point * correction_coff,_tmp_bmp.Width, Point * correction_coff);
            }

            this.pctrBx_CCD_Image.Image = _tmp_bmp;
            _Do_create_bmp = true;
        }

        private void PlotData(string name)
        {
            try
            {
                chrt_Seek_Peak_Graph.Series[name].Points.Clear();
            }
            catch
            {

            }

            for (int i = 0; i < _Image_Height; i++)
            {
                chrt_Seek_Peak_Graph.Series[name].Points.AddXY(_Linspace_forX_Axis[i], _Horizon_Bining_Image_Data[i]);
            }

            Axis axisX = chrt_Seek_Peak_Graph.ChartAreas[0].AxisX;
            Axis axisY = chrt_Seek_Peak_Graph.ChartAreas[0].AxisY;
            Axis axisY2 = chrt_Seek_Peak_Graph.ChartAreas[0].AxisY2;
            axisX.ScaleView.Zoomable = true;
            axisY.ScaleView.Zoomable = true;
            axisX.ScrollBar.Enabled = true;
            axisY.ScrollBar.Enabled = false;
            axisY2.ScrollBar.Enabled = false;
            axisX.IsMarginVisible = false;
            axisX.Title = "Y Axis Pixcel";
            axisY.Title = "Sum Counts";
            xAxisReset();
            yAxisReset();
        }

        private void xAxisReset()
        {
            Axis axisX = chrt_Seek_Peak_Graph.ChartAreas[0].AxisX;
        }

        private void yAxisReset()
        {
            Axis axisY = chrt_Seek_Peak_Graph.ChartAreas[0].AxisY;
            Axis axisY2 = chrt_Seek_Peak_Graph.ChartAreas[0].AxisY2;
            double num = _Horizon_Bining_Image_Data.Skip(0).Take(_Horizon_Bining_Image_Data.Length).Min();
            double num2 = _Horizon_Bining_Image_Data.Skip(0).Take(_Horizon_Bining_Image_Data.Length).Max();
            double num3 = num2 - num;

            if (num3 == 0.0)
            {
                num3 = 10.0;
            }

            int precision = (int)Math.Round(Math.Log10(Math.Abs(num3)));
            double value = num;
            double value2 = num2 + num3 / 10.0;
            double num4 = RoundToDigit(value, precision, roundup: false);
            double num5 = RoundToDigit(value2, precision, roundup: true);
        }

        private double RoundToDigit(double value, int precision, bool roundup)
        {
            double num = Math.Pow(10.0, precision);
            if (roundup)
            {
                return Math.Ceiling(value / num) * num;
            }
            return Math.Floor(value / num) * num;
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
                    double a = ((num3 == num2) ? ((double)((inBuffer[num4] - num2) * 8192)) : ((double)((inBuffer[num4] - num2) * 8192 / (num3 - num2))));
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

        private void Convert_Y_Binning_Data()
        {
            //if (_BackGroundData == null) read_defult_BackGroundImage();
            //float[] tmp_data = new float[_Image_Height * _Image_Width];
            //
            //for(int i = 0; i < _Image_Width * _Image_Height; i++)
            //{
            //    tmp_data[i] = _Data[i] - _BackGroundData[i];
            //}

            float[] Convolve_Data = Convolve2d(_Data,_Image_Width,_Image_Height,4);

            float[] tmp_array = new float[_Image_Height];
            float Convolved_Data_Ave = Convolve_Data.Average();
            
            for (int i = 0; i < _Image_Height + 1; i++)
            {
                for(int j = 0; j < _Image_Width + 1; j++)
                {
                    _Horizon_Bining_Image_Data[i] += (Convolve_Data[i * (_Image_Width + 1) + j] > Convolved_Data_Ave ? Convolve_Data[i * (_Image_Width + 1) + j] : 0);
                }
            }

            for(int i = 0; i < _Image_Height; i++)
            {
                int endIndex;

                if (i + 3 < _Image_Height - 1) endIndex = 3;
                else if (i + 2 < _Image_Height - 1) endIndex = 2;
                else endIndex = 1;

                float sum_for_ave = 0;

                for(int j = i; j < i + endIndex; j++)sum_for_ave += _Horizon_Bining_Image_Data[j];

                tmp_array[i] = sum_for_ave / endIndex;
            }

            float Minmum_number = tmp_array.Min();

            for(int i = 0; i < _Image_Height; i++) _Horizon_Bining_Image_Data[i] = tmp_array[i] -  Minmum_number;
        }

        float[] Derivative(float[] Data)
        {
            float[] diff = new float[Data.Length - 1];

            float previous_Data = Data[0];

            for(int i = 1; i < Data.Length; i++)
            {
                diff[i - 1] = Data[i] - previous_Data;
                previous_Data = Data[i];
            }

            return diff;
        }

        private float[] Find_Separete_Point()
        {
            int loopCounter = 0;

            float[] tmp_Horizon_Bining_Image_Data = new float[_end_point - _first_point + 1];//new float[_Horizon_Bining_Image_Data.Length];
            bool[] sdiff_sign = new bool[_end_point - _first_point];
            float[] tmp_array = new float[_Fiber_qty - 1];
            float[] target_point_x = new float[_Fiber_qty + 1];
            float[] target_point_y = new float[_Fiber_qty + 1];

            for(int i = 0; i < _end_point - _first_point + 1; i++)
            {
                int actual_index = i + _first_point;
                tmp_Horizon_Bining_Image_Data[i] = _Horizon_Bining_Image_Data[actual_index];
            }

            for (int i = 0; i < _end_point - _first_point + 1; i++) tmp_Horizon_Bining_Image_Data[i] *= -1;

            float[] sdiff = Derivative(tmp_Horizon_Bining_Image_Data);

            for(int i = 0; i < _end_point - _first_point - 1; i++)
            {
                sdiff_sign[i] = ((sdiff[i] * sdiff[i + 1] < 0) && (sdiff[i] > 0));
            }

            int tmp_size =  sdiff_sign.Sum((sign) => { if (sign) return 1; else return 0; });

            float[] tmp_x = new float[tmp_size];
            float[] tmp_y = new float[tmp_size];

            for(int i = 0; i < _end_point - _first_point; i++)
            {
                int actual_index = i + _first_point;
                if (sdiff_sign[i])
                {
                    tmp_x[loopCounter] = actual_index + 1;
                    tmp_y[loopCounter] = _Horizon_Bining_Image_Data[actual_index + 1];
                    loopCounter++;
                }
            }

            var sorted = tmp_y.Select((x, i) => new KeyValuePair<float, int>(x, i)).OrderByDescending(x => x.Key);

            for(int i = 0; i < _Fiber_qty - 1; i++)
            {
                tmp_array[i] = sorted.ElementAt(i).Value; 
            }

            for(int i = 0; i < _Fiber_qty - 1; i++)
            {
                target_point_x[i + 1] = tmp_x[(int)tmp_array[i]];
            }


            target_point_x[0] = _first_point;//0
            target_point_x[target_point_x.Length - 1] = _end_point;//263;

            float[] tmp = (float[])tmp_y.Clone();
            //Array.Sort(tmp_array);

            Array.Sort(tmp);
            Array.Reverse(tmp);

            for (int i = 0; i < _Fiber_qty - 1; i++)
            {
                target_point_y[i + 1] = tmp[i];
            }

            target_point_y[0] = _Horizon_Bining_Image_Data[_first_point];// tmp_Horizon_Bining_Image_Data[0];
            target_point_y[target_point_y.Length - 1] = _Horizon_Bining_Image_Data[_end_point]; //tmp_Horizon_Bining_Image_Data[263];

            float[] Separete_Point = (float[])target_point_x.Clone();

            if (this.chrt_Seek_Peak_Graph.Series.Count() != 1) this.chrt_Seek_Peak_Graph.Series.RemoveAt(1);

            Series newSeries = new Series();
            newSeries.ChartType = SeriesChartType.Point;
            newSeries.Name = "SeparetePoint";

            for (int i = 0; i < target_point_x.Length; i++)
            {
                newSeries.Points.AddXY(target_point_x[i], target_point_y[i]);
            }

            this.chrt_Seek_Peak_Graph.Series.Add(newSeries);

            Array.Sort(Separete_Point);

            return Separete_Point;
        }

        private void pctrBx_CCD_Image_Click(object sender, EventArgs e)
        {
            if(_Do_create_bmp && _CCDImage_View_form == null)
            {
                _CCDImage_View_form = new CCDImage_View_Form(_tmp_bmp);
                _CCDImage_View_form.Show();
            }
            else if(_CCDImage_View_form == null)
            {
                _CCDImage_View_form = new CCDImage_View_Form(_bmp);
                _CCDImage_View_form.Show();
            }
            else if(_Do_create_bmp && !_CCDImage_View_form.Visible)
            {
                _CCDImage_View_form.Dispose();
                _CCDImage_View_form = new CCDImage_View_Form(_tmp_bmp);
                _CCDImage_View_form.Show();
            }
            else if(!_CCDImage_View_form.Visible)
            {
                _CCDImage_View_form = new CCDImage_View_Form(_bmp);
                _CCDImage_View_form.Show();
            }
        }

        private void bttn_Find_Fiber_Line_Click(object sender, EventArgs e)
        {
            float[] Separete_Point = Find_Separete_Point();
            DrawLine_To_CCDImage(Separete_Point);

            _Several_Spectrum_Datum = new float[_Fiber_qty, _Image_Width];

            for (int i = 0; i < _Fiber_qty; i++)
            {
                float start_index = Separete_Point[i];
                float end_index = Separete_Point[i + 1];

                for (int j = (int)start_index; j < end_index; j++)
                {
                    for (int k = 0; k < _Image_Width; k++)
                    {
                        _Several_Spectrum_Datum[i, k] += _Data[j * _Image_Width + k];
                    }
                }
            }

            //_SeveralSpectrumform = new SeveralSpectrumForm(_Several_Spectrum_Datum);
            //_SeveralSpectrumform.Show();
        }

        private void bttn_Close_Click(object sender, EventArgs e)
        {
            if(_CCDImage_View_form != null)_CCDImage_View_form.Close();
            _SeveralSpectrumform.Close();
            this.Close();
        }

        private void nmrcUpDwn_Fiber_qty_ValueChanged(object sender, EventArgs e)
        {
            _Fiber_qty = (int)nmrcUpDwn_Fiber_qty.Value;
        }

        private float[] Convolve2d(float[] Image, int Width, int Height, int Convoled_size = 4)
        {
            int half_Convoled_size = Convoled_size / 2;

            float[] Convolved_Image = new float[(Width + 1) * (Height + 1)];
            float[] tmp_matrix = new float[(Width + Convoled_size) * (Height + Convoled_size)];
            
            
            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    tmp_matrix[(i + half_Convoled_size) * (Width + Convoled_size) + (j + half_Convoled_size)] = Image[i * Width + j];
                }
            }
            
            for (int i = 0; i < half_Convoled_size; i++)
            {
                for(int j = 0; j < half_Convoled_size; j++)
                {
                    tmp_matrix[i * (Width + Convoled_size) + j] = Image[0 * Width + 0];
                    tmp_matrix[i * (Width + Convoled_size) + (j + half_Convoled_size + Width)] = Image[0 * Width + (Width - 1)];
                    tmp_matrix[(i + half_Convoled_size + Height) * (Width + Convoled_size) + j] = Image[(Height - 1) * Width + 0];
                    tmp_matrix[(i + half_Convoled_size + Height) * (Width + Convoled_size) + (j + half_Convoled_size + Width)] = Image[(Height - 1) * Width + (Width - 1)];
                }
            }


            for(int i = 0; i < half_Convoled_size; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    tmp_matrix[(i + 0) * (Width + Convoled_size) + (j + half_Convoled_size)] = Image[0 * Width + j];
                    tmp_matrix[(i + half_Convoled_size + Height) * (Width + Convoled_size) + (j + half_Convoled_size)] = Image[(Height - 1) * Width + j];
                }
            }

            for (int i = 0; i < half_Convoled_size; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    tmp_matrix[(j + half_Convoled_size) * (Width + Convoled_size) + (i + 0)] = Image[j * Width + 0];
                    tmp_matrix[(j + half_Convoled_size) * (Width + Convoled_size) + (i + half_Convoled_size + Width)] = Image[j * Width + (Width - 1)];
                }
            }

            for (int i = 0; i < Height + 1; i++)
            {
                for (int j = 0; j < Width + 1; j++)
                {
                    float tmp_sum = 0;

                    for (int k = 0; k < Convoled_size; k++)
                    {
                        for (int l = 0; l < Convoled_size; l++)
                        {
                            tmp_sum += tmp_matrix[(k + i) * (Width + Convoled_size) + (l + j)];
                        }
                    }
                    Convolved_Image[i * (Width + 1) + j] = tmp_sum / (Convoled_size * Convoled_size);
                }
            }
            
            return Convolved_Image;
        }

        private void showMatrix(float[] matrix,int width,int height, bool allshow = true)
        {
            if((width > 7 || height > 7) && allshow)
            {
                Console.WriteLine("{");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(matrix[i * width + j].ToString() + ",");
                    }
            
                    Console.Write("...");
                    for (int j = width - 3; j < width; j++)
                    {
                        Console.Write(matrix[i * width + j].ToString() + ",");
                    }
            
                    Console.WriteLine("}");
                }
            
                Console.WriteLine("...");
            
                for (int i = height - 3; i < height; i++)
                {
                    Console.Write("{");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(matrix[i * width + j].ToString() + ",");
                    }
            
                    Console.Write("...");
                    for (int j = width - 3; j < width; j++)
                    {
                        Console.Write(matrix[i * width + j].ToString() + ",");
                    }
            
                    Console.WriteLine("}");
                }
                Console.WriteLine("}");
            
                return;
            }

            Console.WriteLine("{");
            for (int i = 0; i < height; i++)
            {
                Console.Write("{");
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i * width + j].ToString() + ",");
                }
                Console.WriteLine("}");
            }
            Console.WriteLine("}");
        }

        private void read_defult_BackGroundImage()
        {
            string FilePath = "CCDImage_2024123143255_backgroundImage.csv";
            int col_index = 0;
            int row_index = 0;
            List<float> data = new List<float>();


            StreamReader reader = new StreamReader(FilePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                row_index = 0;
                if (line == "")
                {
                    continue;
                }
                else
                {
                    foreach (string rowNumber in line.Split(','))
                    {
                        data.Add(float.Parse(rowNumber));
                        row_index++;
                    }
                }
                col_index++;
            }

            _BackGroundData = data.ToArray();
        }
    }
}
