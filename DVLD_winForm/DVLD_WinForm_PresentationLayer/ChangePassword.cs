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
    public partial class ChangePassword : Form
    {

        private int _UserID = 0;
        clsUser _User = null;
        public ChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;   
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text) || (txtCurrentPassword.Text != _User.Password))
            {
                MessageBox.Show("Some fields are not valid!\nTry Again", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Sorry! your password is not match!\nTry Again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            _User.Password = txtPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPassword.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
            else
                MessageBox.Show("Data Saved failed :-(", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);
            ctrlUserInformation1.LoadUserInfoData(_User.UserID);
            txtCurrentPassword.Focus();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "This field is Required!");
                e.Cancel = true;
                txtCurrentPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
                e.Cancel = false;
            }


            if (txtCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, "The current password is not valid\nPlease try again!");
                e.Cancel = true;
                txtCurrentPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
                e.Cancel = false;
            }


        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This field is Required!");
                e.Cancel = true;
                txtPassword.Focus();
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
                errorProvider1.SetError(txtConfirmPassword, "This field is Required!");
               
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
                
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(txtConfirmPassword.Text, txtPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not Match the Password!");
                txtConfirmPassword.Focus();
            }
            else { errorProvider1.SetError(txtConfirmPassword, ""); }
        }
    }
}
