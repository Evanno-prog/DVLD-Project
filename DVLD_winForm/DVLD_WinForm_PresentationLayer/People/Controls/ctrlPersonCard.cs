using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1; 
        private clsPerson _Person = null;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        } 

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblName.Text = "[????]";
            pbGendor.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonPhoto.Image = Resources.Male_512;

        }

        private void _LoadPersonImage()
        {

            if (_Person.Gendor == 0)
            {
                pbGendor.Image = Resources.Man_32;
            }
            else
                pbGendor.Image = Resources.Woman_32;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonPhoto.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                _ResetDefaultValues();
                MessageBox.Show($"Could not found Person with ID = {_PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }
  
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                _ResetDefaultValues();
                MessageBox.Show($"Could not found Person with NationalNo = {NationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (AddEditPersoneInfo frm = new AddEditPersoneInfo(_PersonID))
            {
                frm.ShowDialog();     
            }

            // Refresh
            LoadPersonInfo(_PersonID);
        }
    }
}
