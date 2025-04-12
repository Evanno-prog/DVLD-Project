using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private byte _CountFailedLogin = 3;

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = clsUser.FindByUsernameAndPassword(guna2txtUserName.Text.Trim(), guna2txtPassword.Text.Trim());
            if (User != null)
            {
                //Incase the user is not active
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
                _CountFailedLogin--;
                MessageBox.Show($"Invalid UserName/Password! you have ({_CountFailedLogin}) Trial(s) before luck your account.", "Wrong credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_CountFailedLogin == 0)
                {
                    MessageBox.Show("Account locked after 3 failed trails.\nContact system administration to unlock your account", "Wrong credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2btnLogin.Enabled = false;
                    // Specify the source name for the event log
                    string sourceName = "DVLD";
                    // Create the event source if it does not exist
                    if (!EventLog.SourceExists(sourceName))
                    {
                        EventLog.CreateEventSource(sourceName, "Application");
                    }
                    // Log an information event
                    EventLog.WriteEntry(sourceName, "Account locked after 3 failed trails. Contact system administration to unlock your account", EventLogEntryType.Error);

                }
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

        private void pbShowHidePassword_Click(object sender, EventArgs e)
        {
            if (guna2txtPassword.PasswordChar == '*')
            {
                pbShowHidePassword.Image = Properties.Resources.visible;
                guna2txtPassword.PasswordChar = '\0';
            }
            else
            {
                pbShowHidePassword.Image = Properties.Resources.hide;
                guna2txtPassword.PasswordChar = '*';
            }
        }
    }
}
