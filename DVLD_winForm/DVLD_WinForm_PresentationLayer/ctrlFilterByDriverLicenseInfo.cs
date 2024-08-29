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
    public partial class ctrlFilterByDriverLicenseInfo : UserControl
    {
        public ctrlFilterByDriverLicenseInfo()
        {
            InitializeComponent();
        }

        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseIDSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }


        private void btnFindLicenseID_Click(object sender, EventArgs e)
        {

            if (!clsLicense.isLicenseExist(Convert.ToInt16(txtLicenseID.Text)))
            {
                MessageBox.Show("LicenseID does not Exist!","Not found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            ctrlLicenseInfo1.LoadDriverLiceseInfo(Convert.ToInt16(txtLicenseID.Text));



            if (OnLicenseSelected != null)
                // Raise the event with a parameter
                LicenseIDSelected(Convert.ToInt16(txtLicenseID.Text));
        }

        public void IsgbFilterByLicenseIDEnabled(bool IsEnable = true)
        {
            gbFilterByLicenseID.Enabled = IsEnable;
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtLicenseID_TextChanged(object sender, EventArgs e)
        {
            btnFindLicenseID.Enabled = (string.IsNullOrEmpty(txtLicenseID.Text)) ? false : true;
        }
    }
}
