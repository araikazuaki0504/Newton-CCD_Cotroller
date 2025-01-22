using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CCD_controller_windows_form
{
    public partial class SeveralSpectrumForm : Form
    {
        private double[] _Spectrum_Datum;
        private int[] _Linspace_forX_Axis;
        private int _Spectrum_qty;
        private int _Spectrum_X_Size;

        public SeveralSpectrumForm(double[] SpectrumDatum, int colunm, int row)
        {
            InitializeComponent();

            _Spectrum_Datum = (double[])SpectrumDatum.Clone();
            _Spectrum_qty = colunm;
            _Spectrum_X_Size = row;
            _Linspace_forX_Axis = new int[_Spectrum_X_Size];
            for (int i = 0; i <_Spectrum_X_Size; i++) _Linspace_forX_Axis[i] = i;
            showSpectrum();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void showSpectrum()
        {
            const int Client_Width = 800;
            const int Graph_Hieght = 80;

            this.ClientSize = new Size(Client_Width, Graph_Hieght); 

            for (int i = 0; i < _Spectrum_qty; i++)
            {
                double[] tmp_Row_Data = new double[_Spectrum_X_Size];
                Array.Copy(_Spectrum_Datum, i * _Spectrum_X_Size, tmp_Row_Data, 0, _Spectrum_X_Size);

                double Max_Row_Data = tmp_Row_Data.Max();
                double Min_Row_Data = tmp_Row_Data.Min();

                double MaxData_digit = (int)Math.Log10(Max_Row_Data);
                double MinData_digit = (int)Math.Log10(Min_Row_Data);

                double axisY_Max = 0;
                double axisY_Min = 0;

                if (MaxData_digit > 3) axisY_Max = (Max_Row_Data - Max_Row_Data % (int)Math.Pow(10, MaxData_digit - 2)) + (int)Math.Pow(10, MaxData_digit - 2);
                else axisY_Max = (Max_Row_Data - Max_Row_Data % (int)Math.Pow(10, MaxData_digit - 1)) + (int)Math.Pow(10, MaxData_digit - 1);

                if (MinData_digit > 3) axisY_Min = (Min_Row_Data - Min_Row_Data % (int)Math.Pow(10, MinData_digit - 2)) - (int)Math.Pow(10, MinData_digit - 2);
                else if (MinData_digit < 1) axisY_Min = 0;
                else axisY_Min = (Min_Row_Data - Min_Row_Data % (int)Math.Pow(10, MinData_digit - 1)) - (int)Math.Pow(10, MinData_digit - 1);


                int new_Client_Hieght = Graph_Hieght * (i + 1);
                this.ClientSize = new Size(Client_Width, new_Client_Hieght);

                Chart chart = new Chart();
                ChartArea chartArea = new ChartArea();
                Series series = new Series();

                Axis axisX = chartArea.AxisX;
                Axis axisY = chartArea.AxisY;
                axisX.MajorGrid.Enabled = false;
                axisY.MajorGrid.Enabled = false;
                axisY.Maximum = axisY_Max;
                axisY.Minimum = axisY_Min;
                axisY.Interval = axisY.Maximum - axisY.Minimum;
                axisX.ScaleView.Zoomable = true;
                axisX.IsMarginVisible = false;
                axisX.Title = "";
                axisY.Title = "Counts";

                chart.Name = "chart" + (i + 1).ToString();
                chart.ChartAreas.Add(chartArea);
                chart.Location = new Point(0, Graph_Hieght * i);

                series.ChartType = SeriesChartType.Line;

                for (int j = 0; j < _Linspace_forX_Axis.Length; j++)
                {
                    series.Points.AddXY(_Linspace_forX_Axis[j], _Spectrum_Datum[i * _Spectrum_X_Size +  j]);
                }

                chart.Series.Add(series);
                chart.Size = new Size(Client_Width, Graph_Hieght);

                this.Controls.Add(chart);
            }
        }
    }
}
