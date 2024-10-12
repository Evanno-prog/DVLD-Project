using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _LoadData()
        {

            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);
            lblFeesApp.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;
        }

        private void guna2btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update) 
            {
                guna2btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLoginInformation.SelectedTab = tcLoginInformation.TabPages[1];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                guna2btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLoginInformation.SelectedTab = tcLoginInformation.TabPages[1];
            }
            else
            {
                MessageBox.Show("Please select a person","Select a person",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillLicenseClassInComboBox()
        {
            DataTable dtLicenseClass = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow Row in dtLicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(Row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {

            _FillLicenseClassInComboBox();

            if (_Mode == enMode.AddNew)
            {
                tpApplicationInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                cbLicenseClass.SelectedIndex = 2;
                lblFeesApp.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                tpApplicationInfo.Enabled = true;
                guna2btnSave.Enabled = true;
            }

            this.Text = lblTitle.Text = ((_Mode == enMode.AddNew) ? "Add New" : "Update") + " Local driving license application";
        }

        private void NewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

   
        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            int LicenseClassID = cbLicenseClass.SelectedIndex + 1;
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            if (clsLicenseClass.IsPersonAgeValidToApplyForThisLicenseClass(_SelectedPersonID,LicenseClassID))
            {
                MessageBox.Show("Choose another License Class, Person age is not valid for this license class", "Age not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
            {
                MessageBox.Show("Person already has a License with the same applied license class.\nChoose another LicenseClass:", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFeesApp.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (_LocalDrivingLicenseApplication.Save())
            {
                lblLDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                this.Text = lblTitle.Text = "Update local driving license application";
                MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmNewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {

            clsPerson Person = clsPerson.Find(PersonID);
            if (Person == null)
            {
                MessageBox.Show($"Selected person is not found With ID = {PersonID}");
                return;
            }

            if (clsUser.isUserExistForPersonID(PersonID))
            {
                MessageBox.Show($"Sorry: This person is a User in the system = {PersonID}");
                return;
            }

            _SelectedPersonID = PersonID;
        }
    }
}
