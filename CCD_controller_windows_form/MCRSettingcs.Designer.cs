namespace CCD_controller_windows_form
{
    partial class MCRSettingcs
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
            this.lbl_component_txt = new System.Windows.Forms.Label();
            this.nmrcUpDwn_component = new System.Windows.Forms.NumericUpDown();
            this.bttn_calculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_component)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_component_txt
            // 
            this.lbl_component_txt.AutoSize = true;
            this.lbl_component_txt.Location = new System.Drawing.Point(12, 31);
            this.lbl_component_txt.Name = "lbl_component_txt";
            this.lbl_component_txt.Size = new System.Drawing.Size(80, 15);
            this.lbl_component_txt.TabIndex = 0;
            this.lbl_component_txt.Text = "Component";
            // 
            // nmrcUpDwn_component
            // 
            this.nmrcUpDwn_component.Location = new System.Drawing.Point(98, 29);
            this.nmrcUpDwn_component.Name = "nmrcUpDwn_component";
            this.nmrcUpDwn_component.Size = new System.Drawing.Size(120, 22);
            this.nmrcUpDwn_component.TabIndex = 1;
            this.nmrcUpDwn_component.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // bttn_calculate
            // 
            this.bttn_calculate.Location = new System.Drawing.Point(122, 57);
            this.bttn_calculate.Name = "bttn_calculate";
            this.bttn_calculate.Size = new System.Drawing.Size(96, 31);
            this.bttn_calculate.TabIndex = 2;
            this.bttn_calculate.Text = "calculate";
            this.bttn_calculate.UseVisualStyleBackColor = true;
            this.bttn_calculate.Click += new System.EventHandler(this.bttn_calculate_Click);
            // 
            // MCRSettingcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 100);
            this.Controls.Add(this.bttn_calculate);
            this.Controls.Add(this.nmrcUpDwn_component);
            this.Controls.Add(this.lbl_component_txt);
            this.Name = "MCRSettingcs";
            this.Text = "MCRSettingcs";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDwn_component)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_component_txt;
        private System.Windows.Forms.NumericUpDown nmrcUpDwn_component;
        private System.Windows.Forms.Button bttn_calculate;
    }
}