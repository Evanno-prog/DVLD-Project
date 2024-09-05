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

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ListDetainedLicensesManagement : Form
    {
        public ListDetainedLicensesManagement()
        {
            InitializeComponent();
        }

        private void _RefreshListDetainedLicenses()
        {
            DataView dv = clsDetainedLicense.GetAllDetainedLicenses().DefaultView;
            dataGridView1.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }
          
        private void _LoadData()
        {
            _RefreshListDetainedLicenses();
            cbFilterDetainedLicenses.SelectedIndex = 0;
        }

        private void ListDetainedLicensesManagement_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PersonInfoScreen frm = new PersonInfoScreen(clsDriver.Find(clsLicense.Find((int)dataGridView1.CurrentRow.Cells[1].Value).DriverID).PersonID)) 
            {
                frm.ShowDialog();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (ShowLicenseInfo frm = new ShowLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value))
            {
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LicenseHistory frm = new LicenseHistory(clsLicense.Find((int)dataGridView1.CurrentRow.Cells[1].Value).ApplicationID))
            {
                frm.ShowDialog();
            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            using (Detain_License frm = new Detain_License())
            {
                frm.ShowDialog();
            }
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            using (ReleaseDetainedLicense frm = new ReleaseDetainedLicense())
            {
                frm.ShowDialog();
            }
        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmsDetainedLicenseManagement_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value)) ? false : true;  
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReleaseDetainedLicense frm = new ReleaseDetainedLicense())
            {
                int LicenseID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[1].Value);
                frm.SetValueTotxtLicenseID(LicenseID.ToString());
                
                frm.ShowDialog();
            }
        }
    }
}
