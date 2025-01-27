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
    public partial class MCRSettingcs : Form
    {
        public event EventHandler Calculate;

        public MCRSettingcs()
        {
            InitializeComponent();
        }

        public int get_component_number()
        {
            return (int)nmrcUpDwn_component.Value;
        }

        private void bttn_calculate_Click(object sender, EventArgs e)
        {
            Calculate?.Invoke(this, EventArgs.Empty);
        }
    }
}
