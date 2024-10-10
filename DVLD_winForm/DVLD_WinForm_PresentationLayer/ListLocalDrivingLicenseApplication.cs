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
using DVLD_BussinessLayer;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ListLocalDrivingLicenseApplication : Form
    {

        public ListLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _RefereshApplicationList()
        {
            //DataView dv = clsApplication.GetAllApplications().DefaultView;
            //dataGridView1.DataSource = dv;
            //lblRecordCount.Text = dv.Count.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    
        private void _SetAvailableContextMenuStrip()
        {

            //DataTable CurrentApp = clsApplication.GetLocalApplications(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
            //foreach (DataRow dr in CurrentApp.Rows)
            //{

            //    int PassedTest = (int)dr["PassedTestCount"];

            //    if (PassedTest == 0)
            //    {
            //        sechduleVisionTestToolStripMenuItem.Enabled = true;
            //        sechduleWrittenTestToolStripMenuItem.Enabled = false;
            //        sechduleStreetTestToolStripMenuItem.Enabled = false;
            //        IssueDrivingLicenseFirstTime.Enabled = false;
            //        showLicenseToolStripMenuItem.Enabled = false;
            //        SechduleTests.Enabled = true;
            //    }
 
            //    else if (PassedTest == 1)
            //    {
            //        sechduleVisionTestToolStripMenuItem.Enabled = false;
            //        sechduleWrittenTestToolStripMenuItem.Enabled = true;
            //        sechduleStreetTestToolStripMenuItem.Enabled = false;
            //        IssueDrivingLicenseFirstTime.Enabled = false;
            //        showLicenseToolStripMenuItem.Enabled = false;
            //        SechduleTests.Enabled = true;

            //    }
            //    else if (PassedTest == 2)
            //    {
            //        sechduleVisionTestToolStripMenuItem.Enabled = false;
            //        sechduleWrittenTestToolStripMenuItem.Enabled = false;
            //        sechduleStreetTestToolStripMenuItem.Enabled = true;
            //        IssueDrivingLicenseFirstTime.Enabled = false;
            //        showLicenseToolStripMenuItem.Enabled = false;
            //        SechduleTests.Enabled = true;

            //    }
            //    else
            //    {
                   
            //        IssueDrivingLicenseFirstTime.Enabled = true;
            //        SechduleTests.Enabled = false;
            //        editToolStripMenuItem.Enabled = true;
            //        deleteToolStripMenuItem.Enabled = true;
            //        CancelApp.Enabled = true;

            //        if (dr["Status"].ToString() == "Completed")
            //        {
            //            editToolStripMenuItem.Enabled = false;
            //            deleteToolStripMenuItem.Enabled = false;
            //            CancelApp.Enabled = false;
            //            SechduleTests.Enabled = false;
            //            IssueDrivingLicenseFirstTime.Enabled = false;
            //            showLicenseToolStripMenuItem.Enabled = true;
            //        }
            //    }

            //}
        }

        private void ListLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefereshApplicationList();
            cbFilterApplication.SelectedIndex = 0;
        }

        private void btnAddNewLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            using (frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication(-1))
            {
                frm.ShowDialog();
            }
            _RefereshApplicationList();
        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterApplication.Text)
            {

                case "None":
                    _RefereshApplicationList();
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = false;
                    return;
                case "L.D.LAppID":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    return;
                case "NationalNo":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "Full Name":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "Status":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;

            }

        }

        private void txtFilterString_TextChanged(object sender, EventArgs e)
        {
            //DataView dv = clsApplication.GetAllApplications().DefaultView;

            //if (string.IsNullOrEmpty(txtFilterString.Text))
            //{
            //    dataGridView1.DataSource = dv;
            //    lblRecordCount.Text = dv.Count.ToString();
            //    return;
            //}
            //else
            //{
            //    switch (cbFilterApplication.Text)
            //    {
            //        case "Full Name":
            //            dv.RowFilter = $"FullName = '{txtFilterString.Text}'";
            //            dataGridView1.DataSource = dv;
            //            lblRecordCount.Text = dv.Count.ToString();
            //            return;
            //        case "NationalNo":
            //            dv.RowFilter = $"NationalNo = '{txtFilterString.Text}'";
            //            dataGridView1.DataSource = dv;
            //            lblRecordCount.Text = dv.Count.ToString();
            //            return;
            //        case "Status":
            //            dv.RowFilter = $"Status = '{txtFilterString.Text}'";
            //            dataGridView1.DataSource = dv;
            //            lblRecordCount.Text = dv.Count.ToString();
            //            return;

            //    }
            //}

        }

        private void txtFilterNumber_TextChanged(object sender, EventArgs e)
        {
            //DataView dv = clsApplication.GetAllApplications().DefaultView;

            //if (string.IsNullOrEmpty(txtFilterNumber.Text))
            //{
            //    dataGridView1.DataSource = dv;
            //    lblRecordCount.Text = dv.Count.ToString();
            //    return;
            //}
            //else
            //{
            //    dv.RowFilter = $"L.D.L.Application = '{txtFilterNumber.Text}'";
            //    dataGridView1.DataSource = dv;
            //    lblRecordCount.Text = dv.Count.ToString();
            //    return;
            //}
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationInfoScreen frm = new ApplicationInfoScreen((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefereshApplicationList();
        }

        //private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //DataTable dt = clsApplication.GetLocalApplications((int)dataGridView1.CurrentRow.Cells[0].Value);
        //    //DataRow dr = dt.Rows[0];
        //    if (dr["Status"].ToString() == "Completed")
        //    {
        //        MessageBox.Show("Sorry! you cannot delete this Application, because it is status is completed");
        //        return;
        //    }

        //    if (MessageBox.Show("Are you sure you want to delete this Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
        //    {
        //        if (clsApplication.DeleteApplication((int)dataGridView1.CurrentRow.Cells[0].Value))
        //        {
        //            MessageBox.Show("Application Deleted succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            _RefereshApplicationList();
        //        }
        //        else
        //            MessageBox.Show("You can not delete this application, Because there is another data linked to it", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //        MessageBox.Show("The operation was cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //}

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{

        //    if (MessageBox.Show("Are you sure you want to cancel this Application?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
        //    {
        //        clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
        //        clsApplication App = clsApplication.Find(LDLApp.ApplicationID);
        //        App.ApplicationStatus = 2;
        //        App.LastStatusDate = DateTime.Now;
        //        if (App.Save())
        //        {
        //            MessageBox.Show("Application cancelled succfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            _RefereshApplicationList();
        //        }
        //        else
        //            MessageBox.Show("Failed to cancel application", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    else
        //        MessageBox.Show("Operation was cancelled", "Cancel Op", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AppointementsVisionTest frm = new AppointementsVisionTest((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefereshApplicationList();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Written_test_appointment frm = new Written_test_appointment((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefereshApplicationList();
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreetTestAppointment frm = new StreetTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefereshApplicationList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LicenseID = clsLicense.FindLicenseInfoByApplicationID(clsApplication.Find(clsLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID).ApplicationID).LicenseID;

            //using (ShowLicenseInfo frm = new ShowLicenseInfo(LicenseID))
            //{
            //    frm.ShowDialog();
            //}
        }

        private void IssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            using (IssueDriverLicenseForFirstTime frm = new IssueDriverLicenseForFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }

        private void CMSManageApplications_Opening(object sender, CancelEventArgs e)
        {
            _SetAvailableContextMenuStrip();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (LicenseHistory frm = new LicenseHistory(clsLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID))
            //{
            //    frm.ShowDialog();
            //}
        }
    }
}
