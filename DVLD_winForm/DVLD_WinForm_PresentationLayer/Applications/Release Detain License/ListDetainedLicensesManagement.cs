using DVLD_BussinessLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ListDetainedLicensesManagement : Form
    {

        private DataTable _dtDetainedLicences;
        public ListDetainedLicensesManagement()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            using (frmDetainLicense frm = new frmDetainLicense())
            {
                frm.ShowDialog();
            }
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            using (frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void ListDetainedLicensesManagement_Activated(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void ListDetainedLicensesManagement_Load(object sender, EventArgs e)
        {

            _dtDetainedLicences = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _dtDetainedLicences;
            lblRecordCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
            if (dgvDetainedLicenses.Rows.Count > 0)
            {

                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;
                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmsDetainedLicenseManagement_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !((bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo(clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID))
            {
                frm.ShowDialog();
            }
            ListDetainedLicensesManagement_Load(null, null);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmShowLicenseInfo frm = new frmShowLicenseInfo(clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).LicenseID))
            {
                frm.ShowDialog();
            }
            ListDetainedLicensesManagement_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID))
            {
                frm.ShowDialog();
            }
            ListDetainedLicensesManagement_Load(null, null);
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).LicenseID))
            {
                frm.ShowDialog();
            }
            ListDetainedLicensesManagement_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "Is Released")
            {
                cbFilterIsReleased.Visible = true;
                txtFilterValue.Visible = false;
                cbFilterIsReleased.Focus();
                cbFilterIsReleased.SelectedIndex = 0;
                
            }

            else
            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbFilterIsReleased.Visible = false;

                if (cbFilterBy.Text == "None") 
                {
                    cbFilterIsReleased.Visible = false;
                    _dtDetainedLicences.DefaultView.RowFilter = "";
                    lblRecordCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
                }

                txtFilterValue.Text = "";
                txtFilterValue.Focus();

            }
        
        }

        private void cbFilterIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsReleased";
            string FilterValue = cbFilterIsReleased.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtDetainedLicences.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtDetainedLicences.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn, FilterValue);
            
            lblRecordCount.Text = dgvDetainedLicenses.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    };
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicences.DefaultView.RowFilter = "";
                lblRecordCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _dtDetainedLicences.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDetainedLicences.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
               
                lblRecordCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

    }
}
