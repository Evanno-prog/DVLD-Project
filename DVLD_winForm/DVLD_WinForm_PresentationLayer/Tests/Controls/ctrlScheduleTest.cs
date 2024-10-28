using DVLD_Buisness;
using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using DVLD_WinForm_PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {

        enum enMode {AddNew,Update}
        private enMode _Mode = enMode.AddNew;

        enum enCreationMode { FirstTimeSchedule, RetakeTestSchedule }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestAppointment _TestAppointment = null;
        private int _TestAppointmentID = -1;

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    case clsTestType.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.Street_Test_32;
                        break;
                  
                }
            }
        }
  
        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show($"No Appointment with ID = {_TestAppointmentID}", "ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2btnSave.Enabled = false;
                return false;
            }

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0) 
                dtpAppointmentDate.MinDate = DateTime.Now;
            else
                dtpAppointmentDate.MinDate = _TestAppointment.AppointmentDate;
            
            dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;
            lblTestTypesFees.Text = _TestAppointment.PaidFees.ToString();

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";
            }
            else
            {
                lblRTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                lblTitle.Text = "Schedule Retake Test";
            }

            return true;
        }

        private bool _HandleAnActiveAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID,TestTypeID))
            {
                lblUserMessage.Text = "Person already had an active Appointment for this test";
                lblUserMessage.Visible = true;
                guna2btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Text = "Person already sat for this test, Appointment locked";
                lblUserMessage.Visible= true;
                guna2btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }
            else
                lblUserMessage.Visible = false;

            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {

            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;
                case clsTestType.enTestType.WrittenTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot apply for written test, person should pass vision test before";
                        lblUserMessage.Visible = true;
                        guna2btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        guna2btnSave.Enabled = true;
                        dtpAppointmentDate.Enabled = true;
                    }

                    return true;        
                case clsTestType.enTestType.StreetTest:

                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot apply for written test, person should pass written Test before";
                        lblUserMessage.Visible = true;
                        guna2btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;
                        return false;
                    }
                    else
                        lblUserMessage.Visible = false;
                        guna2btnSave.Enabled = true;
                        dtpAppointmentDate.Enabled = true;
                    return true;

            }
            return true;
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID,int AppointmentID = -1)
        {

            _Mode = (AppointmentID == -1) ? enMode.AddNew : enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2btnSave.Enabled = false;
                return;
            }


            _CreationMode = (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID)) ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule) 
            {
                lblRetakeAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                lblRTestAppID.Text = "0";
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
            }
            else 
            {
                lblRetakeAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
                lblTitle.Text = "Schedule Test";
                gbRetakeTestInfo.Enabled = false;
            }

            lblLDLApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
            lblApplicantPerson.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            if (_Mode == enMode.AddNew)
            {
                lblTestTypesFees.Text = clsTestType.Find(_TestTypeID).Fees.ToString();
                dtpAppointmentDate.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";
                _TestAppointment = new clsTestAppointment();
            }
            else
            {

                if (!_LoadTestAppointmentData())
                    return; 
            }

            lblTotalFees.Text = (Convert.ToSingle(lblTestTypesFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();

            if (!_HandleAnActiveAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;
        }

        private bool _HandleRetakeTestApplication()
        {

            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication App = new clsApplication();
                App.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                App.ApplicationDate = DateTime.Now;
                App.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                App.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                App.LastStatusDate = DateTime.Now;
                App.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                App.CreatedByUserID = clsGlobal.CurrentUser.UserID;
               
                if (!App.Save())
                {
                    MessageBox.Show("Error: Failed to create application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _TestAppointment.RetakeTestApplicationID = -1;
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = App.ApplicationID;
               
            }
            return true;
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (!_HandleRetakeTestApplication())
                return;

            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.PaidFees = Convert.ToSingle(lblTestTypesFees.Text);
            if (_Mode == enMode.AddNew)
                _TestAppointment.IsLocked = false;
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
            }
            else
                MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
