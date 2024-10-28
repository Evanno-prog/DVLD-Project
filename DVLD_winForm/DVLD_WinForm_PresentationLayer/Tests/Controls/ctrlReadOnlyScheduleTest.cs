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
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer.Tests.Controls
{
    public partial class ctrlReadOnlyScheduleTest : UserControl
    {
        private clsTestType.enTestType _TestTypeID;
        private int _TestID = -1;
        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointment _TestAppointment = null;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

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

        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        { 
            get 
            {
                return _TestID;
            }
        }

        public void LoadInfo(int AppointmentID)
        {

            _TestAppointmentID = AppointmentID;
            _TestAppointment = clsTestAppointment.Find(AppointmentID);
            if (_TestAppointment == null) 
            {
                MessageBox.Show($"No Appointment found with ID = {AppointmentID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            _TestID = _TestAppointment.TestID;
            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No LocalDrivingLicenseApplication found with ID = {_TestAppointment.LocalDrivingLicenseApplicationID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPersonName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblTestTypesFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestID == -1) ? "Not taken yet" : _TestID.ToString();

        }

        public ctrlReadOnlyScheduleTest()
        {
            InitializeComponent();
        }
    }
}
