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
    public partial class RenewLocalDrivingLicense : Form
    {
        public RenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private clsLicense _OldLicense = null;
        private clsLicense _NewLicense = new clsLicense();
        private clsApplication _NewApplication = new clsApplication();
        private void _LoadData()
        {

            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = DateTime.Now.ToString("d");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            //lblApplicationFees.Text = Convert.ToInt16(clsApplicationType.Find(2).ApplicationFees).ToString();

        }

       private void RenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

            llShowNewLicenseInfo.Enabled = guna2btnRenew.Enabled = false;

            lblOldLicenseID.Text = LicenseID.ToString();

            _OldLicense = clsLicense.Find(LicenseID);

            lblLicenseFees.Text = (Convert.ToInt16(clsLicenseClass.Find(_OldLicense.LicenseClass).ClassFees)).ToString();
            
            DateTime Edt = DateTime.Now.AddYears(clsLicenseClass.Find(_OldLicense.LicenseClass).DefaultValidityLength);
            lblExpirationDate.Text = Edt.ToString("d");

            int A = (int)Convert.ToDecimal(lblLicenseFees.Text), B = (int)Convert.ToDecimal(lblApplicationFees.Text);          
            lblTotalFees.Text = (A+B).ToString();

            if (!(_OldLicense.IsActive))
            {
                MessageBox.Show("Sorry! this license is not Active!\nTry again?", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dt = DateTime.Now;
            if (dt < _OldLicense.ExpirationDate)
            {
                MessageBox.Show($"Selected license is not Expired yet\nIt will expire on: {_OldLicense.ExpirationDate.ToString("d")}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guna2btnRenew.Enabled = true;

        }

        private void guna2btnRenew_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to Renew this license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
            
                _OldLicense.IsActive = false;
                _OldLicense.Save();
            //  --------------------------------------------------------------------------------------------------------
                _NewApplication.ApplicantPersonID = clsApplication.Find(_OldLicense.ApplicationID).ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = 2;
                _NewApplication.ApplicationStatus = 1;
                _NewApplication.LastStatusDate = DateTime.Now;
                //_NewApplication.PaidFees = clsApplicationType.Find(2).ApplicationFees;
                _NewApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _NewApplication.Save();
            //  --------------------------------------------------------------------------------------------------------
                _NewLicense.ApplicationID = _NewApplication.ApplicationID;
                _NewLicense.DriverID = _OldLicense.DriverID;
                _NewLicense.LicenseClass = _OldLicense.LicenseClass;
                _NewLicense.IssueDate = DateTime.Now;
                DateTime dt = DateTime.Now.AddYears(clsLicenseClass.Find(_NewLicense.LicenseClass).DefaultValidityLength);
                _NewLicense.ExpirationDate = dt;
                _NewLicense.Notes = (string.IsNullOrEmpty(txtNotes.Text)) ? DBNull.Value.ToString() : txtNotes.Text;
                _NewLicense.PaidFees = clsLicenseClass.Find(_NewLicense.LicenseClass).ClassFees;
                _NewLicense.IsActive = true;
                _NewLicense.IssueReason = 2;
                _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (_NewLicense.Save())
                {
                    MessageBox.Show($"License Renewed successfully with ID = {_NewLicense.LicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llShowNewLicenseInfo.Enabled = true;
                    guna2btnRenew.Enabled = false;
                    lblRenewLocalAppID.Text = _NewApplication.ApplicationID.ToString();
                    lblRenewLicenseID.Text = _NewLicense.LicenseID.ToString();

                }
                else
                    MessageBox.Show($"Data not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
  

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ShowLicenseInfo frm = new ShowLicenseInfo(_NewLicense.LicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            using (LicenseHistory frm = new LicenseHistory(_NewApplication.ApplicationID))
            {
                frm.ShowDialog();
            }
        }
    }
}
