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
    public partial class LicenseHistory : Form
    {
        private int _ApplicationID = 0;
 
        public LicenseHistory(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }

        private void _RefreshLocalLicenseHistory()
        {
            //DataView dv = clsLicense.GetAllLocalLicenseHistoryByDriverID(clsDriver.FindDriverByPersonID(clsApplication.Find(_ApplicationID).ApplicantPersonID).DriverID).DefaultView;
            //dgvLocalLicensesHistory.DataSource = dv;
            //lblRecordCount.Text = dv.Count.ToString();
        }

        private void _RefreshInternationalLicenseHistory()
        {

            //DataView Dv = clsInternationalLicense.GetAllInternationalLicenseHistoryByDriverID(clsDriver.FindDriverByPersonID(clsApplication.Find(_ApplicationID).ApplicantPersonID).DriverID).DefaultView;
            //dgvInternationalLicensesHistory.DataSource = Dv;
            //lblCountInterRecord.Text = Dv.Count.ToString();

        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            _RefreshLocalLicenseHistory();

            _RefreshInternationalLicenseHistory();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowLicenseDetails_Click(object sender, EventArgs e)
        {
            using (frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }
    }
}
