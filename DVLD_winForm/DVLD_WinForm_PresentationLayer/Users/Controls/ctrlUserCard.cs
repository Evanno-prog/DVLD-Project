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
    public partial class ctrlUserCard : UserControl
    {

        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }

        private clsUser _User = null;

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetUserInfo()
        {
            ctrlPersonCard.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }

        private void _FillUserInfo()
        {
            ctrlPersonCard.LoadPersonInfo(_User.PersonID);
            lblUserName.Text = _User.UserName;
            lblUserID.Text = _User.UserID.ToString();
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show($"Can not find User with UserID {UserID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
            
        }

    }
}
