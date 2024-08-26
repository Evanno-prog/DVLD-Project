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
    public partial class Written_test_appointment : Form
    {
        private int _LDLApplicationID = 0;
        public Written_test_appointment(int lDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = lDLApplicationID;   
        }

        private void _RefreshListTestAppointments()
        {
            DataView dv = clsTestAppointment.GetAllTestAppointments().DefaultView;
            dgvListAppointments.DataSource = dv;
            lblRecordCountAppointment.Text = dv.Count.ToString();
        }

        private void Written_test_appointment_Load(object sender, EventArgs e)
        {
            ctrlL_D_L_ApplicationInfo1.LoadApplicationInfoData(_LDLApplicationID);
            _RefreshListTestAppointments();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {

            if (clsTestAppointment.IsTestAppointmentExistByLDLApp(_LDLApplicationID))
            {
                MessageBox.Show("Person Already have an active appointment for this test,\nYou cannot add new Appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest Test = clsTest.Find(clsTest.GetLatestTestIDForCheck(_LDLApplicationID, 2));

            if (Test != null && Test.TestResult)
            {
                MessageBox.Show("This person already passed this test before,\nYou can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (ScheduleWrittenTest frm = new ScheduleWrittenTest(_LDLApplicationID, -1))
            {
                frm.ShowDialog();
            }
            _RefreshListTestAppointments();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (ScheduleWrittenTest frm = new ScheduleWrittenTest(_LDLApplicationID, (int)dgvListAppointments.CurrentRow.Cells[0].Value))
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


            using (TakeTest frm = new TakeTest((int)dgvListAppointments.CurrentRow.Cells[0].Value, 2))
            {
                frm.ShowDialog();
            }

            _RefreshListTestAppointments();
        }

    }
}
