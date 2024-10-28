using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer.Applications.LocalDrivingLicense
{
    public partial class frmLocalDrivingApplicationInfo : Form
    {
        private int _LocalDrivingApplicationID = -1;
        public frmLocalDrivingApplicationInfo(int LocalDrivingApplicationID)
        {
            InitializeComponent();
            _LocalDrivingApplicationID = LocalDrivingApplicationID;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingApplicationID);
        }

    }
}
