namespace CCD_controller_windows_form
{
    partial class mainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpBx_Setting_temp = new System.Windows.Forms.GroupBox();
            this.bttn_Setting_CCD_Temperature = new System.Windows.Forms.Button();
            this.nmrcUpDwn_Setting_Temperature = new System.Windows.Forms.NumericUpDown();
            this.lbl_Setting_CCD_Temperature = new System.Windows.Forms.Label();
            this.chckBx_Enable_Active_Cooling = new System.Windows.Forms.CheckBox();
            this.lbl_CCD_Temp = new System.Windows.Forms.Label();
            this.lbl_PCB_Temp = new System.Windows.Forms.Label();
            this.lbl_CCD_Temp_Text = new System.Windows.Forms.Label();
            this.lbl_PCB_Temp_Text = new System.Windows.Forms.Label();
            this.grpBx_Acquire_Data = new System.Windows.Forms.GroupBox();
            this.chckBx_Write_CSV = new System.Windows.Forms.CheckBox();
            this.lbl_set_FrameRate = new System.Windows.Forms.Label();
            this.lbl_Set_ExposureTime = new System.Windows.Forms.Label();
            this.chckBx_set_as_BackGround = new System.Windows.Forms.CheckBox();
            this.bttn_Stop = new System.Windows.Forms.Button();
            this.bttn_Acquire_Frame = new System.Windows.Forms.Button();
            this.chckBx_continuous = new System.Windows.Forms.CheckBox();
            this.nmrcUpDwn_Number_of_Frame = new System.Windows.Forms.NumericUpDown();
            this.lbl_Number_of_Frames_txt = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdBttn_Image = new System.Windows.Forms.RadioButton();
            this.rdBttn_FVB = new System.Windows.Forms.RadioButton();
            this.lbl_Binning = new System.Windows.Forms.Label();
            this.pnl_unit_forExpTime = new System.Windows.Forms.Panel();
            this.rdBttn_s_forExpTime = new System.Windows.Forms.RadioButton();
            this.rdBttn_ms_forExpTime = new System.Windows.Forms.RadioButton();
            this.nmrcUpDwn_Exposure_Time = new System.Windows.Forms.NumericUpDown();
            this.lbl_Exposure_Time_Txt = new System.Windows.Forms.Label();
            this.Temperature_timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBackGroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSubstructImageCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCDCameraSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ROISettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerModeSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticalShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialFiberAquisitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identificatePolymorphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Window_Field = new System.Windows.Forms.Panel();
            this.Temperature_timer_for_not_Cooling = new System.Windows.Forms.Timer(this.components);
            this.AutomaticalShutdown_timer = new System.Windows.Forms.Timer(this.components);
            this.grpBx_Setting_temp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Setting_Temperature)).BeginInit();
            this.grpBx_Acquire_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Number_of_Frame)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnl_unit_forExpTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Exposure_Time)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBx_Setting_temp
            // 
            this.grpBx_Setting_temp.BackColor = System.Drawing.SystemColors.Control;
            this.grpBx_Setting_temp.Controls.Add(this.bttn_Setting_CCD_Temperature);
            this.grpBx_Setting_temp.Controls.Add(this.nmrcUpDwn_Setting_Temperature);
            this.grpBx_Setting_temp.Controls.Add(this.lbl_Setting_CCD_Temperature);
            this.grpBx_Setting_temp.Controls.Add(this.chckBx_Enable_Active_Cooling);
            this.grpBx_Setting_temp.Controls.Add(this.lbl_CCD_Temp);
            this.grpBx_Setting_temp.Controls.Add(this.lbl_PCB_Temp);
            this.grpBx_Setting_temp.Controls.Add(this.lbl_CCD_Temp_Text);
            this.grpBx_Setting_temp.Controls.Add(this.lbl_PCB_Temp_Text);
            this.grpBx_Setting_temp.Location = new System.Drawing.Point(2, 2);
            this.grpBx_Setting_temp.Margin = new System.Windows.Forms.Padding(2);
            this.grpBx_Setting_temp.Name = "grpBx_Setting_temp";
            this.grpBx_Setting_temp.Padding = new System.Windows.Forms.Padding(2);
            this.grpBx_Setting_temp.Size = new System.Drawing.Size(339, 205);
            this.grpBx_Setting_temp.TabIndex = 0;
            this.grpBx_Setting_temp.TabStop = false;
            this.grpBx_Setting_temp.Text = "Setting Temperature";
            // 
            // bttn_Setting_CCD_Temperature
            // 
            this.bttn_Setting_CCD_Temperature.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bttn_Setting_CCD_Temperature.Location = new System.Drawing.Point(118, 168);
            this.bttn_Setting_CCD_Temperature.Margin = new System.Windows.Forms.Padding(2);
            this.bttn_Setting_CCD_Temperature.Name = "bttn_Setting_CCD_Temperature";
            this.bttn_Setting_CCD_Temperature.Size = new System.Drawing.Size(90, 23);
            this.bttn_Setting_CCD_Temperature.TabIndex = 0;
            this.bttn_Setting_CCD_Temperature.Text = "Set";
            this.bttn_Setting_CCD_Temperature.UseVisualStyleBackColor = true;
            this.bttn_Setting_CCD_Temperature.Click += new System.EventHandler(this.bttn_Setting_CCD_Temperature_Click);
            // 
            // nmrcUpDwn_Setting_Temperature
            // 
            this.nmrcUpDwn_Setting_Temperature.Enabled = false;
            this.nmrcUpDwn_Setting_Temperature.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nmrcUpDwn_Setting_Temperature.Location = new System.Drawing.Point(5, 168);
            this.nmrcUpDwn_Setting_Temperature.Margin = new System.Windows.Forms.Padding(2);
            this.nmrcUpDwn_Setting_Temperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmrcUpDwn_Setting_Temperature.Name = "nmrcUpDwn_Setting_Temperature";
            this.nmrcUpDwn_Setting_Temperature.Size = new System.Drawing.Size(107, 24);
            this.nmrcUpDwn_Setting_Temperature.TabIndex = 0;
            this.nmrcUpDwn_Setting_Temperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrcUpDwn_Setting_Temperature.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            // 
            // lbl_Setting_CCD_Temperature
            // 
            this.lbl_Setting_CCD_Temperature.AutoSize = true;
            this.lbl_Setting_CCD_Temperature.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Setting_CCD_Temperature.Location = new System.Drawing.Point(6, 137);
            this.lbl_Setting_CCD_Temperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Setting_CCD_Temperature.Name = "lbl_Setting_CCD_Temperature";
            this.lbl_Setting_CCD_Temperature.Size = new System.Drawing.Size(195, 17);
            this.lbl_Setting_CCD_Temperature.TabIndex = 0;
            this.lbl_Setting_CCD_Temperature.Text = "Setting CCD Temperature";
            // 
            // chckBx_Enable_Active_Cooling
            // 
            this.chckBx_Enable_Active_Cooling.AutoSize = true;
            this.chckBx_Enable_Active_Cooling.Checked = true;
            this.chckBx_Enable_Active_Cooling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckBx_Enable_Active_Cooling.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chckBx_Enable_Active_Cooling.Location = new System.Drawing.Point(5, 95);
            this.chckBx_Enable_Active_Cooling.Margin = new System.Windows.Forms.Padding(2);
            this.chckBx_Enable_Active_Cooling.Name = "chckBx_Enable_Active_Cooling";
            this.chckBx_Enable_Active_Cooling.Size = new System.Drawing.Size(189, 21);
            this.chckBx_Enable_Active_Cooling.TabIndex = 0;
            this.chckBx_Enable_Active_Cooling.Text = "Enable Active Cooling";
            this.chckBx_Enable_Active_Cooling.UseVisualStyleBackColor = true;
            this.chckBx_Enable_Active_Cooling.CheckedChanged += new System.EventHandler(this.chckBx_Enable_Active_Cooling_CheckedChanged);
            // 
            // lbl_CCD_Temp
            // 
            this.lbl_CCD_Temp.AutoSize = true;
            this.lbl_CCD_Temp.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_CCD_Temp.Location = new System.Drawing.Point(162, 56);
            this.lbl_CCD_Temp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CCD_Temp.Name = "lbl_CCD_Temp";
            this.lbl_CCD_Temp.Size = new System.Drawing.Size(40, 17);
            this.lbl_CCD_Temp.TabIndex = 3;
            this.lbl_CCD_Temp.Text = "????";
            // 
            // lbl_PCB_Temp
            // 
            this.lbl_PCB_Temp.AutoSize = true;
            this.lbl_PCB_Temp.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_PCB_Temp.Location = new System.Drawing.Point(162, 25);
            this.lbl_PCB_Temp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_PCB_Temp.Name = "lbl_PCB_Temp";
            this.lbl_PCB_Temp.Size = new System.Drawing.Size(40, 17);
            this.lbl_PCB_Temp.TabIndex = 2;
            this.lbl_PCB_Temp.Text = "????";
            // 
            // lbl_CCD_Temp_Text
            // 
            this.lbl_CCD_Temp_Text.AutoSize = true;
            this.lbl_CCD_Temp_Text.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_CCD_Temp_Text.Location = new System.Drawing.Point(5, 56);
            this.lbl_CCD_Temp_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CCD_Temp_Text.Name = "lbl_CCD_Temp_Text";
            this.lbl_CCD_Temp_Text.Size = new System.Drawing.Size(138, 17);
            this.lbl_CCD_Temp_Text.TabIndex = 1;
            this.lbl_CCD_Temp_Text.Text = "CCD Temperature";
            // 
            // lbl_PCB_Temp_Text
            // 
            this.lbl_PCB_Temp_Text.AutoSize = true;
            this.lbl_PCB_Temp_Text.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_PCB_Temp_Text.Location = new System.Drawing.Point(5, 25);
            this.lbl_PCB_Temp_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_PCB_Temp_Text.Name = "lbl_PCB_Temp_Text";
            this.lbl_PCB_Temp_Text.Size = new System.Drawing.Size(137, 17);
            this.lbl_PCB_Temp_Text.TabIndex = 0;
            this.lbl_PCB_Temp_Text.Text = "PCB Temperature";
            // 
            // grpBx_Acquire_Data
            // 
            this.grpBx_Acquire_Data.BackColor = System.Drawing.SystemColors.Control;
            this.grpBx_Acquire_Data.Controls.Add(this.chckBx_Write_CSV);
            this.grpBx_Acquire_Data.Controls.Add(this.lbl_set_FrameRate);
            this.grpBx_Acquire_Data.Controls.Add(this.lbl_Set_ExposureTime);
            this.grpBx_Acquire_Data.Controls.Add(this.chckBx_set_as_BackGround);
            this.grpBx_Acquire_Data.Controls.Add(this.bttn_Stop);
            this.grpBx_Acquire_Data.Controls.Add(this.bttn_Acquire_Frame);
            this.grpBx_Acquire_Data.Controls.Add(this.chckBx_continuous);
            this.grpBx_Acquire_Data.Controls.Add(this.nmrcUpDwn_Number_of_Frame);
            this.grpBx_Acquire_Data.Controls.Add(this.lbl_Number_of_Frames_txt);
            this.grpBx_Acquire_Data.Controls.Add(this.panel3);
            this.grpBx_Acquire_Data.Controls.Add(this.pnl_unit_forExpTime);
            this.grpBx_Acquire_Data.Controls.Add(this.nmrcUpDwn_Exposure_Time);
            this.grpBx_Acquire_Data.Controls.Add(this.lbl_Exposure_Time_Txt);
            this.grpBx_Acquire_Data.Location = new System.Drawing.Point(2, 208);
            this.grpBx_Acquire_Data.Margin = new System.Windows.Forms.Padding(2);
            this.grpBx_Acquire_Data.Name = "grpBx_Acquire_Data";
            this.grpBx_Acquire_Data.Padding = new System.Windows.Forms.Padding(2);
            this.grpBx_Acquire_Data.Size = new System.Drawing.Size(339, 480);
            this.grpBx_Acquire_Data.TabIndex = 1;
            this.grpBx_Acquire_Data.TabStop = false;
            this.grpBx_Acquire_Data.Text = "Acquire Data";
            // 
            // chckBx_Write_CSV
            // 
            this.chckBx_Write_CSV.AutoSize = true;
            this.chckBx_Write_CSV.Location = new System.Drawing.Point(13, 277);
            this.chckBx_Write_CSV.Margin = new System.Windows.Forms.Padding(2);
            this.chckBx_Write_CSV.Name = "chckBx_Write_CSV";
            this.chckBx_Write_CSV.Size = new System.Drawing.Size(94, 19);
            this.chckBx_Write_CSV.TabIndex = 16;
            this.chckBx_Write_CSV.Text = "Write CSV";
            this.chckBx_Write_CSV.UseVisualStyleBackColor = true;
            // 
            // lbl_set_FrameRate
            // 
            this.lbl_set_FrameRate.AutoSize = true;
            this.lbl_set_FrameRate.Location = new System.Drawing.Point(10, 64);
            this.lbl_set_FrameRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_set_FrameRate.Name = "lbl_set_FrameRate";
            this.lbl_set_FrameRate.Size = new System.Drawing.Size(0, 15);
            this.lbl_set_FrameRate.TabIndex = 15;
            // 
            // lbl_Set_ExposureTime
            // 
            this.lbl_Set_ExposureTime.AutoSize = true;
            this.lbl_Set_ExposureTime.Location = new System.Drawing.Point(10, 64);
            this.lbl_Set_ExposureTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Set_ExposureTime.Name = "lbl_Set_ExposureTime";
            this.lbl_Set_ExposureTime.Size = new System.Drawing.Size(0, 15);
            this.lbl_Set_ExposureTime.TabIndex = 13;
            // 
            // chckBx_set_as_BackGround
            // 
            this.chckBx_set_as_BackGround.AutoSize = true;
            this.chckBx_set_as_BackGround.Enabled = false;
            this.chckBx_set_as_BackGround.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chckBx_set_as_BackGround.Location = new System.Drawing.Point(13, 223);
            this.chckBx_set_as_BackGround.Margin = new System.Windows.Forms.Padding(2);
            this.chckBx_set_as_BackGround.Name = "chckBx_set_as_BackGround";
            this.chckBx_set_as_BackGround.Size = new System.Drawing.Size(165, 38);
            this.chckBx_set_as_BackGround.TabIndex = 8;
            this.chckBx_set_as_BackGround.Text = "Acquire Frame as \nBackGround Image";
            this.chckBx_set_as_BackGround.UseVisualStyleBackColor = true;
            this.chckBx_set_as_BackGround.CheckedChanged += new System.EventHandler(this.chckBx_set_as_BackGround_CheckedChanged);
            // 
            // bttn_Stop
            // 
            this.bttn_Stop.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bttn_Stop.Location = new System.Drawing.Point(5, 428);
            this.bttn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.bttn_Stop.Name = "bttn_Stop";
            this.bttn_Stop.Size = new System.Drawing.Size(90, 41);
            this.bttn_Stop.TabIndex = 7;
            this.bttn_Stop.Text = "Stop";
            this.bttn_Stop.UseVisualStyleBackColor = true;
            this.bttn_Stop.Click += new System.EventHandler(this.bttn_Stop_Click);
            // 
            // bttn_Acquire_Frame
            // 
            this.bttn_Acquire_Frame.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bttn_Acquire_Frame.Location = new System.Drawing.Point(193, 377);
            this.bttn_Acquire_Frame.Margin = new System.Windows.Forms.Padding(2);
            this.bttn_Acquire_Frame.Name = "bttn_Acquire_Frame";
            this.bttn_Acquire_Frame.Size = new System.Drawing.Size(142, 92);
            this.bttn_Acquire_Frame.TabIndex = 0;
            this.bttn_Acquire_Frame.Text = "Acquire Frame";
            this.bttn_Acquire_Frame.UseVisualStyleBackColor = true;
            this.bttn_Acquire_Frame.Click += new System.EventHandler(this.btton_Acuire_Frame_Click);
            // 
            // chckBx_continuous
            // 
            this.chckBx_continuous.AutoSize = true;
            this.chckBx_continuous.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chckBx_continuous.Location = new System.Drawing.Point(13, 186);
            this.chckBx_continuous.Margin = new System.Windows.Forms.Padding(2);
            this.chckBx_continuous.Name = "chckBx_continuous";
            this.chckBx_continuous.Size = new System.Drawing.Size(113, 21);
            this.chckBx_continuous.TabIndex = 4;
            this.chckBx_continuous.Text = "Continuous";
            this.chckBx_continuous.UseVisualStyleBackColor = true;
            this.chckBx_continuous.CheckedChanged += new System.EventHandler(this.chckBx_continuous_CheckedChanged);
            // 
            // nmrcUpDwn_Number_of_Frame
            // 
            this.nmrcUpDwn_Number_of_Frame.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nmrcUpDwn_Number_of_Frame.Location = new System.Drawing.Point(153, 146);
            this.nmrcUpDwn_Number_of_Frame.Margin = new System.Windows.Forms.Padding(2);
            this.nmrcUpDwn_Number_of_Frame.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrcUpDwn_Number_of_Frame.Name = "nmrcUpDwn_Number_of_Frame";
            this.nmrcUpDwn_Number_of_Frame.Size = new System.Drawing.Size(87, 24);
            this.nmrcUpDwn_Number_of_Frame.TabIndex = 6;
            this.nmrcUpDwn_Number_of_Frame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrcUpDwn_Number_of_Frame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Number_of_Frames_txt
            // 
            this.lbl_Number_of_Frames_txt.AutoSize = true;
            this.lbl_Number_of_Frames_txt.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Number_of_Frames_txt.Location = new System.Drawing.Point(10, 147);
            this.lbl_Number_of_Frames_txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Number_of_Frames_txt.Name = "lbl_Number_of_Frames_txt";
            this.lbl_Number_of_Frames_txt.Size = new System.Drawing.Size(131, 17);
            this.lbl_Number_of_Frames_txt.TabIndex = 5;
            this.lbl_Number_of_Frames_txt.Text = "Number of Frame";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdBttn_Image);
            this.panel3.Controls.Add(this.rdBttn_FVB);
            this.panel3.Controls.Add(this.lbl_Binning);
            this.panel3.Location = new System.Drawing.Point(13, 89);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 32);
            this.panel3.TabIndex = 2;
            // 
            // rdBttn_Image
            // 
            this.rdBttn_Image.AutoSize = true;
            this.rdBttn_Image.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdBttn_Image.Location = new System.Drawing.Point(151, 6);
            this.rdBttn_Image.Margin = new System.Windows.Forms.Padding(2);
            this.rdBttn_Image.Name = "rdBttn_Image";
            this.rdBttn_Image.Size = new System.Drawing.Size(70, 21);
            this.rdBttn_Image.TabIndex = 1;
            this.rdBttn_Image.Text = "Image";
            this.rdBttn_Image.UseVisualStyleBackColor = true;
            this.rdBttn_Image.CheckedChanged += new System.EventHandler(this.rdBttn_Image_CheckedChanged);
            // 
            // rdBttn_FVB
            // 
            this.rdBttn_FVB.AutoSize = true;
            this.rdBttn_FVB.Checked = true;
            this.rdBttn_FVB.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdBttn_FVB.Location = new System.Drawing.Point(78, 6);
            this.rdBttn_FVB.Margin = new System.Windows.Forms.Padding(2);
            this.rdBttn_FVB.Name = "rdBttn_FVB";
            this.rdBttn_FVB.Size = new System.Drawing.Size(60, 21);
            this.rdBttn_FVB.TabIndex = 0;
            this.rdBttn_FVB.TabStop = true;
            this.rdBttn_FVB.Text = "FVB";
            this.rdBttn_FVB.UseVisualStyleBackColor = true;
            // 
            // lbl_Binning
            // 
            this.lbl_Binning.AutoSize = true;
            this.lbl_Binning.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Binning.Location = new System.Drawing.Point(2, 9);
            this.lbl_Binning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Binning.Name = "lbl_Binning";
            this.lbl_Binning.Size = new System.Drawing.Size(62, 17);
            this.lbl_Binning.TabIndex = 0;
            this.lbl_Binning.Text = "Binning";
            // 
            // pnl_unit_forExpTime
            // 
            this.pnl_unit_forExpTime.AutoSize = true;
            this.pnl_unit_forExpTime.Controls.Add(this.rdBttn_s_forExpTime);
            this.pnl_unit_forExpTime.Controls.Add(this.rdBttn_ms_forExpTime);
            this.pnl_unit_forExpTime.Location = new System.Drawing.Point(234, 21);
            this.pnl_unit_forExpTime.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_unit_forExpTime.Name = "pnl_unit_forExpTime";
            this.pnl_unit_forExpTime.Size = new System.Drawing.Size(48, 49);
            this.pnl_unit_forExpTime.TabIndex = 0;
            // 
            // rdBttn_s_forExpTime
            // 
            this.rdBttn_s_forExpTime.AutoSize = true;
            this.rdBttn_s_forExpTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdBttn_s_forExpTime.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdBttn_s_forExpTime.Location = new System.Drawing.Point(12, 29);
            this.rdBttn_s_forExpTime.Margin = new System.Windows.Forms.Padding(2);
            this.rdBttn_s_forExpTime.Name = "rdBttn_s_forExpTime";
            this.rdBttn_s_forExpTime.Size = new System.Drawing.Size(34, 18);
            this.rdBttn_s_forExpTime.TabIndex = 1;
            this.rdBttn_s_forExpTime.TabStop = true;
            this.rdBttn_s_forExpTime.Text = "s";
            this.rdBttn_s_forExpTime.UseVisualStyleBackColor = true;
            // 
            // rdBttn_ms_forExpTime
            // 
            this.rdBttn_ms_forExpTime.AutoSize = true;
            this.rdBttn_ms_forExpTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdBttn_ms_forExpTime.Checked = true;
            this.rdBttn_ms_forExpTime.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdBttn_ms_forExpTime.Location = new System.Drawing.Point(2, 2);
            this.rdBttn_ms_forExpTime.Margin = new System.Windows.Forms.Padding(2);
            this.rdBttn_ms_forExpTime.Name = "rdBttn_ms_forExpTime";
            this.rdBttn_ms_forExpTime.Size = new System.Drawing.Size(44, 18);
            this.rdBttn_ms_forExpTime.TabIndex = 0;
            this.rdBttn_ms_forExpTime.TabStop = true;
            this.rdBttn_ms_forExpTime.Text = "ms";
            this.rdBttn_ms_forExpTime.UseVisualStyleBackColor = true;
            // 
            // nmrcUpDwn_Exposure_Time
            // 
            this.nmrcUpDwn_Exposure_Time.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nmrcUpDwn_Exposure_Time.Location = new System.Drawing.Point(142, 34);
            this.nmrcUpDwn_Exposure_Time.Margin = new System.Windows.Forms.Padding(2);
            this.nmrcUpDwn_Exposure_Time.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrcUpDwn_Exposure_Time.Name = "nmrcUpDwn_Exposure_Time";
            this.nmrcUpDwn_Exposure_Time.Size = new System.Drawing.Size(87, 24);
            this.nmrcUpDwn_Exposure_Time.TabIndex = 4;
            this.nmrcUpDwn_Exposure_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrcUpDwn_Exposure_Time.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Exposure_Time_Txt
            // 
            this.lbl_Exposure_Time_Txt.AutoSize = true;
            this.lbl_Exposure_Time_Txt.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Exposure_Time_Txt.Location = new System.Drawing.Point(8, 36);
            this.lbl_Exposure_Time_Txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Exposure_Time_Txt.Name = "lbl_Exposure_Time_Txt";
            this.lbl_Exposure_Time_Txt.Size = new System.Drawing.Size(115, 17);
            this.lbl_Exposure_Time_Txt.TabIndex = 2;
            this.lbl_Exposure_Time_Txt.Text = "Exposure Time";
            // 
            // Temperature_timer
            // 
            this.Temperature_timer.Tick += new System.EventHandler(this.Temperature_timer_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cCDCameraSettingToolStripMenuItem,
            this.analizeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1126, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCsvToolStripMenuItem,
            this.importBackGroundImageToolStripMenuItem,
            this.importSubstructImageCSVToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importCsvToolStripMenuItem
            // 
            this.importCsvToolStripMenuItem.Name = "importCsvToolStripMenuItem";
            this.importCsvToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.importCsvToolStripMenuItem.Text = "import Image(CSV)";
            this.importCsvToolStripMenuItem.Click += new System.EventHandler(this.importCsvToolStripMenuItem_Click);
            // 
            // importBackGroundImageToolStripMenuItem
            // 
            this.importBackGroundImageToolStripMenuItem.Name = "importBackGroundImageToolStripMenuItem";
            this.importBackGroundImageToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.importBackGroundImageToolStripMenuItem.Text = "import BackGround Image(CSV)";
            this.importBackGroundImageToolStripMenuItem.Click += new System.EventHandler(this.importBackGroundImageToolStripMenuItem_Click);
            // 
            // importSubstructImageCSVToolStripMenuItem
            // 
            this.importSubstructImageCSVToolStripMenuItem.Name = "importSubstructImageCSVToolStripMenuItem";
            this.importSubstructImageCSVToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.importSubstructImageCSVToolStripMenuItem.Text = "import Substruct Image(CSV)";
            this.importSubstructImageCSVToolStripMenuItem.Click += new System.EventHandler(this.importSubstructImageCSVToolStripMenuItem_Click);
            // 
            // cCDCameraSettingToolStripMenuItem
            // 
            this.cCDCameraSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ROISettingToolStripMenuItem,
            this.triggerModeSettingToolStripMenuItem,
            this.automaticalShutDownToolStripMenuItem});
            this.cCDCameraSettingToolStripMenuItem.Name = "cCDCameraSettingToolStripMenuItem";
            this.cCDCameraSettingToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.cCDCameraSettingToolStripMenuItem.Text = "CCD Camera Setting";
            // 
            // ROISettingToolStripMenuItem
            // 
            this.ROISettingToolStripMenuItem.Enabled = false;
            this.ROISettingToolStripMenuItem.Name = "ROISettingToolStripMenuItem";
            this.ROISettingToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.ROISettingToolStripMenuItem.Text = "ROI Setting";
            this.ROISettingToolStripMenuItem.Click += new System.EventHandler(this.ROISettingToolStripMenuItem_Click);
            // 
            // triggerModeSettingToolStripMenuItem
            // 
            this.triggerModeSettingToolStripMenuItem.Name = "triggerModeSettingToolStripMenuItem";
            this.triggerModeSettingToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.triggerModeSettingToolStripMenuItem.Text = "Trigger Mode Setting";
            this.triggerModeSettingToolStripMenuItem.Click += new System.EventHandler(this.triggerModeSettingToolStripMenuItem_Click);
            // 
            // automaticalShutDownToolStripMenuItem
            // 
            this.automaticalShutDownToolStripMenuItem.Name = "automaticalShutDownToolStripMenuItem";
            this.automaticalShutDownToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.automaticalShutDownToolStripMenuItem.Text = "Automatical ShutDown";
            this.automaticalShutDownToolStripMenuItem.Click += new System.EventHandler(this.automaticalShutDownToolStripMenuItem_Click);
            // 
            // analizeToolStripMenuItem
            // 
            this.analizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialFiberAquisitionToolStripMenuItem,
            this.identificatePolymorphToolStripMenuItem});
            this.analizeToolStripMenuItem.Name = "analizeToolStripMenuItem";
            this.analizeToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.analizeToolStripMenuItem.Text = "Analysis";
            // 
            // serialFiberAquisitionToolStripMenuItem
            // 
            this.serialFiberAquisitionToolStripMenuItem.Enabled = false;
            this.serialFiberAquisitionToolStripMenuItem.Name = "serialFiberAquisitionToolStripMenuItem";
            this.serialFiberAquisitionToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.serialFiberAquisitionToolStripMenuItem.Text = "Serial Fiber Aquisition";
            this.serialFiberAquisitionToolStripMenuItem.Click += new System.EventHandler(this.serialFiberAquisitionToolStripMenuItem_Click);
            // 
            // identificatePolymorphToolStripMenuItem
            // 
            this.identificatePolymorphToolStripMenuItem.Enabled = false;
            this.identificatePolymorphToolStripMenuItem.Name = "identificatePolymorphToolStripMenuItem";
            this.identificatePolymorphToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.identificatePolymorphToolStripMenuItem.Text = "identificate polymorph";
            this.identificatePolymorphToolStripMenuItem.Click += new System.EventHandler(this.identificatePolymorphToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.grpBx_Setting_temp);
            this.panel1.Controls.Add(this.grpBx_Acquire_Data);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 686);
            this.panel1.TabIndex = 3;
            // 
            // pnl_Window_Field
            // 
            this.pnl_Window_Field.Location = new System.Drawing.Point(359, 28);
            this.pnl_Window_Field.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Window_Field.Name = "pnl_Window_Field";
            this.pnl_Window_Field.Size = new System.Drawing.Size(766, 686);
            this.pnl_Window_Field.TabIndex = 4;
            // 
            // Temperature_timer_for_not_Cooling
            // 
            this.Temperature_timer_for_not_Cooling.Interval = 1000;
            this.Temperature_timer_for_not_Cooling.Tick += new System.EventHandler(this.Temperature_timer_for_not_Cooling_Tick);
            // 
            // AutomaticalShutdown_timer
            // 
            this.AutomaticalShutdown_timer.Interval = 1000;
            this.AutomaticalShutdown_timer.Tick += new System.EventHandler(this.AutomaticalShutdown_timer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1126, 714);
            this.Controls.Add(this.pnl_Window_Field);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainForm";
            this.Text = "CCD_Controller";
            this.grpBx_Setting_temp.ResumeLayout(false);
            this.grpBx_Setting_temp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Setting_Temperature)).EndInit();
            this.grpBx_Acquire_Data.ResumeLayout(false);
            this.grpBx_Acquire_Data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Number_of_Frame)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnl_unit_forExpTime.ResumeLayout(false);
            this.pnl_unit_forExpTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_Exposure_Time)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBx_Setting_temp;
        private System.Windows.Forms.GroupBox grpBx_Acquire_Data;
        private System.Windows.Forms.Label lbl_CCD_Temp_Text;
        private System.Windows.Forms.Label lbl_PCB_Temp_Text;
        private System.Windows.Forms.Label lbl_PCB_Temp;
        private System.Windows.Forms.CheckBox chckBx_Enable_Active_Cooling;
        private System.Windows.Forms.Label lbl_CCD_Temp;
        private System.Windows.Forms.Timer Temperature_timer;
        private System.Windows.Forms.Label lbl_Setting_CCD_Temperature;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_Setting_Temperature;
        private System.Windows.Forms.Button bttn_Setting_CCD_Temperature;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_Exposure_Time;
        private System.Windows.Forms.Label lbl_Exposure_Time_Txt;
        private System.Windows.Forms.Panel pnl_unit_forExpTime;
        private System.Windows.Forms.RadioButton rdBttn_s_forExpTime;
        private System.Windows.Forms.RadioButton rdBttn_ms_forExpTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdBttn_Image;
        private System.Windows.Forms.RadioButton rdBttn_FVB;
        private System.Windows.Forms.Label lbl_Binning;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_Number_of_Frame;
        private System.Windows.Forms.Label lbl_Number_of_Frames_txt;
        private System.Windows.Forms.Button bttn_Stop;
        private System.Windows.Forms.Button bttn_Acquire_Frame;
        private System.Windows.Forms.CheckBox chckBx_continuous;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialFiberAquisitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCsvToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Window_Field;
        private System.Windows.Forms.CheckBox chckBx_set_as_BackGround;
        private System.Windows.Forms.ToolStripMenuItem importBackGroundImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCDCameraSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ROISettingToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Set_ExposureTime;
        private System.Windows.Forms.Label lbl_set_FrameRate;
        private System.Windows.Forms.CheckBox chckBx_Write_CSV;
        private System.Windows.Forms.ToolStripMenuItem triggerModeSettingToolStripMenuItem;
        private System.Windows.Forms.Timer Temperature_timer_for_not_Cooling;
        private System.Windows.Forms.ToolStripMenuItem automaticalShutDownToolStripMenuItem;
        private System.Windows.Forms.Timer AutomaticalShutdown_timer;
        private System.Windows.Forms.ToolStripMenuItem identificatePolymorphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSubstructImageCSVToolStripMenuItem;
    }
}

