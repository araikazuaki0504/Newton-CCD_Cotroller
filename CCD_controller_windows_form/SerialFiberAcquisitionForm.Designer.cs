namespace CCD_controller_windows_form
{
    partial class SerialFiberAcquisitionForm
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
            this.pctrBx_CCD_Image = new System.Windows.Forms.PictureBox();
            this.chrt_Seek_Peak_Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bttn_Find_Fiber_Line = new System.Windows.Forms.Button();
            this.bttn_Close = new System.Windows.Forms.Button();
            this.nmrcUpDwn_Fiber_qty = new System.Windows.Forms.NumericUpDown();
            this.lbl_fiber_qty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBx_CCD_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_Seek_Peak_Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Fiber_qty)).BeginInit();
            this.SuspendLayout();
            // 
            // pctrBx_CCD_Image
            // 
            this.pctrBx_CCD_Image.Location = new System.Drawing.Point(12, 12);
            this.pctrBx_CCD_Image.Name = "pctrBx_CCD_Image";
            this.pctrBx_CCD_Image.Size = new System.Drawing.Size(776, 174);
            this.pctrBx_CCD_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrBx_CCD_Image.TabIndex = 0;
            this.pctrBx_CCD_Image.TabStop = false;
            this.pctrBx_CCD_Image.Click += new System.EventHandler(this.pctrBx_CCD_Image_Click);
            // 
            // chrt_Seek_Peak_Graph
            // 
            chartArea1.Name = "ChartArea1";
            this.chrt_Seek_Peak_Graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            this.chrt_Seek_Peak_Graph.Legends.Add(legend1);
            this.chrt_Seek_Peak_Graph.Location = new System.Drawing.Point(12, 192);
            this.chrt_Seek_Peak_Graph.Name = "chrt_Seek_Peak_Graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Spectrum";
            this.chrt_Seek_Peak_Graph.Series.Add(series1);
            this.chrt_Seek_Peak_Graph.Size = new System.Drawing.Size(422, 391);
            this.chrt_Seek_Peak_Graph.TabIndex = 0;
            this.chrt_Seek_Peak_Graph.Text = "spectrum";
            // 
            // bttn_Find_Fiber_Line
            // 
            this.bttn_Find_Fiber_Line.Location = new System.Drawing.Point(626, 465);
            this.bttn_Find_Fiber_Line.Name = "bttn_Find_Fiber_Line";
            this.bttn_Find_Fiber_Line.Size = new System.Drawing.Size(162, 48);
            this.bttn_Find_Fiber_Line.TabIndex = 1;
            this.bttn_Find_Fiber_Line.Text = "Find Fiber Line";
            this.bttn_Find_Fiber_Line.UseVisualStyleBackColor = true;
            this.bttn_Find_Fiber_Line.Click += new System.EventHandler(this.bttn_Find_Fiber_Line_Click);
            // 
            // bttn_Close
            // 
            this.bttn_Close.Location = new System.Drawing.Point(626, 535);
            this.bttn_Close.Name = "bttn_Close";
            this.bttn_Close.Size = new System.Drawing.Size(162, 48);
            this.bttn_Close.TabIndex = 2;
            this.bttn_Close.Text = "Close";
            this.bttn_Close.UseVisualStyleBackColor = true;
            this.bttn_Close.Click += new System.EventHandler(this.bttn_Close_Click);
            // 
            // nmrcUpDwn_Fiber_qty
            // 
            this.nmrcUpDwn_Fiber_qty.Location = new System.Drawing.Point(668, 413);
            this.nmrcUpDwn_Fiber_qty.Name = "nmrcUpDwn_Fiber_qty";
            this.nmrcUpDwn_Fiber_qty.Size = new System.Drawing.Size(120, 25);
            this.nmrcUpDwn_Fiber_qty.TabIndex = 3;
            this.nmrcUpDwn_Fiber_qty.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nmrcUpDwn_Fiber_qty.ValueChanged += new System.EventHandler(this.nmrcUpDwn_Fiber_qty_ValueChanged);
            // 
            // lbl_fiber_qty
            // 
            this.lbl_fiber_qty.AutoSize = true;
            this.lbl_fiber_qty.Location = new System.Drawing.Point(506, 413);
            this.lbl_fiber_qty.Name = "lbl_fiber_qty";
            this.lbl_fiber_qty.Size = new System.Drawing.Size(131, 18);
            this.lbl_fiber_qty.TabIndex = 4;
            this.lbl_fiber_qty.Text = "Number of fibers";
            // 
            // SerialFiberAquisitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.lbl_fiber_qty);
            this.Controls.Add(this.nmrcUpDwn_Fiber_qty);
            this.Controls.Add(this.bttn_Close);
            this.Controls.Add(this.bttn_Find_Fiber_Line);
            this.Controls.Add(this.chrt_Seek_Peak_Graph);
            this.Controls.Add(this.pctrBx_CCD_Image);
            this.Name = "SerialFiberAquisitionForm";
            this.Text = "SerialFiberAquisition";
            ((System.ComponentModel.ISupportInitialize)(this.pctrBx_CCD_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_Seek_Peak_Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Fiber_qty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrBx_CCD_Image;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_Seek_Peak_Graph;
        private System.Windows.Forms.Button bttn_Find_Fiber_Line;
        private System.Windows.Forms.Button bttn_Close;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_Fiber_qty;
        private System.Windows.Forms.Label lbl_fiber_qty;
    }
}