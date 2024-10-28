using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Applications.LocalDrivingLicense;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmListLocalDrivingLicenseApplication : Form
    {

        private DataTable _dtGetAllLocalDrivingLicenseApplication;


        public frmListLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
    
        private void ListLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtGetAllLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplication.DataSource = _dtGetAllLocalDrivingLicenseApplication;
            lblRecordCount.Text = dgvLocalDrivingLicenseApplication.Rows.Count.ToString();
         
            if (dgvLocalDrivingLicenseApplication.Rows.Count > 0) 
            {

                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText = "L.D.L.AppID";  
                dgvLocalDrivingLicenseApplication.Columns[0].Width = 120;
       
                dgvLocalDrivingLicenseApplication.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplication.Columns[1].Width = 230;
               
                dgvLocalDrivingLicenseApplication.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplication.Columns[2].Width = 95;
              
                dgvLocalDrivingLicenseApplication.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplication.Columns[3].Width = 200;
             
                dgvLocalDrivingLicenseApplication.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplication.Columns[4].Width = 145;
            
                dgvLocalDrivingLicenseApplication.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplication.Columns[5].Width = 100;

                dgvLocalDrivingLicenseApplication.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplication.Columns[6].Width = 50;


            }

        }

        private void btnAddNewLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            using (frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            //  Refresh
            ListLocalDrivingLicenseApplication_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLocalDrivingApplicationInfo frm = new frmLocalDrivingApplicationInfo((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value)) 
            {
                frm.ShowDialog();
            }
            //  Refresh
            ListLocalDrivingLicenseApplication_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This funcation is not ready", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _ScheduleTest(clsTestType.enTestType TestType)
        {
            using (frmListTestAppointments frm = new frmListTestAppointments((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, TestType)) 
            {
                frm.ShowDialog();
            }
            ListLocalDrivingLicenseApplication_Load(null, null);
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This funcation is not ready", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void IssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This funcation is not ready", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CMSManageApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled Only if person passed all tests and Does not have license. 
            IssueDrivingLicenseFirstTime.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            scheduletestMenue.Enabled = !LicenseExists;

            // Enable/Disable Cancel Menue Item
            // We only cancel the applications with status = new.
            CancelApp.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);


            //Enable / Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            scheduletestMenue.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (scheduletestMenue.Enabled)
            {

                //To Allow Schdule vision test, Person must not passed the same test before.
                sechduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                sechduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                sechduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This funcation is not ready", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbFilterApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterValue.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtGetAllLocalDrivingLicenseApplication.DefaultView.RowFilter = "";
            lblRecordCount.Text = dgvLocalDrivingLicenseApplication.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //We allow only number incase L.D.L.AppID is selected.
            if (cbFilterValue.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterValue.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtGetAllLocalDrivingLicenseApplication.DefaultView.RowFilter = "";
                lblRecordCount.Text = dgvLocalDrivingLicenseApplication.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                _dtGetAllLocalDrivingLicenseApplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtGetAllLocalDrivingLicenseApplication.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordCount.Text = dgvLocalDrivingLicenseApplication.Rows.Count.ToString();

        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            if (LDLApplication != null)
            {
              
                if (LDLApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh the form again.
                    ListLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            ListLocalDrivingLicenseApplication_Load(null, null);
            
        }

        private void CancelApp_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
            clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    ListLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
