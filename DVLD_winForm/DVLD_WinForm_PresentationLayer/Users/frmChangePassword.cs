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
    public partial class frmChangePassword : Form
    {

        private int _UserID = -1;
        private clsUser _User = null;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();
            _User = clsUser.FindByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"User is not found with UserID = {_UserID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserInformation1.LoadUserInfo(_UserID);

        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! put the mouse over the red icon(s) to see the error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text.Trim();
            if (_User.ChangePassword())
            {
                MessageBox.Show("Password Changed succfully", "Changed succfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefaultValues();
            }
            else
                MessageBox.Show("An error occured while changing the password", "Password didnot change", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "This field is required");
                e.Cancel = true;
                return;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

            if (_User.Password != txtCurrentPassword.Text)
            {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is wrong!");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "This field is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "This field is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation does not match the password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }
    }
}
