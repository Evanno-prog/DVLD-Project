using DVLD_BussinessLayer;
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
    public partial class AddEditUser : Form
    {
        private int _UserID = -1;
        enum enMode { AddNew,Update }
        enMode _Mode = enMode.AddNew;
        
        clsUser _User = null;
        public AddEditUser(int User_id)
        {
            InitializeComponent();
            _UserID = User_id;

            if (_UserID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
            
        }

        private void _LoadData()
        {

            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();
                this.Text = "Add New User";
                lblAddEditUser.Text = "Add New User";
                guna2btnNext.Enabled = true;
                return;
            }


            guna2btnNext.Enabled = false;
            this.Text = "Update User";
            lblAddEditUser.Text = "Update User";
            lblUserID.Text = _UserID.ToString();
            _User = clsUser.Find(_UserID);
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
        }


        private void guna2btnNext_Click(object sender, EventArgs e)
        {


        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void AddEditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This field is required");
                txtUserName.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
                e.Cancel = false;
            }

        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Some fields are not valid!\nTry Again", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Sorry! your password is not match!\nTry Again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = (chkIsActive.Checked) ? true : false;

            if (_User.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblAddEditUser.Text = "Update User";
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
            }
            else
                MessageBox.Show("Data Saved failed :-(", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This field is required");
                txtPassword.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

          

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "This field is Required");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(txtConfirmPassword.Text,txtPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not Match the Password!");
                txtConfirmPassword.Focus();
            }
            else { errorProvider1.SetError(txtConfirmPassword, ""); }
        }
    }
}
