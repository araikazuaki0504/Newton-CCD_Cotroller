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
    public partial class Arrow : Form
    {
        public Arrow(int X_Pox,int Y_Pos)
        {
            InitializeComponent();
            this.Location = new Point(X_Pox - this.Width / 2, Y_Pos - this.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Update();
        }

        public void setWindowPosition(int X_Pox, int Y_Pos)
        {
            this.Location = new Point(X_Pox - this.Width / 2, Y_Pos - this.Height / 2);
            //this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
        }
    }
}
