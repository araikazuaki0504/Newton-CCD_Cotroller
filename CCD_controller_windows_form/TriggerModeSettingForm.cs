using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMCD64CS;

using MessageBox = System.Windows.Forms.MessageBox;
using TriggerMode = ATMCD64CS.AndorSDK.TriggerMode;

namespace CCD_controller_windows_form
{
    public partial class TriggerModeSettingForm : Form
    {
        private uint errorValue;

        public TriggerModeSettingForm()
        {
            InitializeComponent();
            errorValue = AndorSDK.SetTriggerMode(TriggerMode.Internal);
            if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("TriggerModeを変更できませんでした。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bttn_Confirm_Click(object sender, EventArgs e)
        {
            int Changed_Trigger_Mode;

            if (rdbttn_internal_Mode.Checked) Changed_Trigger_Mode = TriggerMode.Internal;
            else if (rdbttn_External_Mode.Checked) Changed_Trigger_Mode = TriggerMode.External;
            else if (rdbttn_External_Start_Mode.Checked) Changed_Trigger_Mode = TriggerMode.External_Start;
            else if (rdbttn_External_Exposure_Mode.Checked) Changed_Trigger_Mode = TriggerMode.External_Exposure;
            else if (rdbttn_Software_Trigger_Mode.Checked) Changed_Trigger_Mode = TriggerMode.Software_Trigger;
            else Changed_Trigger_Mode = TriggerMode.External_Charge_Shifting;

            errorValue = AndorSDK.SetTriggerMode(Changed_Trigger_Mode);
            if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("TriggerModeを変更できませんでした。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
