using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmAddEditUser : Form
    {

        enum enMode {AddNew = 0, Update = 1}
        private enMode _Mode = enMode.AddNew;

        private int _UserID = -1;
        private clsUser _User = null;

        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void guna2btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                guna2btnSave.Enabled = tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages[1];
                return;
            }

            //Incase of add new mode.
            if (ctrlPersonCardWithFilter.PersonID != -1)
            {
                if (clsUser.isUserExistForPersonID(ctrlPersonCardWithFilter.PersonID)) 
                {
                    MessageBox.Show("Selected Person already has user in the system!\nChoose another one", "Choose another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter.FilterFocus();
                }
                else
                {
                    guna2btnSave.Enabled = tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages[1];
                }
             
            }
            else
            {
                MessageBox.Show("Please select the exist person","Select a person",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ctrlPersonCardWithFilter.FilterFocus();
            }
      
        }

        private void _ResetDefaultValues()
        {

            //This will initialize the reset defaule values

            if (_Mode == enMode.AddNew)
            {
                lblAddEditUser.Text = "Add New User";
                this.Text = lblAddEditUser.Text;
                _User = new clsUser();
                guna2btnSave.Enabled = tpLoginInfo.Enabled = false;
                ctrlPersonCardWithFilter.FilterFocus();
            }
            else
            {
                lblAddEditUser.Text = "Update User";
                this.Text = lblAddEditUser.Text;
                guna2btnSave.Enabled = tpLoginInfo.Enabled = true;
            }

            txtUserName.Text = "???";
            txtPassword.Text = "???";
            txtConfirmPassword.Text = "???";
            chkIsActive.Checked = true;
        }
       
        private void _LoadData()
        {

            _User = clsUser.FindByUserID(_UserID);
            ctrlPersonCardWithFilter.FilterEnabled = false;
            if (_User == null)
            {
                MessageBox.Show($"No User with ID = {_UserID}", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //The following code will not be executed if the person was not found :-)

            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter.LoadPersonInfo(_User.PersonID);
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This field cannot be blank");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtUserName, null);

            if (_Mode == enMode.AddNew)
            {
                 if (clsUser.isUserExist(txtUserName.Text)) 
                 {
                     errorProvider1.SetError(txtUserName, "UserName is used by another User\nEnter New user name?");
                     e.Cancel = true;
                 }
                 else
                    errorProvider1.SetError(txtUserName, null);

            }
            else
            {
                //incase update make sure not to use anothers user name :-)

                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        errorProvider1.SetError(txtUserName, "UserName is used by another User\nEnter New user name?");
                        e.Cancel = true;
                    }
                    else
                        errorProvider1.SetError(txtUserName, null);
                }
            }
           
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!\nPut the mouse over the red icon(s) to see the error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserName = txtUserName.Text.Trim();
            string salt = clsUtil.GenerateSalt();
            string HashPasswordWithSalt = clsUtil.HashPasswordWithSalt(txtPassword.Text.Trim(), salt);
            _User.Password = HashPasswordWithSalt;
            _User.PersonID = ctrlPersonCardWithFilter.PersonID;
            _User.IsActive = chkIsActive.Checked;
            _User.Salt = salt;
            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //Change form mode to update.
                _Mode = enMode.Update;
                lblAddEditUser.Text = "Update user";
                this.Text = lblUserID.Text;
                MessageBox.Show("Data saved succfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "This field cannot be blank");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtPassword, "Password confirmation does not match the password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtPassword, null);

        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter.FilterFocus();
        }
    }
}
