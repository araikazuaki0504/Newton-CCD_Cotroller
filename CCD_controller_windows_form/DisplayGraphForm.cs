using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace CCD_controller_windows_form
{
    public partial class DisplayGraphForm : Form
    {
        private double[] xArray;

        private double[] yArray;

        private double[] yOriginalArray;

        private double[] yBackgroundArray;

        private string unit = "Pixel";

        private double[] singlePoint = new double[2];

        private string plotName;

        public double[] XarrayData
        {
            get
            {
                return xArray;
            }
            set
            {
                if (xArray != value)
                {
                    xArray = value;
                }
            }
        }

        public double[] YarrayData
        {
            get
            {
                return yArray;
            }
            set
            {
                yOriginalArray = value;
                yArray = new double[value.Length];
                if (yOriginalArray.Length == yBackgroundArray.Length)
                {
                    for (int i = 0; i < yArray.Length; i++)
                    {
                        //if (chkSubtractBackground.Checked)
                        //{
                        //    yArray[i] = yOriginalArray[i] - yBackgroundArray[i];
                        //}
                        //else
                        //{
                            yArray[i] = yOriginalArray[i];
                        //}
                    }
                }
                plotData(plotName);
            }
        }

        public double[] Point => singlePoint;

        public string Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
                plotData(plotName);
            }
        }

        public DisplayGraphForm(double[] xValues, double[] yValues, string name, string _unit)
        {
            InitializeComponent();
            yBackgroundArray = new double[yValues.Length];
            xArray = (double[])xValues.Clone();
            yArray = (double[])yValues.Clone();
            yOriginalArray = (double[])yValues.Clone();
            plotName = name;
            unit = _unit;
            plotData(plotName);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void plotData(string name)
        {
            try
            {
                chrt_Spectrum.Series[plotName].Points.Clear();
            }
            catch
            {

            }

            for (int i = 0; i < xArray.Length; i++)
            {
                chrt_Spectrum.Series[name].Points.AddXY(xArray[i], yArray[i]);
            }

            Axis axisX = chrt_Spectrum.ChartAreas[0].AxisX;
            Axis axisY = chrt_Spectrum.ChartAreas[0].AxisY;
            Axis axisY2 = chrt_Spectrum.ChartAreas[0].AxisY2;
            axisX.ScaleView.Zoomable = true;
            axisY.ScaleView.Zoomable = true;
            axisX.ScrollBar.Enabled = true;
            axisY.ScrollBar.Enabled = false;
            axisY2.ScrollBar.Enabled = false;
            axisX.IsMarginVisible = false;
            axisX.Title = unit;
            axisY.Title = "Counts";
            xAxisReset();
            yAxisReset();
        }

        private void xAxisReset()
        {
            Axis axisX = chrt_Spectrum.ChartAreas[0].AxisX;
        }

        private void yAxisReset()
        {
            Axis axisY = chrt_Spectrum.ChartAreas[0].AxisY;
            Axis axisY2 = chrt_Spectrum.ChartAreas[0].AxisY2;
            double num = yArray.Skip(0).Take(yArray.Length).Min();
            double num2 = yArray.Skip(0).Take(yArray.Length).Max();
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

            //if (!FixYAxisRange.Checked)
            //{
            //    double minimum = (axisY2.Minimum = num4);
            //    axisY.Minimum = minimum;
            //    minimum = (axisY2.Maximum = num5);
            //    axisY.Maximum = minimum;
            //    axisY.ScaleView.ZoomReset();
            //    axisY2.ScaleView.ZoomReset();
            //}
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
    }
}
