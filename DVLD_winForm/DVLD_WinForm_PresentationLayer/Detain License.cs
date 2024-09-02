using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class Detain_License : Form
    {
        public Detain_License()
        {
            InitializeComponent();
        }

        private clsLicense _License = null;

        private void _LoadData()
        {
            lblDetainDate.Text = DateTime.Now.ToString("d");
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }


        private void Detain_License_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

            llShowLicenseInfo.Enabled = guna2btnDetain.Enabled = false;
            lblLicenseID.Text = LicenseID.ToString();

            _License = clsLicense.Find(LicenseID);

            if (!(_License.IsActive))
            {
                MessageBox.Show("Selected license is not Active, Choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Another condition should be there :-)


            guna2btnDetain.Enabled = true;
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
