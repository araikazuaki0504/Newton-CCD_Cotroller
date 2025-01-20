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
    public partial class StepPanel : Form
    {
        private Point Start_Relativity_Position;
        private Arrow Right_arrow;
        private Arrow Left_arrow;

        public StepPanel()
        {
            InitializeComponent();
            //Left_arrow.Show();
        }

        private void StepPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - Start_Relativity_Position.X;
                this.Top += e.Y - Start_Relativity_Position.Y;
                this.Update();
            }
        }

        private void StepPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Start_Relativity_Position = e.Location;
                this.Update();
            }
        }
    }
}
