using DVLD_BussinessLayer;
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
    public partial class ApplicationInfoScreen : Form
    {
        private int _LDlApplicationID = 0;
        public ApplicationInfoScreen(int LDL_ApplicationID)
        {
            InitializeComponent();
            _LDlApplicationID = LDL_ApplicationID;
        }

        private void ApplicationInfoScreen_Load(object sender, EventArgs e)
        {
            ctrlL_D_L_ApplicationInfo1.LoadApplicationInfoData(_LDlApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
