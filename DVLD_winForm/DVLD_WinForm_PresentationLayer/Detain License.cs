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
    public partial class Detain_License : Form
    {
        public Detain_License()
        {
            InitializeComponent();
        }

        private clsLicense _License = null;
        private clsDetainedLicense _DetainedLicense = new clsDetainedLicense();

        private void _LoadData()
        {
            lblDetainDate.Text = DateTime.Now.ToString("d");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
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

            if (clsDetainedLicense.IsLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("Selected license is already detained, choose another one:", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guna2btnDetain.Enabled = true;
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ShowLicenseInfo frm = new ShowLicenseInfo(_License.LicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (LicenseHistory frm = new LicenseHistory(_License.ApplicationID))
            {
                frm.ShowDialog();
            }
        }

        private void guna2btnDetain_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Error!\nSome fields are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtFineFees, "This field is Required");
                return;
            }
            else
                errorProvider1.SetError(txtFineFees, "");

            if (MessageBox.Show("Are you sure you want to detain this license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {

                _DetainedLicense.LicenseID = _License.LicenseID;
                _DetainedLicense.DetainDate = DateTime.Now; 
                _DetainedLicense.FineFees = Convert.ToDecimal(txtFineFees.Text);    
                _DetainedLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _DetainedLicense.IsReleased = false;
                

                if (_DetainedLicense.Save())
                {
                    MessageBox.Show($"License Detained Successfully with ID = {_DetainedLicense.DetainID}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDetainID.Text = _DetainedLicense.DetainID.ToString();
                    llShowLicenseInfo.Enabled = true;
                }
                else
                    MessageBox.Show("Data not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
