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
    public partial class UserInfoScreen : Form
    {
        int _UserID = 0;
        public UserInfoScreen(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserInfoScreen_Load(object sender, EventArgs e)
        {
            ctrlUserInformation1.LoadUserInfoData(_UserID);
        }
    }
}
