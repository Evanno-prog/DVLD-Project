using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{

    public partial class frmShowInternationalLicencesInfo : Form
    {

        private int _InternationalLicenseID = 0;

        public frmShowInternationalLicencesInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void InternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
