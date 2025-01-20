namespace CCD_controller_windows_form
{
    partial class CCDImage_View_Form
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
            this.pctrbx_CCD_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_CCD_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pctrbx_CCD_Image
            // 
            this.pctrbx_CCD_Image.Location = new System.Drawing.Point(0, 0);
            this.pctrbx_CCD_Image.Name = "pctrbx_CCD_Image";
            this.pctrbx_CCD_Image.Size = new System.Drawing.Size(0, 0);
            this.pctrbx_CCD_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrbx_CCD_Image.TabIndex = 0;
            this.pctrbx_CCD_Image.TabStop = false;
            // 
            // CCDImage_View_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 0);
            this.Controls.Add(this.pctrbx_CCD_Image);
            this.Name = "CCDImage_View_Form";
            this.Text = "CCDImage_View_Form";
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_CCD_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrbx_CCD_Image;
    }
}