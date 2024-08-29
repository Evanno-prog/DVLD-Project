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

    public partial class InternationalDriverInfo : Form
    {

        private int _IntLicenseID = 0;
    
        public InternationalDriverInfo(int IntLicenseID)
        {
            InitializeComponent();
            _IntLicenseID = IntLicenseID;
        }

       

        private void InternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadInternationalLicenseInfo(_IntLicenseID);
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
