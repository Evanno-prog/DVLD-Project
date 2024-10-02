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

            using (frmListPeople managePeople = new frmListPeople())
            {
                managePeople.ShowDialog();
            }                
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (Manage_Users frm = new Manage_Users())
            {
                frm.ShowDialog();
            } 
           
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmUserInfo frm = new frmUserInfo(clsGlobalSettings.CurrentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmChangePassword frm = new frmChangePassword(clsGlobalSettings.CurrentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentUser = null;
           
            using (LoginScreen frm = new LoginScreen())
            {
                frm.ShowDialog();
            }
            this.Close();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Manage_Application_Types frm = new Manage_Application_Types())
            {
                frm.ShowDialog();
            }   
                
             
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ManageTestTypes frm = new ManageTestTypes())
            {
                frm.ShowDialog();   
            }  
            
         
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

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (New_International_License_Application frm = new New_International_License_Application())
            {
                frm.ShowDialog();
            }
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListInternationalDrivingLicenseApplication frm = new ListInternationalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RenewLocalDrivingLicense frm = new RenewLocalDrivingLicense())
            {
                frm.ShowDialog();
            }
        }

        private void replacmentForLostOrDamegedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReplacementForDamageOrLostLicense frm = new ReplacementForDamageOrLostLicense())
            {
                frm.ShowDialog();
            }
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListLocalDrivingLicenseApplication frm = new ListLocalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Detain_License frm = new Detain_License())
            {
                frm.ShowDialog();
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReleaseDetainedLicense frm = new ReleaseDetainedLicense())
            {
                frm.ShowDialog();
            }
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListDetainedLicensesManagement frm = new ListDetainedLicensesManagement())
            {
                frm.ShowDialog();
            }
        }
    }
}
