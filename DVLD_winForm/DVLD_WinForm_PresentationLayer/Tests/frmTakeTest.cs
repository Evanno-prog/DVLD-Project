using DVLD_Buisness;
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

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmTakeTest : Form
    {


        public clsTestType.enTestType _TestTypeID;
        private int _TestID = -1;
        private int _TestAppointmentID = -1;
        private clsTest _Test;

        public frmTakeTest(int AppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _TestAppointmentID = AppointmentID;
        }


        private void TakeTest_Load(object sender, EventArgs e)
        {

            ctrlScheduledTest.TestTypeID = _TestTypeID;
            ctrlScheduledTest.LoadInfo(_TestAppointmentID);

            guna2btnSave.Enabled = (ctrlScheduledTest.TestAppointmentID == -1) ? false : true;
            
            int TestID = ctrlScheduledTest.TestID;
            if (TestID != -1)
            {
                _Test = clsTest.Find(TestID);
                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtNotes.Text = _Test.Notes;
                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
                _Test = new clsTest();
        } 

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change\n the Pass/Fail result after you save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                guna2btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data dont save successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
