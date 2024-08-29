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
    public partial class New_International_License_Application : Form
    {

        private clsLicense _License = null;
        private clsInternationalLicense _I_License = null;
        private clsApplication _Application = null;

        public New_International_License_Application()
        {
            InitializeComponent();
        }
       
        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnIssue_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue the license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                llShowLicenseInfo.Enabled = true;
                guna2btnIssue.Enabled = false;
                _Application = new clsApplication();
                _Application.ApplicantPersonID = clsApplication.Find(_License.ApplicationID).ApplicantPersonID;
                _Application.ApplicationDate = DateTime.Now;
                _Application.ApplicationTypeID = 6;
                _Application.ApplicationStatus = 1;
                _Application.LastStatusDate = DateTime.Now;
                _Application.PaidFees = clsApplicationType.Find(6).ApplicationFees;
                _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
                _Application.Save();
                
                _I_License = new clsInternationalLicense();
                _I_License.ApplicationID = _Application.ApplicationID;
                _I_License.DriverID = _License.DriverID;
                _I_License.IssuedUsingLocalLicenseID = _License.LicenseID;
                _I_License.IssueDate = DateTime.Now;
                DateTime dt = DateTime.Now.AddYears(1);
                _I_License.ExpirationDate = dt;
                _I_License.IsActive = true;
                _I_License.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
                if (_I_License.Save())
                {
                    MessageBox.Show($"International license issued successfully with ID = {_I_License.InternationalLicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InterApplicationID.Text = _I_License.ApplicationID.ToString();
                    lblInterLicenseID.Text = _I_License.InternationalLicenseID.ToString();
                }
                else
                {
                    MessageBox.Show($"Data Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Application == null)
            {
                MessageBox.Show("LicenseID is Not Valid", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (LicenseHistory frm = new LicenseHistory(_Application.ApplicationID))
            {
                frm.ShowDialog();
            }

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (InternationalDriverInfo frm = new InternationalDriverInfo(_I_License.InternationalLicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = DateTime.Now.ToString("d");
            lblFees.Text = clsApplicationType.Find(6).ApplicationFees.ToString();
            DateTime dt = DateTime.Now.AddYears(1);
            lblExpirationDate.Text = dt.ToString("d");
            lblCreatedByUser.Text = clsGlobalSettings.CurrentUser.UserName;
        }

        private void New_International_License_Application_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

            llShowLicenseInfo.Enabled = false;
            lblLocalLicenseID.Text = LicenseID.ToString();

            _License = clsLicense.Find(LicenseID);
            if (!(_License.LicenseClass == 3))
            {
                MessageBox.Show("Sorry! this license is not Class 3!\nTry again?", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(_License.IsActive))
            {
                MessageBox.Show("Sorry! this license is not Active!\nTry again?", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dt = DateTime.Now;
            if (dt >= _License.ExpirationDate)
            {
                MessageBox.Show("Sorry! this license date is Expired", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int IsI_LicenseExistAndActive = clsInternationalLicense.IsInternationalLicenseExistAndActive(LicenseID);
           
            if (IsI_LicenseExistAndActive != -1)
            {
                MessageBox.Show($"Person already has an active International license with ID = {IsI_LicenseExistAndActive}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guna2btnIssue.Enabled = true;
        }

      
    }
}
