namespace CCD_controller_windows_form
{
    partial class DisplayGraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chrt_Spectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_Spectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // chrt_Spectrum
            // 
            chartArea1.Name = "ChartArea1";
            this.chrt_Spectrum.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrt_Spectrum.Legends.Add(legend1);
            this.chrt_Spectrum.Location = new System.Drawing.Point(12, 12);
            this.chrt_Spectrum.Name = "chrt_Spectrum";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Spectrum";
            this.chrt_Spectrum.Series.Add(series1);
            this.chrt_Spectrum.Size = new System.Drawing.Size(670, 660);
            this.chrt_Spectrum.TabIndex = 0;
            this.chrt_Spectrum.Text = "spectrum";
            // 
            // DisplayGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 684);
            this.Controls.Add(this.chrt_Spectrum);
            this.Name = "DisplayGraphForm";
            this.Text = "Display_Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chrt_Spectrum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_Spectrum;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}