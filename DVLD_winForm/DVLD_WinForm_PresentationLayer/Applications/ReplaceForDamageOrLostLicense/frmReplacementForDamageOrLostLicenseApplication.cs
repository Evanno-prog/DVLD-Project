using DVLD_Buisness;
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
using static DVLD_BussinessLayer.clsLicense;
namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmReplacementForDamageOrLostLicenseApplication : Form
    {
        public frmReplacementForDamageOrLostLicenseApplication()
        {
            InitializeComponent();
        }

        private int _NewLicenseID = -1;
      
        private void ReplacementForDamageOrLostLicense_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Enabled = true;
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = lblTitle.Text = "Replacement for a Damaged License";
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = lblTitle.Text = "Replacement for a Lost License";
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int SelectedLicenseID)
        {

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;

            if (!ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active, choose an active license:", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2btnIssueReplacement.Enabled = false;
                return;
            }

            guna2btnIssueReplacement.Enabled = true;

        }

        enIssueReason _GetIssueReason()
        {

            if (rbDamagedLicense.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;

        }

        private void guna2btnIssueReplacement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue a replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense NewLicense = ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to issue a replacement for this License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            lblLReplacementAppID.Text = NewLicense.ApplicationID.ToString();
            lblReplacedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("License Replaced Successfully with ID =" +
            _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            llShowNewLicenseInfo.Enabled = true;
            gbReplacementFor.Enabled = false;
            guna2btnIssueReplacement.Enabled = false;
            ctrlFilterByDriverLicenseInfo1.FilterEnabled = false;

        }

        
        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.DriverInfo.PersonID))
            {
                frm.ShowDialog();
            }
        }

        private void ReplacementForDamageOrLostLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlFilterByDriverLicenseInfo1.txtLicenseIdFocus();
        }
    }
}
