using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;
using System.IO;
using System.Diagnostics.Contracts;
using DVLD_WinForm_PresentationLayer.Properties;
using DVLD_WinForm_PresentationLayer.Global_Classes;
using Guna.UI2.WinForms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmAddEditPersoneInfo : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        enum enMode {Addnew, Update}
        enum enGender { Male = 0, Female = 1}
        private enMode _Mode = enMode.Addnew;
        private int _PersonID = -1;
        private clsPerson _Person = null;
        public frmAddEditPersoneInfo()
        {
            InitializeComponent();
            _Mode = enMode.Addnew;
        }
    
        public frmAddEditPersoneInfo(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            //this will initialize the reset the defaule values
            _FillCountriesInComboBox();
            if (_Mode == enMode.Addnew)
            {
                lblModeTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblModeTitle.Text = "Update Person";
            }

            //set default image for the person.
            if (rbMale.Checked)
                pbPhoto.Image = Resources.Male_512;
            else
                pbPhoto.Image = Resources.Female_512;
        
            //hide/show the remove linke incase there is no image for the person.
            llRemove.Visible = (pbPhoto.ImageLocation != null);
         
            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
         
            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
        
            //this will set default country to jordan.
            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");
            guna2txtFirstName.Text = "";
            guna2txtSecondName.Text = "";
            guna2txtThirdName.Text = "";
            guna2txtLastName.Text = "";
            guna2txtNationalNo.Text = "";
            rbMale.Checked = true;
            guna2txtPhone.Text = "";
            guna2txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //The following code will not be executed if the person was not found
            lblPersonID.Text = _PersonID.ToString();
            guna2txtFirstName.Text = _Person.FirstName;
            guna2txtSecondName.Text = _Person.SecondName;
            guna2txtThirdName.Text = _Person.ThirdName;
            guna2txtLastName.Text = _Person.LastName;
            guna2txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            guna2txtPhone.Text = _Person.Phone;
            guna2txtEmail.Text = _Person.Email;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);


            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                pbPhoto.ImageLocation = _Person.ImagePath;

            }
            else if (_Person.Gendor == 0)
                pbPhoto.Image = Properties.Resources.Male_512;
            else
                pbPhoto.Image = Properties.Resources.Female_512;

            //hide/show the remove linke incase there is no image for the person.
            llRemove.Visible = (_Person.ImagePath != "");

        }

        private void AddEditPersoneInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPhoto.ImageLocation = null;

            if (rbMale.Checked)
                pbPhoto.Image = Resources.Male_512;
            else
                pbPhoto.Image = Resources.Female_512;

            llRemove.Visible = false;   
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);
                llRemove.Visible = true;
                pbPhoto.Load(selectedFilePath);
                
            }
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPhoto.ImageLocation)
            {

                if (_Person.ImagePath != "")
                {
                    // First we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException iox)
                    {
                        MessageBox.Show(iox.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (pbPhoto.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPhoto.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPhoto.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {
         
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (!_HandlePersonImage())
                return;

            int NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;

            _Person.FirstName = guna2txtFirstName.Text.Trim();
            _Person.SecondName = guna2txtSecondName.Text.Trim();
            _Person.ThirdName = guna2txtThirdName.Text.Trim();
            _Person.LastName = guna2txtLastName.Text.Trim();
            _Person.NationalNo = guna2txtNationalNo.Text.Trim();
            _Person.Email = guna2txtEmail.Text.Trim();
            _Person.Phone = guna2txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGender.Male;
            else
                _Person.Gendor = (short)enGender.Female;

            _Person.NationalityCountryID = NationalityCountryID;

            if (pbPhoto.ImageLocation != null)
                _Person.ImagePath = pbPhoto.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblModeTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.
            if (pbPhoto.ImageLocation == null)
                pbPhoto.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to Female incase there is no image set.
            if (pbPhoto.ImageLocation == null)
                pbPhoto.Image = Resources.Female_512;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            if (sender is Guna2TextBox)
            {

                Guna2TextBox gunaTemp = (Guna2TextBox)sender;

                if (string.IsNullOrEmpty(gunaTemp.Text.Trim()))
                {
                     e.Cancel = true;
                     errorProvider1.SetError(gunaTemp, "This field is required!");
                }
                else
                {
                     //e.Cancel = false;
                     errorProvider1.SetError(gunaTemp, null);
                }
            }
            else
            {
                TextBox Temp = ((TextBox)sender);

                if (string.IsNullOrEmpty(Temp.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(Temp, "This field is required!");
                }
                else
                {
                    //e.Cancel = false;
                    errorProvider1.SetError(Temp, null);
                }
            }


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (guna2txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(guna2txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(guna2txtEmail, null);
            };

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(guna2txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(guna2txtNationalNo, null);
            }


            //Make sure the national number is not used by another person
            if (guna2txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(guna2txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(guna2txtNationalNo, null);
            }
        }


    }
}
