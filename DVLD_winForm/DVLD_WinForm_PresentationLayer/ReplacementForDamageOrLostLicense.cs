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
    public partial class ReplacementForDamageOrLostLicense : Form
    {
        public ReplacementForDamageOrLostLicense()
        {
            InitializeComponent();
        }

        private clsApplication _NewApplication = new clsApplication();
        private clsLicense _NewLicense = new clsLicense();
        private clsLicense _OldLicense = null;

        private void _LoadData()
        {
            rbDamagedLicense.Checked = true;
            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
      
        private void ReplacementForDamageOrLostLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = lblTitle.Text = "Replacement for a Damaged License";
            //lblApplicationFees.Text = Convert.ToInt16(clsApplicationType.Find(4).ApplicationFees).ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = lblTitle.Text = "Replacement for a Lost License";
            //lblApplicationFees.Text = Convert.ToInt16(clsApplicationType.Find(3).ApplicationFees).ToString();
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

            llShowNewLicenseInfo.Enabled = guna2btnIssueReplacement.Enabled = false;

            lblOldLicenseID.Text = LicenseID.ToString();

            _OldLicense = clsLicense.Find(LicenseID);

            if (!(_OldLicense.IsActive))
            {
                MessageBox.Show("Selected license is not Active, Choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guna2btnIssueReplacement.Enabled = true;

        }

        private void guna2btnIssueReplacement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                _OldLicense.IsActive = false;
                _OldLicense.Save();
            //  --------------------------------------------------------------------------------------------------------
                //_NewApplication.ApplicantPersonID = clsApplication.Find(_OldLicense.ApplicationID).ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = (rbDamagedLicense.Checked) ? 4 : 3;
                //_NewApplication.ApplicationStatus = 1;
                _NewApplication.LastStatusDate = DateTime.Now;
                //_NewApplication.PaidFees = clsApplicationType.Find(_NewApplication.ApplicationTypeID).ApplicationFees;
                _NewApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _NewApplication.Save();
            //  --------------------------------------------------------------------------------------------------------
                _NewLicense.ApplicationID = _NewApplication.ApplicationID;
                _NewLicense.DriverID = _OldLicense.DriverID;
                _NewLicense.LicenseClass = _OldLicense.LicenseClass;
                _NewLicense.IssueDate = DateTime.Now;
                DateTime dt = DateTime.Now.AddYears(clsLicenseClass.Find(_NewLicense.LicenseClass).DefaultValidityLength);
                _NewLicense.ExpirationDate = dt;
                _NewLicense.Notes = DBNull.Value.ToString();
                _NewLicense.PaidFees = clsLicenseClass.Find(_NewLicense.LicenseClass).ClassFees;
                _NewLicense.IsActive = true;
                _NewLicense.IssueReason = (rbDamagedLicense.Checked) ? 3 : 4;
                _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (_NewLicense.Save())
                {
                    MessageBox.Show($"License Replaced Successfully with ID = {_NewLicense.LicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llShowNewLicenseInfo.Enabled = true;
                    ctrlFilterByDriverLicenseInfo1.IsgbFilterByLicenseIDEnabled(false);
                    gbReplacementFor.Enabled = guna2btnIssueReplacement.Enabled = false;
                    
                    lblLReplacementAppID.Text = _NewApplication.ApplicationID.ToString();
                    lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
                }
                else
                    MessageBox.Show($"Data not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        
        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ShowLicenseInfo frm = new ShowLicenseInfo(_NewLicense.LicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (LicenseHistory frm = new LicenseHistory(_NewLicense.ApplicationID))
            {
                frm.ShowDialog();
            }
        }
    }
}
