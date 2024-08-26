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
    public partial class AppointementsVisionTest : Form
    {

        private int _LDLApplicationID = 0;
        public AppointementsVisionTest(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
        }

        private void _RefreshListTestAppointments()
        {
            DataView dv = clsTestAppointment.GetAllTestAppointments().DefaultView;
            dgvListAppointments.DataSource = dv;
            lblRecordCountAppointment.Text = dv.Count.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppointementsVisionTest_Load(object sender, EventArgs e)
        {
            ctrlL_D_L_ApplicationInfo1.LoadApplicationInfoData(_LDLApplicationID);
            _RefreshListTestAppointments();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {

            if (clsTestAppointment.IsTestAppointmentExistByLDLApp(_LDLApplicationID))
            {
                MessageBox.Show("Person Already have an active appointment for this test,\nYou cannot add new Appointment", "Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            clsTest Test = clsTest.Find(clsTest.GetLatestTestIDForCheck(_LDLApplicationID,1));
            
            if (Test != null && Test.TestResult)
            {
                MessageBox.Show("This person already passed this test before,\nYou can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (ScheduleVisionTest frm = new ScheduleVisionTest(_LDLApplicationID,-1))
            {
                frm.ShowDialog();
            }
            _RefreshListTestAppointments();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ScheduleVisionTest frm = new ScheduleVisionTest(_LDLApplicationID,(int) dgvListAppointments.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefreshListTestAppointments();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsTestAppointment testAppointment = clsTestAppointment.Find((int)dgvListAppointments.CurrentRow.Cells[0].Value);
            if (testAppointment.IsLocked)
            {
                MessageBox.Show("Sorry! this appointment already taked test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (TakeTest frm = new TakeTest((int)dgvListAppointments.CurrentRow.Cells[0].Value, 1))
            {
                frm.ShowDialog();
            }
            _RefreshListTestAppointments();
        }

      
    }
}
