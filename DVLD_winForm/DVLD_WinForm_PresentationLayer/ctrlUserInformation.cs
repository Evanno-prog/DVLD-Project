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
    public partial class ctrlUserInformation : UserControl
    {
        public ctrlUserInformation()
        {
            InitializeComponent();
        }

        public void SetTextToUserName_UserID_IsActive(string UserName, int UserID, bool IsActive)
        {
            lblUserName.Text = UserName;
            lblUserID.Text = UserID.ToString();
            lblIsActive.Text = (IsActive == true) ? "Yes" : "No";
        }

        public void LoadUserInfoData(int User_id)
        {
            clsUser User = clsUser.Find(User_id);
            ctrlPersonInformation1.LoadPersonInfoData(User.PersonID);
            lblUserName.Text = User.UserName;
            lblUserID.Text = User.UserID.ToString();
            lblIsActive.Text = (User.IsActive == true) ? "Yes" : "No";

        }
        private void ctrlUserInformation_Load(object sender, EventArgs e)
        {
            
        }
    }
}
