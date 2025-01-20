namespace CCD_controller_windows_form
{
    partial class StepPanel
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
            this.pnl_StepName = new System.Windows.Forms.Panel();
            this.pnl_StepSetting = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_StepName
            // 
            this.pnl_StepName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_StepName.Location = new System.Drawing.Point(0, 0);
            this.pnl_StepName.Name = "pnl_StepName";
            this.pnl_StepName.Size = new System.Drawing.Size(248, 76);
            this.pnl_StepName.TabIndex = 0;
            this.pnl_StepName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StepPanel_MouseDown);
            this.pnl_StepName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StepPanel_MouseMove);
            // 
            // pnl_StepSetting
            // 
            this.pnl_StepSetting.Location = new System.Drawing.Point(0, 72);
            this.pnl_StepSetting.Name = "pnl_StepSetting";
            this.pnl_StepSetting.Size = new System.Drawing.Size(248, 125);
            this.pnl_StepSetting.TabIndex = 0;
            this.pnl_StepSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StepPanel_MouseDown);
            this.pnl_StepSetting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StepPanel_MouseMove);
            // 
            // StepPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 198);
            this.Controls.Add(this.pnl_StepSetting);
            this.Controls.Add(this.pnl_StepName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StepPanel";
            this.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.Text = "StepPanel";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StepPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StepPanel_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_StepName;
        private System.Windows.Forms.Panel pnl_StepSetting;
    }
}