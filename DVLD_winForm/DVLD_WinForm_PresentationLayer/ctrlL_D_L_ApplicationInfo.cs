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
    public partial class ctrlL_D_L_ApplicationInfo : UserControl
    {

        public ctrlL_D_L_ApplicationInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplication _LDL_App;
        private clsApplication _Application;

        private string _GetLicenseClassName(int LicenseClassId)
        {

            switch (LicenseClassId)
            {
                case 1:
                    return "Class 1 - Small Motorcycle";
                case 2:
                    return "Class 2 - Heavy Motorcycle License";
                case 3:
                    return "Class 3 - Ordinary driving license";
                case 4:
                    return "Class 4 - Commercial";
                case 5:
                    return "Class 5 - Agricultural";
                case 6:
                    return "Class 6 - Small and medium bus";
                case 7:
                    return "Class 7 - Truck and heavy vehicle";

                default:
                    return "";
            }

        }

        private string _GetApplicationTypeName(int AppTypeID)
        {
            switch (AppTypeID)
            {
                case 1:
                    return "New Local Driving License Service";
                case 2:
                    return "Renew Driving License Service";
                case 3:
                    return "Replacement for a Lost Driving License";
                case 4:
                    return "Replacement for a Damaged Driving License";
                case 5:
                    return "Release Detained Driving Licsense";
                case 6:
                    return "New International License";
                case 8:
                    return "Retake Test";
                default:
                    return "";
            }
        }

        private string _GetApplicationStatusName(int AppStatusID)
        {
            switch (AppStatusID)
            {
                case 1:
                    return "New";
                case 2:
                    return "Cancelled";
                case 3:
                    return "Completed";

                default:
                    return "";
            }
        }

        public void LoadApplicationInfoData(int LDL_ApplicationID)
        {
            //_LDL_App = clsLocalDrivingLicenseApplication.Find(LDL_ApplicationID);

            lblLDLApplicationID.Text = LDL_ApplicationID.ToString();
            lblLicenseClass.Text = _GetLicenseClassName(_LDL_App.LicenseClassID);
            //DataTable Dt = clsApplication.GetLocalApplications(LDL_ApplicationID);
            //foreach (DataRow item in Dt.Rows)
            //{
            //    lblPassedTests.Text = $"{Convert.ToInt16(item["PassedTestCount"])}/3";
            //    lblApplicantPerson.Text = item["FullName"].ToString();
            //}
            
            //_Application = clsApplication.Find(_LDL_App.ApplicationID);
            lblAppID.Text = _Application.ApplicationID.ToString();
            //lblApplicationStatus.Text = _GetApplicationStatusName(_Application.ApplicationStatus);
            lblApplicationFees.Text =  (Convert.ToInt16(_Application.PaidFees)).ToString();
            lblApplicationTypes.Text = _GetApplicationTypeName(_Application.ApplicationTypeID);
            lblApplicationStatusDate.Text = _Application.LastStatusDate.ToString("d");
            lblApplicationDate.Text = _Application.ApplicationDate.ToString("d");
        }

        private void ctrlL_D_L_ApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID))
            {
                frm.ShowDialog();
            }
        }
    }
}
