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
namespace DVLD_WinForm_PresentationLayer
{
    public partial class NewLocalDrivingLicenseApplication : Form
    {

        private int _LocalDrivingLicenseID = 0;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsApplication _Application;
        enum enMode { AddNew,Update}
        enMode _Mode = enMode.AddNew;
        
        public NewLocalDrivingLicenseApplication(int localDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = localDrivingLicenseID;
            if (_LocalDrivingLicenseID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _FillLicenseClassInComboBox()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }
            cbLicenseClass.SelectedIndex = 0;
        }

        private string _GetLicenseClassName(int LicenseClassId)
        {

            switch (LicenseClassId)
            {
                case 1:
                    return "Class 1 - Small Motorcycle";
                case 2:
                    return "Class 2 - Heavy Motorcycle License";
                case 3:
                    return "Class 3 - Ordinary driving license";
                case 4:
                    return "Class 4 - Commercial";
                case 5:
                    return "Class 5 - Agricultural";
                case 6:
                    return "Class 6 - Small and medium bus";
                case 7:
                    return "Class 7 - Truck and heavy vehicle";

                default:
                    return "";
            }

        }

        private void _LoadData()
        {

            _FillLicenseClassInComboBox();

            lblDateNow.Text = DateTime.Now.ToString("d");
            lblFeesApp.Text = "15";
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;

            if (_Mode == enMode.AddNew)
            {
                _Application = new clsApplication();  
                _LocalDrivingLicenseApplication= new clsLocalDrivingLicenseApplication();
                return;
            }

            // Edit Application Code Will Be here :-)
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseID);
            _Application = clsApplication.Find(_LocalDrivingLicenseApplication.ApplicationID);
            guna2btnNext.Enabled = false;
            this.Text = lblTitle.Text = "Update Local driving license class";
            lblApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDateNow.Text = _Application.ApplicationDate.ToString("d");
            lblFeesApp.Text = Convert.ToInt16(_Application.PaidFees).ToString();
            lblCreatedBy.Text = clsUser.Find(_Application.CreatedByUserID).UserName;
            guna2btnSave.Enabled = true;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_GetLicenseClassName(_LocalDrivingLicenseApplication.LicenseClassID));
        }

        private void guna2btnNext_Click(object sender, EventArgs e)
        {
            if (!clsPerson.isPersonExist(2))
            {
                MessageBox.Show("Sorry! PersonID Or NationalNo is not exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsUser.IsUserPersonIdExist(4)) 
            {
                MessageBox.Show("Sorry! this Person info is a User Exist in the System\n Choose another Person", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl1.SelectedIndex = 1;
            guna2btnSave.Enabled = true;
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private int _GetLicenseClass()
        {

            switch (cbLicenseClass.Text)
            {
                case "Class 1 - Small Motorcycle":
                    return 1;
                case "Class 2 - Heavy Motorcycle License":
                    return 2;
                case "Class 3 - Ordinary driving license":
                    return 3;
                case "Class 4 - Commercial":
                    return 4;
                case "Class 5 - Agricultural":
                    return 5;
                case "Class 6 - Small and medium bus":
                    return 6;
                case "Class 7 - Truck and heavy vehicle":
                    return 7;

                default:
                    return 0;
            }

        }
   
        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            clsDriver Driver = clsDriver.FindDriverByPersonID(5);
            if (Driver != null)
            {
                int LicenseID = cbLicenseClass.SelectedIndex + 1;
                if (clsLicense.IsLicenseExistBySameAppliedLicenseClass(Driver.DriverID,LicenseID))
                {
                    MessageBox.Show("Person already has a license class with the same applied class\nChoose different driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (_Mode == enMode.AddNew)
            {
                _Application.ApplicationDate = DateTime.Now;
            }
            
            
            _Application.ApplicationTypeID = clsApplicationType.FindFees(15).ApplicationTypeID;
         
            if (_Mode == enMode.AddNew)
            {
                _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            }

            if (_Mode == enMode.AddNew)
            {
                _Application.ApplicationStatus = 1;
            }

            if (_Mode == enMode.AddNew)
            {
                _Application.LastStatusDate = DateTime.Now;
            }
           
            _Application.PaidFees = 15;


            // Check if the Old Applications of this Person already has the LicenseClass
            // that match the current LicenseClass Or Not!
            DataTable dt = clsApplication.GetListApplicationLicenseClassPersonId(_Application.ApplicantPersonID);
            int LicenseClassID = _GetLicenseClass();    
            foreach (DataRow DtRow in dt.Rows)
            {
                                                                                                            
                if ((Convert.ToInt16(DtRow["LicenseClassID"]) == LicenseClassID) && (Convert.ToInt16(DtRow["ApplicationStatus_id"]) == 1))
                {
                    MessageBox.Show($"Choose another LicenseClass,the selected person already\n have an active application for the selected class with id = {LicenseClassID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 

                if ((Convert.ToInt16(DtRow["LicenseClassID"]) == LicenseClassID) && (Convert.ToInt16(DtRow["ApplicationStatus_id"]) == 3))
                {
                    MessageBox.Show($"Choose another LicenseClass,the selected person already\n have an Complete application for the selected class with id = {LicenseClassID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        

            if (_Application.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTitle.Text = "Update Local Driving License Application";
                _Mode = enMode.Update;
                this.Text = lblTitle.Text;
               
                _LocalDrivingLicenseApplication.ApplicationID = _Application.ApplicationID;
                _LocalDrivingLicenseApplication.LicenseClassID = clsLicenseClass.Find(_GetLicenseClass()).LicenseClassID;
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("L.D.L Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString(); 
                }
                else { MessageBox.Show("L.D.L Not Saved","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Application Data Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
