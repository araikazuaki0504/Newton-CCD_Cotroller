namespace CCD_controller_windows_form
{
    partial class TriggerModeSettingForm
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
            this.bttn_Confirm = new System.Windows.Forms.Button();
            this.grpBx_Trigger_Mode = new System.Windows.Forms.GroupBox();
            this.rdbttn_External_Charge_Shift_Mode = new System.Windows.Forms.RadioButton();
            this.rdbttn_Software_Trigger_Mode = new System.Windows.Forms.RadioButton();
            this.rdbttn_internal_Mode = new System.Windows.Forms.RadioButton();
            this.rdbttn_External_Exposure_Mode = new System.Windows.Forms.RadioButton();
            this.rdbttn_External_Mode = new System.Windows.Forms.RadioButton();
            this.rdbttn_External_Start_Mode = new System.Windows.Forms.RadioButton();
            this.grpBx_Trigger_Mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttn_Confirm
            // 
            this.bttn_Confirm.Location = new System.Drawing.Point(201, 324);
            this.bttn_Confirm.Name = "bttn_Confirm";
            this.bttn_Confirm.Size = new System.Drawing.Size(118, 41);
            this.bttn_Confirm.TabIndex = 6;
            this.bttn_Confirm.Text = "Confirm";
            this.bttn_Confirm.UseVisualStyleBackColor = true;
            this.bttn_Confirm.Click += new System.EventHandler(this.bttn_Confirm_Click);
            // 
            // grpBx_Trigger_Mode
            // 
            this.grpBx_Trigger_Mode.Controls.Add(this.rdbttn_External_Charge_Shift_Mode);
            this.grpBx_Trigger_Mode.Controls.Add(this.rdbttn_Software_Trigger_Mode);
            this.grpBx_Trigger_Mode.Controls.Add(this.rdbttn_internal_Mode);
            this.grpBx_Trigger_Mode.Controls.Add(this.rdbttn_External_Exposure_Mode);
            this.grpBx_Trigger_Mode.Controls.Add(this.rdbttn_External_Mode);
            this.grpBx_Trigger_Mode.Controls.Add(this.rdbttn_External_Start_Mode);
            this.grpBx_Trigger_Mode.Location = new System.Drawing.Point(12, 12);
            this.grpBx_Trigger_Mode.Name = "grpBx_Trigger_Mode";
            this.grpBx_Trigger_Mode.Size = new System.Drawing.Size(307, 306);
            this.grpBx_Trigger_Mode.TabIndex = 6;
            this.grpBx_Trigger_Mode.TabStop = false;
            this.grpBx_Trigger_Mode.Text = "Trigger Mode";
            // 
            // rdbttn_External_Charge_Shift_Mode
            // 
            this.rdbttn_External_Charge_Shift_Mode.AutoSize = true;
            this.rdbttn_External_Charge_Shift_Mode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdbttn_External_Charge_Shift_Mode.Location = new System.Drawing.Point(6, 270);
            this.rdbttn_External_Charge_Shift_Mode.Name = "rdbttn_External_Charge_Shift_Mode";
            this.rdbttn_External_Charge_Shift_Mode.Size = new System.Drawing.Size(259, 24);
            this.rdbttn_External_Charge_Shift_Mode.TabIndex = 5;
            this.rdbttn_External_Charge_Shift_Mode.Text = "External Charge Shift Mode";
            this.rdbttn_External_Charge_Shift_Mode.UseVisualStyleBackColor = true;
            // 
            // rdbttn_Software_Trigger_Mode
            // 
            this.rdbttn_Software_Trigger_Mode.AutoSize = true;
            this.rdbttn_Software_Trigger_Mode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdbttn_Software_Trigger_Mode.Location = new System.Drawing.Point(6, 221);
            this.rdbttn_Software_Trigger_Mode.Name = "rdbttn_Software_Trigger_Mode";
            this.rdbttn_Software_Trigger_Mode.Size = new System.Drawing.Size(220, 24);
            this.rdbttn_Software_Trigger_Mode.TabIndex = 4;
            this.rdbttn_Software_Trigger_Mode.Text = "Software Trigger Mode";
            this.rdbttn_Software_Trigger_Mode.UseVisualStyleBackColor = true;
            // 
            // rdbttn_internal_Mode
            // 
            this.rdbttn_internal_Mode.AutoSize = true;
            this.rdbttn_internal_Mode.Checked = true;
            this.rdbttn_internal_Mode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdbttn_internal_Mode.Location = new System.Drawing.Point(6, 25);
            this.rdbttn_internal_Mode.Name = "rdbttn_internal_Mode";
            this.rdbttn_internal_Mode.Size = new System.Drawing.Size(144, 24);
            this.rdbttn_internal_Mode.TabIndex = 0;
            this.rdbttn_internal_Mode.TabStop = true;
            this.rdbttn_internal_Mode.Text = "Internal Mode";
            this.rdbttn_internal_Mode.UseVisualStyleBackColor = true;
            // 
            // rdbttn_External_Exposure_Mode
            // 
            this.rdbttn_External_Exposure_Mode.AutoSize = true;
            this.rdbttn_External_Exposure_Mode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdbttn_External_Exposure_Mode.Location = new System.Drawing.Point(6, 172);
            this.rdbttn_External_Exposure_Mode.Name = "rdbttn_External_Exposure_Mode";
            this.rdbttn_External_Exposure_Mode.Size = new System.Drawing.Size(231, 24);
            this.rdbttn_External_Exposure_Mode.TabIndex = 3;
            this.rdbttn_External_Exposure_Mode.Text = "External Exposure Mode";
            this.rdbttn_External_Exposure_Mode.UseVisualStyleBackColor = true;
            // 
            // rdbttn_External_Mode
            // 
            this.rdbttn_External_Mode.AutoSize = true;
            this.rdbttn_External_Mode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdbttn_External_Mode.Location = new System.Drawing.Point(6, 74);
            this.rdbttn_External_Mode.Name = "rdbttn_External_Mode";
            this.rdbttn_External_Mode.Size = new System.Drawing.Size(149, 24);
            this.rdbttn_External_Mode.TabIndex = 1;
            this.rdbttn_External_Mode.Text = "External Mode";
            this.rdbttn_External_Mode.UseVisualStyleBackColor = true;
            // 
            // rdbttn_External_Start_Mode
            // 
            this.rdbttn_External_Start_Mode.AutoSize = true;
            this.rdbttn_External_Start_Mode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdbttn_External_Start_Mode.Location = new System.Drawing.Point(6, 123);
            this.rdbttn_External_Start_Mode.Name = "rdbttn_External_Start_Mode";
            this.rdbttn_External_Start_Mode.Size = new System.Drawing.Size(198, 24);
            this.rdbttn_External_Start_Mode.TabIndex = 2;
            this.rdbttn_External_Start_Mode.Text = "External Start Mode";
            this.rdbttn_External_Start_Mode.UseVisualStyleBackColor = true;
            // 
            // TriggerModeSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 374);
            this.Controls.Add(this.grpBx_Trigger_Mode);
            this.Controls.Add(this.bttn_Confirm);
            this.Name = "TriggerModeSettingForm";
            this.Text = "TriggerModeSettingForm";
            this.grpBx_Trigger_Mode.ResumeLayout(false);
            this.grpBx_Trigger_Mode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bttn_Confirm;
        private System.Windows.Forms.GroupBox grpBx_Trigger_Mode;
        private System.Windows.Forms.RadioButton rdbttn_External_Charge_Shift_Mode;
        private System.Windows.Forms.RadioButton rdbttn_Software_Trigger_Mode;
        private System.Windows.Forms.RadioButton rdbttn_internal_Mode;
        private System.Windows.Forms.RadioButton rdbttn_External_Exposure_Mode;
        private System.Windows.Forms.RadioButton rdbttn_External_Mode;
        private System.Windows.Forms.RadioButton rdbttn_External_Start_Mode;
    }
}