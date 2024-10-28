using DVLD_Buisness;
using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Properties;
using DVLD_WinForm_PresentationLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmListTestAppointments : Form
    {

        private DataTable _dtListTestAppointments;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _LocalDrivingLicenseApplicationID = 0;
   
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void _SetTestTypeTitleAndImage()
        {

            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    this.Text = lblTitle.Text = "Vision Test Appointment";
                    pbTestTypeImage.Image = Resources.Vision_512;
                    break;
                case clsTestType.enTestType.WrittenTest:
                    this.Text = lblTitle.Text = "Written Test Appointment";
                    pbTestTypeImage.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.StreetTest:
                    this.Text = lblTitle.Text = "Street Test Appointment";
                    pbTestTypeImage.Image = Resources.Street_Test_32;
                    break;
          
            }

        }

        private void ListTestAppointements_Load(object sender, EventArgs e)
        {
            _SetTestTypeTitleAndImage();
            ctrlLocalDrivingApplicationInfo.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtListTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvListAppointments.DataSource = _dtListTestAppointments;
            lblRecordCountAppointment.Text = dgvListAppointments.Rows.Count.ToString();
           
            if (dgvListAppointments.Rows.Count > 0)
            {
                dgvListAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvListAppointments.Columns[0].Width = 150;

                dgvListAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvListAppointments.Columns[1].Width = 200;

                dgvListAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvListAppointments.Columns[2].Width = 150;

                dgvListAppointments.Columns[3].HeaderText = "Is Locked";
                dgvListAppointments.Columns[3].Width = 100;
            }     
                
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (LocalDrivingApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already had an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LocalDrivingApplication.DoesPassTestType(_TestTypeID))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                frm.ShowDialog();
            }
            //Refresh dgv :-)
            ListTestAppointements_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, (int)dgvListAppointments.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }

            ListTestAppointements_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmTakeTest frm = new frmTakeTest((int)dgvListAppointments.CurrentRow.Cells[0].Value,_TestTypeID))
            {
                frm.ShowDialog();
            }

            ListTestAppointements_Load(null, null);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
