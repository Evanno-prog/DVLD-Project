using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
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

    public partial class IssueDriverLicenseForFirstTime : Form
    {
        private int _LDLApplicationID = 0;
        private clsApplication _Application = null;
        private clsLicenseClass _LicenseClass = null;
        private clsDriver _Driver = new clsDriver();
        private clsLicense _License = new clsLicense();

        public IssueDriverLicenseForFirstTime(int lDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = lDLApplicationID;
            //_Application = clsApplication.Find(clsLocalDrivingLicenseApplication.Find(_LDLApplicationID).ApplicationID);
            //_LicenseClass = clsLicenseClass.Find(clsLocalDrivingLicenseApplication.Find(_LDLApplicationID).LicenseClassID);

        }

        private void IssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            //ctrlL_D_L_ApplicationInfo1.LoadApplicationInfoData(_LDLApplicationID);
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            _Driver = clsDriver.FindDriverByPersonID(_Application.ApplicantPersonID);
            
            if (_Driver == null)
            {
                _Driver = new clsDriver();
                _Driver.PersonID = _Application.ApplicantPersonID;
                _Driver.CreatedDate = DateTime.Now;
                _Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _Driver.Save();
            }
          
            
            _License.ApplicationID = _Application.ApplicationID;
            _License.DriverID = _Driver.DriverID;
            _License.LicenseClass = _LicenseClass.LicenseClassID;
            _License.Notes = (txtNotes.Text != "") ? txtNotes.Text : DBNull.Value.ToString();
            //_License.PaidFees = _Application.PaidFees;
            _License.IsActive = true;
            _License.IssueReason = 1;
            _License.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = DateTime.Now.AddYears(_LicenseClass.DefaultValidityLength);

            if (_License.Save())
            {
                MessageBox.Show($"License Issued Successfully with License ID = {_License.LicenseID}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //_Application.ApplicationStatus = 3;
                _Application.LastStatusDate = DateTime.Now;
                _Application.Save();
                Close();
            }
            else
                MessageBox.Show("Data not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
