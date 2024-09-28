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
    public partial class ListInternationalDrivingLicenseApplication : Form
    {
        public ListInternationalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _RefreshListIntLicenses()
        {
            DataView dv = clsInternationalLicense.GetAllInternationalLicenses().DefaultView;
            dgvListIntLicenses.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }

        private void ListInternationalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshListIntLicenses();
        }


        private void btnAddIntLicnese_Click(object sender, EventArgs e)
        {
            using (New_International_License_Application frm = new New_International_License_Application())
            {
                frm.ShowDialog();
            }
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFilterString_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilterNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo(clsApplication.Find((int)dgvListIntLicenses.CurrentRow.Cells[1].Value).ApplicantPersonID))
            {
                frm.ShowDialog();
            }
        }

        private void ShowLicenseDetails_Click(object sender, EventArgs e)
        {
            using (InternationalDriverInfo frm = new InternationalDriverInfo((int)dgvListIntLicenses.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LicenseHistory frm = new LicenseHistory((int)dgvListIntLicenses.CurrentRow.Cells[1].Value))
            {
                frm.ShowDialog();
            }
        }
    }
}
