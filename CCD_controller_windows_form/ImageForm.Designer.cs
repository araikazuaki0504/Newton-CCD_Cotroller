namespace CCD_controller_windows_form
{
    partial class ImageForm
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
            this.pctrBx_Image_Display = new System.Windows.Forms.PictureBox();
            this.lbl_X_offset_text = new System.Windows.Forms.Label();
            this.lbl_Y_offset_text = new System.Windows.Forms.Label();
            this.lbl_Y_size_text = new System.Windows.Forms.Label();
            this.lbl_X_size_text = new System.Windows.Forms.Label();
            this.nmrcUpDwn_X_offset = new System.Windows.Forms.NumericUpDown();
            this.nmrcUpDwn_Y_offset = new System.Windows.Forms.NumericUpDown();
            this.nmrcUpDwn_X_size = new System.Windows.Forms.NumericUpDown();
            this.nmrcUpDwn_Y_size = new System.Windows.Forms.NumericUpDown();
            this.bttn_ROI_Setting = new System.Windows.Forms.Button();
            this.grpBx_ROI_setting = new System.Windows.Forms.GroupBox();
            this.bttn_full_width = new System.Windows.Forms.Button();
            this.bttn_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBx_Image_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_X_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Y_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_X_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Y_size)).BeginInit();
            this.grpBx_ROI_setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctrBx_Image_Display
            // 
            this.pctrBx_Image_Display.Location = new System.Drawing.Point(10, 10);
            this.pctrBx_Image_Display.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctrBx_Image_Display.Name = "pctrBx_Image_Display";
            this.pctrBx_Image_Display.Size = new System.Drawing.Size(819, 220);
            this.pctrBx_Image_Display.TabIndex = 0;
            this.pctrBx_Image_Display.TabStop = false;
            this.pctrBx_Image_Display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctrBx_Image_Display_MouseDown);
            this.pctrBx_Image_Display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctrBx_Image_Display_MouseMove);
            this.pctrBx_Image_Display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctrBx_Image_Display_MouseUp);
            // 
            // lbl_X_offset_text
            // 
            this.lbl_X_offset_text.AutoSize = true;
            this.lbl_X_offset_text.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_X_offset_text.Location = new System.Drawing.Point(14, 22);
            this.lbl_X_offset_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_X_offset_text.Name = "lbl_X_offset_text";
            this.lbl_X_offset_text.Size = new System.Drawing.Size(65, 17);
            this.lbl_X_offset_text.TabIndex = 1;
            this.lbl_X_offset_text.Text = "X offset";
            // 
            // lbl_Y_offset_text
            // 
            this.lbl_Y_offset_text.AutoSize = true;
            this.lbl_Y_offset_text.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Y_offset_text.Location = new System.Drawing.Point(14, 54);
            this.lbl_Y_offset_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Y_offset_text.Name = "lbl_Y_offset_text";
            this.lbl_Y_offset_text.Size = new System.Drawing.Size(65, 17);
            this.lbl_Y_offset_text.TabIndex = 2;
            this.lbl_Y_offset_text.Text = "Y offset";
            // 
            // lbl_Y_size_text
            // 
            this.lbl_Y_size_text.AutoSize = true;
            this.lbl_Y_size_text.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Y_size_text.Location = new System.Drawing.Point(14, 125);
            this.lbl_Y_size_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Y_size_text.Name = "lbl_Y_size_text";
            this.lbl_Y_size_text.Size = new System.Drawing.Size(52, 17);
            this.lbl_Y_size_text.TabIndex = 4;
            this.lbl_Y_size_text.Text = "Y size";
            // 
            // lbl_X_size_text
            // 
            this.lbl_X_size_text.AutoSize = true;
            this.lbl_X_size_text.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_X_size_text.Location = new System.Drawing.Point(14, 92);
            this.lbl_X_size_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_X_size_text.Name = "lbl_X_size_text";
            this.lbl_X_size_text.Size = new System.Drawing.Size(52, 17);
            this.lbl_X_size_text.TabIndex = 3;
            this.lbl_X_size_text.Text = "X size";
            // 
            // nmrcUpDwn_X_offset
            // 
            this.nmrcUpDwn_X_offset.Location = new System.Drawing.Point(97, 22);
            this.nmrcUpDwn_X_offset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmrcUpDwn_X_offset.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.nmrcUpDwn_X_offset.Name = "nmrcUpDwn_X_offset";
            this.nmrcUpDwn_X_offset.Size = new System.Drawing.Size(96, 22);
            this.nmrcUpDwn_X_offset.TabIndex = 5;
            this.nmrcUpDwn_X_offset.ValueChanged += new System.EventHandler(this.nmrcUpDwn_X_offset_ValueChanged);
            // 
            // nmrcUpDwn_Y_offset
            // 
            this.nmrcUpDwn_Y_offset.Location = new System.Drawing.Point(97, 54);
            this.nmrcUpDwn_Y_offset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmrcUpDwn_Y_offset.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nmrcUpDwn_Y_offset.Name = "nmrcUpDwn_Y_offset";
            this.nmrcUpDwn_Y_offset.Size = new System.Drawing.Size(96, 22);
            this.nmrcUpDwn_Y_offset.TabIndex = 6;
            this.nmrcUpDwn_Y_offset.ValueChanged += new System.EventHandler(this.nmrcUpDwn_Y_offset_ValueChanged);
            // 
            // nmrcUpDwn_X_size
            // 
            this.nmrcUpDwn_X_size.Location = new System.Drawing.Point(97, 92);
            this.nmrcUpDwn_X_size.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmrcUpDwn_X_size.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nmrcUpDwn_X_size.Name = "nmrcUpDwn_X_size";
            this.nmrcUpDwn_X_size.Size = new System.Drawing.Size(96, 22);
            this.nmrcUpDwn_X_size.TabIndex = 7;
            this.nmrcUpDwn_X_size.ValueChanged += new System.EventHandler(this.nmrcUpDwn_X_size_ValueChanged);
            // 
            // nmrcUpDwn_Y_size
            // 
            this.nmrcUpDwn_Y_size.Location = new System.Drawing.Point(97, 125);
            this.nmrcUpDwn_Y_size.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmrcUpDwn_Y_size.Maximum = new decimal(new int[] {
            264,
            0,
            0,
            0});
            this.nmrcUpDwn_Y_size.Name = "nmrcUpDwn_Y_size";
            this.nmrcUpDwn_Y_size.Size = new System.Drawing.Size(96, 22);
            this.nmrcUpDwn_Y_size.TabIndex = 8;
            this.nmrcUpDwn_Y_size.ValueChanged += new System.EventHandler(this.nmrcUpDwn_Y_size_ValueChanged);
            // 
            // bttn_ROI_Setting
            // 
            this.bttn_ROI_Setting.Location = new System.Drawing.Point(208, 119);
            this.bttn_ROI_Setting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttn_ROI_Setting.Name = "bttn_ROI_Setting";
            this.bttn_ROI_Setting.Size = new System.Drawing.Size(103, 41);
            this.bttn_ROI_Setting.TabIndex = 9;
            this.bttn_ROI_Setting.Text = "Set";
            this.bttn_ROI_Setting.UseVisualStyleBackColor = true;
            this.bttn_ROI_Setting.Click += new System.EventHandler(this.bttn_ROI_Setting_Click);
            // 
            // grpBx_ROI_setting
            // 
            this.grpBx_ROI_setting.Controls.Add(this.bttn_full_width);
            this.grpBx_ROI_setting.Controls.Add(this.nmrcUpDwn_Y_size);
            this.grpBx_ROI_setting.Controls.Add(this.bttn_ROI_Setting);
            this.grpBx_ROI_setting.Controls.Add(this.lbl_X_offset_text);
            this.grpBx_ROI_setting.Controls.Add(this.lbl_Y_offset_text);
            this.grpBx_ROI_setting.Controls.Add(this.nmrcUpDwn_X_size);
            this.grpBx_ROI_setting.Controls.Add(this.lbl_X_size_text);
            this.grpBx_ROI_setting.Controls.Add(this.nmrcUpDwn_Y_offset);
            this.grpBx_ROI_setting.Controls.Add(this.lbl_Y_size_text);
            this.grpBx_ROI_setting.Controls.Add(this.nmrcUpDwn_X_offset);
            this.grpBx_ROI_setting.Location = new System.Drawing.Point(10, 235);
            this.grpBx_ROI_setting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBx_ROI_setting.Name = "grpBx_ROI_setting";
            this.grpBx_ROI_setting.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBx_ROI_setting.Size = new System.Drawing.Size(316, 165);
            this.grpBx_ROI_setting.TabIndex = 10;
            this.grpBx_ROI_setting.TabStop = false;
            this.grpBx_ROI_setting.Text = "ROI Setting";
            // 
            // bttn_full_width
            // 
            this.bttn_full_width.Location = new System.Drawing.Point(208, 80);
            this.bttn_full_width.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttn_full_width.Name = "bttn_full_width";
            this.bttn_full_width.Size = new System.Drawing.Size(87, 29);
            this.bttn_full_width.TabIndex = 11;
            this.bttn_full_width.Text = "Full Width";
            this.bttn_full_width.UseVisualStyleBackColor = true;
            this.bttn_full_width.Click += new System.EventHandler(this.bttn_full_width_Click);
            // 
            // bttn_Close
            // 
            this.bttn_Close.Location = new System.Drawing.Point(722, 349);
            this.bttn_Close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttn_Close.Name = "bttn_Close";
            this.bttn_Close.Size = new System.Drawing.Size(103, 41);
            this.bttn_Close.TabIndex = 12;
            this.bttn_Close.Text = "Close";
            this.bttn_Close.UseVisualStyleBackColor = true;
            this.bttn_Close.Click += new System.EventHandler(this.bttn_Close_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 406);
            this.Controls.Add(this.bttn_Close);
            this.Controls.Add(this.grpBx_ROI_setting);
            this.Controls.Add(this.pctrBx_Image_Display);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            ((System.ComponentModel.ISupportInitialize)(this.pctrBx_Image_Display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_X_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Y_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_X_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Y_size)).EndInit();
            this.grpBx_ROI_setting.ResumeLayout(false);
            this.grpBx_ROI_setting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrBx_Image_Display;
        private System.Windows.Forms.Label lbl_X_offset_text;
        private System.Windows.Forms.Label lbl_Y_offset_text;
        private System.Windows.Forms.Label lbl_Y_size_text;
        private System.Windows.Forms.Label lbl_X_size_text;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_X_offset;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_Y_offset;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_X_size;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_Y_size;
        private System.Windows.Forms.Button bttn_ROI_Setting;
        private System.Windows.Forms.GroupBox grpBx_ROI_setting;
        private System.Windows.Forms.Button bttn_full_width;
        private System.Windows.Forms.Button bttn_Close;
    }
}