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
    public partial class frmDetainLicense : Form
    {

        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }


        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

            guna2btnDetain.Enabled = false;
            _SelectedLicenseID = LicenseID;
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);
            if (_SelectedLicenseID == -1)
            {
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected license is already detained , choose another one:", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active, choose an active license", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guna2btnDetain.Enabled = true;
            txtFineFees.Focus();
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowLicenseInfo frm = new frmShowLicenseInfo(ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.LicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.DriverInfo.PersonID))
            {
                frm.ShowDialog();
            }
        }

        private void guna2btnDetain_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error: Invalid input in txtFineFees, put the mouse over the red icon to see the error message", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
           
            _DetainID = ctrlDriverLicenseInfoWithFilter.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1) 
            {
                MessageBox.Show("Failed to detain license", "Not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            llShowLicenseInfo.Enabled = true;
            txtFineFees.Enabled = false;
            guna2btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter.FilterEnabled = false;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty");
                return;
            }
            else
                errorProvider1.SetError(txtFineFees, null);

            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number!\nEnter a valid number?");
            }
            else
                errorProvider1.SetError(txtFineFees, null);

        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter.txtLicenseIdFocus();
        }
    }
}
