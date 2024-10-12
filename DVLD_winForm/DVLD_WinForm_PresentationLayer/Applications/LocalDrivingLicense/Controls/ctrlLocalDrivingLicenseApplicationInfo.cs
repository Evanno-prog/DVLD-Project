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
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LicenseID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        public int LocalDrivingLicenseApplicationID
        {
            get {  return _LocalDrivingLicenseApplicationID;}
        }

        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetLocalDrivingApplication()
        {
            _LocalDrivingLicenseApplicationID = -1;
            lblLDLApplicationID.Text = "[???]";
            lblLicenseClass.Text = "[???]";
            lblPassedTests.Text = "[???]";
            lblShowLicenseInfo.Enabled = false;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            lblShowLicenseInfo.Enabled = (_LicenseID != -1);
            lblLDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No LocalDrivingApplication Found With ID = {LocalDrivingLicenseApplicationID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetLocalDrivingApplication();
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();

        } 
     
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No LocalDrivingApplication Found With ID = {LocalDrivingLicenseApplicationID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetLocalDrivingApplication();
                return;
            }

            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _FillLocalDrivingLicenseApplicationInfo();

        } 

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ShowLicenseInfo frm = new ShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID()))
            {
                frm.ShowDialog();
            }
        }
    }
}
