using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private clsApplication _Application;
        private int _ApplicationID = -1;
        public int ApplicationID 
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;
            lblAppID.Text = "[???]";
            lblApplicationStatus.Text = "[???]";
            lblApplicationFees.Text = "[???]";
            lblApplicationTypes.Text = "[???]";
            lblApplicantPerson.Text = "[???]";
            lblApplicationDate.Text = "[???]";
            lblApplicationStatusDate.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblAppID.Text = _Application.ApplicationID.ToString();
            lblApplicationStatus.Text = _Application.StatusText;
            lblApplicationFees.Text = _Application.PaidFees.ToString();
            lblApplicationTypes.Text = _Application.ApplicationTypeInfo.Title;
            lblApplicantPerson.Text = _Application.PersonInfo.FullName;
            lblApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblApplicationStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {

            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                MessageBox.Show($"No Application with ID = {ApplicationID} Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetApplicationInfo();

            }
            else
                _FillApplicationInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID))
            {
                frm.ShowDialog();
            }
            // Refresh
            LoadApplicationInfo(ApplicationID);
        }
    }
}
