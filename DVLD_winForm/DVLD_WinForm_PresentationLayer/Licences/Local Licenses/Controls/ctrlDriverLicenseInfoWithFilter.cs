using DVLD_Buisness;
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
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {

        public ctrlDriverLicenseInfoWithFilter()
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

        private int _LicenseID = -1;
        public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilteres.Enabled = _FilterEnabled;
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {

            txtLicenseID.Text = LicenseID.ToString();
      
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
            {
                LicenseIDSelected(_LicenseID);
            }

        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error: some fields are not valid, put the mouse over the red icon(s) to see the error","Validation error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }

            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "Required");
            }
            else
                errorProvider1.SetError(txtLicenseID, null);
        }
   
        public void txtLicenseIdFocus()
        {
            txtLicenseID.Focus();
        }
    }
}
