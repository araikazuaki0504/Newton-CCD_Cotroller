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
        private const int _Selected_Spectrum_Max = 2;
        private int _Spectrum_qty;
        private int _Spectrum_X_Size;
        private int _latest_checked_index = 0;
        private double[] _Spectrum_Datum;
        private int[] _Linspace_forX_Axis;
        private List<bool> _isChecked;

        public event EventHandler _Is_Button_Clicked;

        public SeveralSpectrumForm(double[] SpectrumDatum, int colunm, int row)
        {
            InitializeComponent();

            _Spectrum_Datum = (double[])SpectrumDatum.Clone();
            _Spectrum_qty = colunm;
            _Spectrum_X_Size = row;
            _Linspace_forX_Axis = new int[_Spectrum_X_Size];
            _isChecked = new List<bool>();
            for (int i = 0; i < _Spectrum_X_Size; i++) _Linspace_forX_Axis[i] = i;
            showSpectrum();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public int[] Get_Selected_Spectrum()
        {
            List<int> Selected_Spectrum = new List<int>();

            for (int i = 0; i < _Spectrum_qty; i++)
            {
                if (_isChecked[i]) Selected_Spectrum.Add(i);
            }

            return Selected_Spectrum.ToArray();
        }

        private void showSpectrum()
        {
            const int Graph_Width = 800;
            const int Graph_Hieght = 80;
            const int Control_margin = 20;

            this.ClientSize = new Size(Graph_Width, Graph_Hieght);

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

                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Text = "";
                checkBox.Location = new Point(Control_margin, Control_margin + Graph_Hieght * i);
                checkBox.Name = (i + 1).ToString();
                checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
                this.Controls.Add(checkBox);

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
                chart.Location = new Point(checkBox.Size.Width, Graph_Hieght * i);

                series.ChartType = SeriesChartType.Line;

                for (int j = 0; j < _Linspace_forX_Axis.Length; j++)
                {
                    series.Points.AddXY(_Linspace_forX_Axis[j], _Spectrum_Datum[i * _Spectrum_X_Size + j]);
                }

                chart.Series.Add(series);
                chart.Size = new Size(Graph_Width, Graph_Hieght);

                this.Controls.Add(chart);

                int new_Client_Hieght = Graph_Hieght * (i + 1);
                this.ClientSize = new Size(Graph_Width + checkBox.Width, new_Client_Hieght);

                _isChecked.Add(false);
            }

            Button button = new Button();
            button.Text = "Create Distribution Image";
            button.Size = new Size(120, 45);
            button.Location = new Point(this.Width - button.Size.Width - Control_margin,  this.ClientSize.Height);
            button.Click += new EventHandler(button_Click);

            this.Controls.Add(button);
            this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + button.Size.Height + Control_margin);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (!checkBox.Checked)
            {
                int index = int.Parse(checkBox.Name) - 1;
                _isChecked[index] = false;
                return;
            }

            if (_isChecked.Sum<bool>((bool x) => { return Convert.ToInt64(x); }) != _Selected_Spectrum_Max)
            {
                int index = int.Parse(checkBox.Name) - 1;
                _isChecked[index] = true;
                _latest_checked_index = index;
            }
            else
            {
                _isChecked[_latest_checked_index] = false;
                int erase_index = _isChecked.FindIndex((bool x) => { return x; });
                _isChecked[_latest_checked_index] = true;
                _isChecked[erase_index] = false;
                ((CheckBox)(this.Controls.Find((erase_index + 1).ToString(), true)[0])).Checked = false;

                int index = int.Parse(checkBox.Name) - 1;
                _isChecked[index] = true;
                _latest_checked_index = index;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
           if(_isChecked.Sum<bool>((bool x) => { return Convert.ToInt64(x); }) == _Selected_Spectrum_Max) _Is_Button_Clicked(this, EventArgs.Empty);
        }
    }
}
