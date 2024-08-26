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
    public partial class ctrlFilterByDriverLicenseInfo : UserControl
    {
        public ctrlFilterByDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlFilterByDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnFindLicenseID_Click(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadDriverLiceseInfo(Convert.ToInt16(txtLicenseID.Text));
        }
    }
}
