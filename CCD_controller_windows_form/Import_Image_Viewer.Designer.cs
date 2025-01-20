namespace CCD_controller_windows_form
{
    partial class Import_Image_Viewer
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
            this.pctrBx_CCD_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBx_CCD_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pctrBx_CCD_Image
            // 
            this.pctrBx_CCD_Image.Location = new System.Drawing.Point(0, 0);
            this.pctrBx_CCD_Image.Margin = new System.Windows.Forms.Padding(0);
            this.pctrBx_CCD_Image.Name = "pctrBx_CCD_Image";
            this.pctrBx_CCD_Image.Size = new System.Drawing.Size(512, 132);
            this.pctrBx_CCD_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrBx_CCD_Image.TabIndex = 0;
            this.pctrBx_CCD_Image.TabStop = false;
            this.pctrBx_CCD_Image.Click += new System.EventHandler(this.pctrBx_CCD_Image_Click);
            // 
            // Import_Image_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(513, 134);
            this.Controls.Add(this.pctrBx_CCD_Image);
            this.Name = "Import_Image_Viewer";
            this.Text = "Import_Image_Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pctrBx_CCD_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrBx_CCD_Image;
    }
}