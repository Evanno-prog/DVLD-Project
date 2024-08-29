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
    public partial class RenewLocalDrivingLicense : Form
    {
        public RenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private clsLicense _License = null;
        private clsApplication _Application = null;
        private void _LoadData()
        {

            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = DateTime.Now.ToString("d");
            //lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
            lblApplicationFees.Text = Convert.ToInt16(clsApplicationType.Find(2).ApplicationFees).ToString();

        }

        private void RenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

            llShowNewLicenseInfo.Enabled = guna2btnRenew.Enabled = false;

            lblOldLicenseID.Text = LicenseID.ToString();

            _License = clsLicense.Find(LicenseID);

            lblLicenseFees.Text = (Convert.ToInt16(clsLicenseClass.Find(_License.LicenseClass).ClassFees)).ToString();
            
            DateTime Edt = DateTime.Now.AddYears(clsLicenseClass.Find(_License.LicenseClass).DefaultValidityLength);
            lblExpirationDate.Text = Edt.ToString("d");

            int A = (int)Convert.ToDecimal(lblLicenseFees.Text), B = (int)Convert.ToDecimal(lblApplicationFees.Text);          
            lblTotalFees.Text = (A+B).ToString();

            if (!(_License.IsActive))
            {
                MessageBox.Show("Sorry! this license is not Active!\nTry again?", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dt = DateTime.Now;
            if (dt < _License.ExpirationDate)
            {
                MessageBox.Show($"Selected license is not Expired yet\nIt will expire on: {_License.ExpirationDate.ToString("d")}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guna2btnRenew.Enabled = true;

        }


        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
