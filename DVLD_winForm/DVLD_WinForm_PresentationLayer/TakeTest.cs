using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppointmentsBusinessLayer;
using TestsBusinessLayer;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class TakeTest : Form
    {
        private int _AppointmentID = 0;
        private clsTest _Test = new clsTest();
        private clsTestAppointment _TestAppointment = null;
        private clsLocalDrivingLicenseApplication _LDLApp = null;
        private int _TestType_id = 0;
        public TakeTest(int AppointmentID,int Testtype_id)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestAppointment = clsTestAppointment.Find(_AppointmentID);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_TestAppointment.LocalDrivingLicenseApplicationID);
            _TestType_id= Testtype_id;
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

        private void SetImageTest()
        {
            if (_TestType_id == 1)
            {
                gbTest.Text = "Vision test";
                pbTest.Load("D:\\Rel_Schema for DVLD\\ICONS\\Vision 512.png");
            }
            else if (_TestType_id == 2)
            {
                gbTest.Text = "Written test";
                pbTest.Load("D:\\Rel_Schema for DVLD\\ICONS\\Written Test 512.png");
            }
            else
            {
                gbTest.Text = "Street test";
                pbTest.Load("D:\\Rel_Schema for DVLD\\ICONS\\driving-test 512.png");
            }

        }
        private void _LoadData()
        {

            SetImageTest();

            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblTestTypesFees.Text = Convert.ToInt16(_TestAppointment.PaidFees).ToString();

            DataTable Dt = clsApplication.GetLocalApplications(_LDLApp.LocalDrivingLicenseApplicationID);

            lblLDLApplicationID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _GetLicenseClassName(_LDLApp.LicenseClassID);
            foreach (DataRow item in Dt.Rows)
            {
                lblTrial.Text = clsLocalDrivingLicenseApplication.GetNumberOfTrialTest(_LDLApp.LocalDrivingLicenseApplicationID, _TestAppointment.TestTypeID).ToString();
                lblApplicantPerson.Text = item["FullName"].ToString();
            }


        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change\n the Pass/Fail result after you save?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Test.TestAppointmentID = _TestAppointment.TestAppointmentID;
                _Test.TestResult = (rbPass.Checked) ? true : false;
                if (txtNotes.Text != "")
                    _Test.Notes = txtNotes.Text;
                else
                    _Test.Notes = DBNull.Value.ToString();

                _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (_Test.Save())
                {
                    MessageBox.Show("Data saved succfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _TestAppointment.IsLocked = true;
                    _TestAppointment.Save();
                    Close();
                }
                else
                {
                    MessageBox.Show("Data Not Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
