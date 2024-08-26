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

            DataView dv = clsLicense.GetLocalLicenseHistoryByLicenseID(clsLicense.FindLicenseInfoByApplicationID(_ApplicationID).LicenseID).DefaultView;
            dgvLocalLicensesHistory.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();

        }

        private void _RefreshInternationalLicenseHistory()
        {

            DataView Dv = clsLicense.GetInternationalLicenseHistoryByLicenseID(clsLicense.FindLicenseInfoByApplicationID(_ApplicationID).LicenseID).DefaultView;
            dgvInternationalLicensesHistory.DataSource = Dv;
            lblCountInterRecord.Text = Dv.Count.ToString();

        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonInformationFindBy1.IsEnableGbFilter(false);
            ctrlPersonInformationFindBy1.LoadPersonInfoByPersonID(clsApplication.Find(_ApplicationID).ApplicantPersonID);
            _RefreshLocalLicenseHistory();

            _RefreshInternationalLicenseHistory();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
