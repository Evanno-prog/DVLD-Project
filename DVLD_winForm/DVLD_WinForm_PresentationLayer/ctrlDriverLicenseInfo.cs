using DVLD_BussinessLayer;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using DVLD_WinForm_PresentationLayer.Properties;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private int _LicenseID = -1;
        private clsLicense _License = null;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        {
            get { return _License; } 
        }

        private void _LoadPersonImage()
        {

            if (_License.DriverInfo.PersonInfo.Gendor == 0)
            {
                pbPersonImage.Image = Resources.Male_512;
                pbGendor.Image = Resources.Man_32;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_512;
                pbGendor.Image = Resources.Woman_32;
            }

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblLicenseClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text =
            clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();

        }
    }
}
