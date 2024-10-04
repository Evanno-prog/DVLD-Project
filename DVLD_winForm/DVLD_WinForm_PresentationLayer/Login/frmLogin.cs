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

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = clsUser.FindByUsernameAndPassword(guna2txtUserName.Text.Trim(), guna2txtPassword.Text.Trim());
            if (User != null)
            {
                //incase the user is not active
                if (!User.IsActive)
                {
                    MessageBox.Show("This User is Not active! Contact your admin", "User in active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chkRememberMe.Checked)
                {
                //  Store username and password
                    clsGlobal.RememberUsernameAndPassword(guna2txtUserName.Text.Trim(), guna2txtPassword.Text.Trim());
                }
                else
                {
                    // Store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                clsGlobal.CurrentUser = User;
                this.Hide();
                using (frmMain frm = new frmMain(this))
                {
                    frm.ShowDialog();
                }

            }
            else
            {
                guna2txtUserName.Focus();
                MessageBox.Show("Invalid UserName/Password!", "Wrong credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                guna2txtUserName.Text = UserName;
                guna2txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

    }
}
