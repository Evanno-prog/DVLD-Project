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
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = clsUser.FindByUsernameAndPassword(guna2txtUserName.Text, guna2txtPassword.Text);

            if (User == null)
            {
                MessageBox.Show("Invalid! UserName/Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (User.IsActive == false)
            {
                MessageBox.Show("Sorry! Your Account is DeActivated.\nPlease contact your Admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (chkRememberMe.Checked)
            {
                UserPersistenceManager.SaveUser(guna2txtUserName.Text, guna2txtPassword.Text);
            }
            else
            {
                UserPersistenceManager.DeleteSavedUser();
            }

            clsGlobalSettings.CurrentUser = User;

            using (Main frm = new Main()) 
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            guna2txtUserName.Text = UserPersistenceManager.LoadUser()?.username;
            guna2txtPassword.Text = UserPersistenceManager.LoadUser()?.password;
        }
    }
}
