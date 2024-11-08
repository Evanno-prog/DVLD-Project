using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
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

    public partial class frmIssueDriverLicenseForFirstTime : Form
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        public frmIssueDriverLicenseForFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void IssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {

            txtNotes.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Local Driving License with ID = {_LocalDrivingLicenseApplicationID}", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person must pass all test before", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show($"Error: Person already has a license like this applied LicenseClass with LicenseID {LicenseID}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }

            ctrlLocalDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " +
                LicenseID.ToString(),
                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
