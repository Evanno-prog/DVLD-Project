﻿using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Applications.International_License;
using DVLD_WinForm_PresentationLayer.Global_Classes;
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
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
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
            using (frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmListApplicationTypes frm = new frmListApplicationTypes())
            {
                frm.ShowDialog();
            }   
                
             
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmListTestTypes frm = new frmListTestTypes())
            {
                frm.ShowDialog();   
            }  
            
         
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmListLocalDrivingLicenseApplication frm = new frmListLocalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmListDrivers frm = new frmListDrivers())
            {
                frm.ShowDialog();
            }
        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmListInternationalDrivingLicenseApplication frm = new frmListInternationalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense())
            {
                frm.ShowDialog();
            }
        }

        private void replacmentForLostOrDamegedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmReplacementForDamageOrLostLicenseApplication frm = new frmReplacementForDamageOrLostLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmListLocalDrivingLicenseApplication frm = new frmListLocalDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmDetainLicense frm = new frmDetainLicense())
            {
                frm.ShowDialog();
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication())
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

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clsGlobal.CurrentUser != null)
                Application.Exit();
        }
    }
}
