using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCD_controller_windows_form
{
    public partial class CCDImage_View_Form : Form
    {
        private Bitmap _CCD_Image;
        private int _Image_Width;
        private int _Image_Height;


        public CCDImage_View_Form(Bitmap CCD_Image)
        {
            InitializeComponent();
            _CCD_Image = (Bitmap) CCD_Image.Clone();
            _Image_Width = CCD_Image.Width;
            _Image_Height = CCD_Image.Height;

            this.ClientSize = new Size(1200, 300);
            this.pctrbx_CCD_Image.Size = this.ClientSize;

            this.pctrbx_CCD_Image.Image = CCD_Image;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void change_Image(Bitmap CCD_Image)
        {
            _CCD_Image = (Bitmap)CCD_Image.Clone();
            _Image_Width = CCD_Image.Width;
            _Image_Height = CCD_Image.Height;

            this.pctrbx_CCD_Image.Image = CCD_Image;
        }
    }
}
