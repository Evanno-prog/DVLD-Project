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
using TestAppointmentsBusinessLayer;
using TestsBusinessLayer;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ScheduleStreetTest : Form
    {

        private int _LDLApplicationID = 0;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        private clsApplication _Application;
        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = 0;
        private clsTest _Test;
        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;


        public ScheduleStreetTest(int lDLApplicationID, int TestAppointmentID)
        {
            InitializeComponent();
            _LDLApplicationID = lDLApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLApplicationID);
            _Application = clsApplication.Find(_LDLApplication.ApplicationID);
            _TestAppointmentID = TestAppointmentID;
            if (_TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

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

        private void _LoadData()
        {

            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            lblLicenseClass.Text = _GetLicenseClassName(_LDLApplication.LicenseClassID);
            DataTable Dt = clsApplication.GetLocalApplications(_LDLApplicationID);
            foreach (DataRow item in Dt.Rows)
            {
                lblTrial.Text = clsLocalDrivingLicenseApplication.GetNumberOfTrialTest(_LDLApplicationID, 3).ToString();
                lblApplicantPerson.Text = item["FullName"].ToString();
            }

            lblTestTypesFees.Text = Convert.ToInt16(clsTestType.Find(3).TestTypeFees).ToString();

            lblTrial.Text = clsLocalDrivingLicenseApplication.GetNumberOfTrialTest(_LDLApplicationID, 3).ToString();

            if (_Mode == enMode.Update)
            {


                _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
                dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;
                if (_TestAppointment.IsLocked)
                {
                    lblAppoinLocked.Text = "Person Already sat for the test, appointment locked.";
                    lblAppoinLocked.Visible = true;
                    dtpAppointmentDate.Enabled = false;
                    guna2btnSave.Enabled = false;
                    return;
                }
                else
                {
                    lblAppoinLocked.Visible = false;
                    dtpAppointmentDate.Enabled = true;
                    guna2btnSave.Enabled = true;
                }

                clsRetakeTest Rtest = clsRetakeTest.FindRtestInfoByTestAppointmentID(_TestAppointmentID);
                if (Rtest != null)
                {
                    lblTitle.Text = "Schedule Retake test";
                    gbRetakeTestInfo.Enabled = true;
                    lblRetakeAppFees.Text = "5";
                    lblTotalFees.Text = Convert.ToInt16(clsTestType.Find(3).TestTypeFees + 5).ToString();
                    lblRTestAppID.Text = Rtest.RetakeTestID.ToString();
                }

            }


            _Test = clsTest.Find(clsTest.GetLatestTestIDForCheck(_LDLApplicationID, 3));
            if (_Test != null)
            {
                if (!_Test.TestResult)
                {
                    // Logic code of retake test will be here :-)
                    lblTitle.Text = "Schedule Retake test";
                    gbRetakeTestInfo.Enabled = true;
                    lblRetakeAppFees.Text = "5";
                    lblTotalFees.Text = Convert.ToInt16(clsTestType.Find(3).TestTypeFees + 5).ToString();

                    clsRetakeTest Rtest = clsRetakeTest.FindRtestInfoByTestAppointmentID(_TestAppointmentID);
                    lblRTestAppID.Text = (Rtest != null) ? Rtest.RetakeTestID.ToString() : "0";
                }
            }

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointment();
                return;
            }

        }


        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointment.TestTypeID = 3;
            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApplicationID;
            _TestAppointment.PaidFees = clsTestType.Find(3).TestTypeFees;
            if (_Mode == enMode.AddNew)
            {
                _TestAppointment.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            }

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment.IsLocked = false;
            }


            if (_TestAppointment.Save())
            {
                MessageBox.Show("Appointment Saved Succfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_Test != null)
                {
                    if (!_Test.TestResult)
                    {
                        clsRetakeTest Rtest = new clsRetakeTest();
                        Rtest.TestAppointment_id = _TestAppointment.TestAppointmentID;
                        Rtest.RetakeTestFees = 5;
                        Rtest.Save();
                    }

                }
                Close();
            }
            else
                MessageBox.Show("Appointment Not Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();


        }

        private void ScheduleStreetTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpAppointmentDate.Value;
            DateTime currentDate = DateTime.Now;
            if (selectedDate < currentDate)
            {
                MessageBox.Show("Please select a future date.", "Date Selection Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpAppointmentDate.Value = DateTime.Now; // Set the current date
            }

        }
    }
}
