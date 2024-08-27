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

        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void _LoadData()
        {

        }

        private void New_International_License_Application_Load(object sender, EventArgs e)
        {
            _LoadData();        
        }

        private void ctrlFilterByDriverLicenseInfo1_OnLicenseSelected(int LicenseID)
        {

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
            if (dt > _License.ExpirationDate)
            {
                MessageBox.Show("Sorry! this license date is Ended", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (clsInternationalLicense.IsInternationalLicenseExistByLicenseID(_License.LicenseID))
            //{
                
            //}

        }

        private void ctrlFilterByDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
