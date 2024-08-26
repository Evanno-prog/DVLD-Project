using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ManagePeople managePeople = new ManagePeople();
           
                managePeople.MdiParent = this;
                managePeople.Show();
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Users frm = new Manage_Users();
            frm.MdiParent = this;
            frm.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserInfoScreen frm = new UserInfoScreen(clsGlobalSettings.CurrentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePassword frm = new ChangePassword(clsGlobalSettings.CurrentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentUser = null;
            this.Close();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Application_Types frm = new Manage_Application_Types();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes frm = new ManageTestTypes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewLocalDrivingLicenseApplication frm = new NewLocalDrivingLicenseApplication(-1))
            {
               
                frm.ShowDialog();
            }
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListLocalDrivingLicenseApplication frm = new ListLocalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListDrivers frm = new ListDrivers())
            {
                frm.ShowDialog();
            }
        }
    }
}
