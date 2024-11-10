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

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmRenewLocalDrivingLicense : Form
    {

        private int _NewLicenseID = -1;

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlFilterByDriverLicenseInfo1.txtLicenseIdFocus();
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int SelectedLicenseID)
        {
            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            if (SelectedLicenseID == -1)
            {
                return;
            }
        
            lblLicenseFees.Text = ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            txtNotes.Text = ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.Notes;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength));
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();

            //   Check if the license is not expired 
            if (!ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show($"Selected license is not expired yet, it will expire on: {ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.ExpirationDate}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2btnRenew.Enabled = false;
                return;
            }

            //  Check if the license is not Active
            if (!ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active, choose an active license", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2btnRenew.Enabled = false;
                return;
            }

            guna2btnRenew.Enabled = true;
        }
 
        private void guna2btnRenew_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense NewLicense = ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);
            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Renew the license", "Renewed failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            MessageBox.Show("License Renewed Successfully with ID = " + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblRenewLocalAppID.Text = NewLicense.ApplicationID.ToString();
            lblRenewLicenseID.Text = NewLicense.LicenseID.ToString();

            ctrlFilterByDriverLicenseInfo1.FilterEnabled = false;
            guna2btnRenew.Enabled = false;
            llShowNewLicenseInfo.Enabled = true;

        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRenewLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlFilterByDriverLicenseInfo1.txtLicenseIdFocus();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This future is not implemented yet","Not Ready",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //using (LicenseHistory frm = new LicenseHistory(ctrlFilterByDriverLicenseInfo1.SelectedLicenseInfo.DriverInfo.PersonID))
            //{
            //    frm.ShowDialog();
            //}
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID))
            {
                frm.ShowDialog();
            }
        }
    }

}
