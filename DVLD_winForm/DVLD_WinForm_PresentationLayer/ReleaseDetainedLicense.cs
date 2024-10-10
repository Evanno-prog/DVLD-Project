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
    public partial class ReleaseDetainedLicense : Form
    {
        public ReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        private clsLicense _License = null;
        private clsApplication _NewApplication = new clsApplication();
        private clsDetainedLicense _OldDetainedLicense = null;
        private DataTable _dt = null;
  
        private void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        public void SetValueTotxtLicenseID(string Num)
        {
            ctrlFilterByDriverLicenseInfo1.SetTextValue(Num);
            ctrlFilterByDriverLicenseInfo1.btnFindLicenseID_Click(null, null);
            ctrlFilterByDriverLicenseInfo1.IsgbFilterByLicenseIDEnabled(false);
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {


            llShowLicenseInfo.Enabled = guna2btnRelease.Enabled = false;
            lblLicenseID.Text = LicenseID.ToString();

            _License = clsLicense.Find(LicenseID);

            if (!(_License.IsActive))
            {
                MessageBox.Show("Selected license is not Active, Choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsDetainedLicense.IsLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("Selected license is not detained, choose another one:", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

             _dt = clsDetainedLicense.GetDetainedLicenseByLicenseID(LicenseID);

            DataRow dr = _dt.Rows[0];
            lblDetainID.Text = dr["DetainID"].ToString();
            lblDetainDate.Text = Convert.ToDateTime(dr["DetainDate"]).ToString("d");
            lblFineFees.Text = Convert.ToInt16(dr["FineFees"]).ToString();
            //lblApplicationFees.Text = Convert.ToInt16(clsApplicationType.Find(5).ApplicationFees).ToString();
            lblTotalFees.Text = (Convert.ToInt16(lblFineFees.Text) + Convert.ToInt16(lblApplicationFees.Text)).ToString();

            guna2btnRelease.Enabled = true;

        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release this detained license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //_NewApplication.ApplicantPersonID = clsApplication.Find(_License.ApplicationID).ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = 5;
                //_NewApplication.ApplicationStatus = 1;
                _NewApplication.LastStatusDate = DateTime.Now;
                //_NewApplication.PaidFees = clsApplicationType.Find(_NewApplication.ApplicationTypeID).ApplicationFees;
                _NewApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _NewApplication.Save();
        //  ------------------------------------------------------------------------
                DataRow dr = _dt.Rows[0];
                _OldDetainedLicense = clsDetainedLicense.Find(Convert.ToInt16(dr["DetainID"]));
                _OldDetainedLicense.IsReleased = true;  
                _OldDetainedLicense.ReleaseDate = DateTime.Now;
                _OldDetainedLicense.ReleaseApplicationID = _NewApplication.ApplicationID;
                _OldDetainedLicense.ReleasedByUserID = clsGlobal.CurrentUser.UserID;
                if (_OldDetainedLicense.Save())
                {
                    MessageBox.Show("Detained License released Successfully", "License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblApplicationID.Text = _NewApplication.ApplicationID.ToString();
                    guna2btnRelease.Enabled = false;
                    llShowLicenseInfo.Enabled = true;
                }
                else
                    MessageBox.Show("Data not saved :-(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
    }
}
