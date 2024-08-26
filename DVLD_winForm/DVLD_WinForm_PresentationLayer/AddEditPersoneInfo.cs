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

namespace DVLD_WinForm_PresentationLayer
{
    public partial class AddEditPersoneInfo : Form
    {
        enum enMode { AddNew,Update}
        private enMode _Mode;
        private int _Persone_id;
        private clsPersone _Person;

        public AddEditPersoneInfo(int PersonID)
        {

            InitializeComponent();
            _Persone_id = PersonID;

            if (_Persone_id == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;

        }

        public delegate void DataBackEventHandler(int PersonID);
        public DataBackEventHandler DataBack;


        private void _FillCountriesInCombobox()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }
            cbCountries.SelectedIndex = cbCountries.FindString("Syria");
        }

        private void _LoadData()
        {

            _FillCountriesInCombobox();
           
            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPersone();
                return;
            }

            _Person = clsPersone.Find(_Persone_id);
            guna2txtFirstName.Text = _Person.FirstName; 
            guna2txtSecondName.Text = _Person.SecondName;
            guna2txtThirdName.Text = (_Person.ThirdName != null) ? _Person.ThirdName : "";
            guna2txtLastName.Text = _Person.LastName;
            guna2txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            guna2txtPhone.Text = _Person.Phone;
            guna2txtEmail.Text = (_Person.Email != null) ? _Person.Email : "";
            txtAddress.Text = _Person.Address;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_Person.ImagePath != null)
                pbPhoto.Load(_Person.ImagePath);
            else
                pbPhoto.ImageLocation = null;

            llRemove.Visible = (_Person.ImagePath == null) ? false : true;

            cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

            lblModeTitle.Text = "Update Person";
            lblPersonID.Text = _Persone_id.ToString();
        }

        private void AddEditPersoneInfo_Load(object sender, EventArgs e)
        {
            DateTime Today = DateTime.Now;
            DateTime E18 = Today.AddYears(-18);
            dtpDateOfBirth.MaxDate = E18;
            _LoadData();
        }

        private void guna2txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2txtFirstName.Text))
            {

                e.Cancel = true;
                guna2txtFirstName.Focus();
                errorProvider1.SetError(guna2txtFirstName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(guna2txtFirstName, "");
            }

        }

        private void guna2txtSecondName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(guna2txtSecondName.Text))
            {

                e.Cancel = true;
                guna2txtSecondName.Focus();
                errorProvider1.SetError(guna2txtSecondName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(guna2txtSecondName, "");
            }

        }

        private void guna2txtLastName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(guna2txtLastName.Text))
            {

                e.Cancel = true;
                guna2txtLastName.Focus();
                errorProvider1.SetError(guna2txtLastName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(guna2txtLastName, "");
            }
        }

        private void guna2txtPhone_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(guna2txtPhone.Text))
            {

                e.Cancel = true;
                guna2txtPhone.Focus();
                errorProvider1.SetError(guna2txtPhone, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(guna2txtPhone, "");
            }

        }

        private void guna2txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(guna2txtNationalNo.Text))
            {

                e.Cancel = true;
                guna2txtNationalNo.Focus();
                errorProvider1.SetError(guna2txtNationalNo, "Required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(guna2txtNationalNo, "");
               
            }

            if (clsPersone.IsNationalNoExist(guna2txtNationalNo.Text))
            {

                e.Cancel = true;
                guna2txtNationalNo.Focus();
                errorProvider1.SetError(guna2txtNationalNo, "NationalNo is used for another person");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(guna2txtNationalNo, "");
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPhoto.Load("D:\\Rel_Schema for DVLD\\ICONS\\Male 512.png");
            }
            else
                pbPhoto.Load("D:\\Rel_Schema for DVLD\\ICONS\\Female 512.png");

        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(guna2txtEmail.Text))
            {
                //string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                string EmPattern = @"@gmail.com";
                if (!Regex.IsMatch(guna2txtEmail.Text, EmPattern)) 
                {
                    e.Cancel = true;
                    guna2txtEmail.Focus();
                    errorProvider1.SetError(guna2txtEmail, "Please enter a valid email address.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(guna2txtEmail, "");
                }
                
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPhoto.ImageLocation = null;
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

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(guna2txtFirstName.Text) || string.IsNullOrEmpty(guna2txtSecondName.Text) || string.IsNullOrEmpty(guna2txtLastName.Text) || string.IsNullOrEmpty(guna2txtNationalNo.Text) || string.IsNullOrEmpty(guna2txtPhone.Text) || string.IsNullOrEmpty(txtAddress.Text)) 
            {
                MessageBox.Show("Some fields are not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int CountryID = clsCountry.Find(cbCountries.Text).CountryID;
            _Person.FirstName = guna2txtFirstName.Text;
            _Person.SecondName = guna2txtSecondName.Text;
            _Person.ThirdName = (guna2txtThirdName.Text == "") ? DBNull.Value.ToString() : guna2txtThirdName.Text;
            _Person.LastName = guna2txtLastName.Text;
            _Person.NationalNo = guna2txtNationalNo.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = guna2txtPhone.Text; 
            _Person.Email = (guna2txtEmail.Text == "") ? DBNull.Value.ToString() : guna2txtEmail.Text;
            _Person.NationalityCountryID = CountryID;
            _Person.Address = txtAddress.Text;

            _Person.ImagePath = (pbPhoto.ImageLocation != null) ? pbPhoto.ImageLocation : DBNull.Value.ToString();

            _Person.Gendor = (rbMale.Checked) ? 0 : 1;
         
            if (_Person.Save())
            { 
                MessageBox.Show("Data Saved Successfully.");
                DataBack?.Invoke(_Person.PersoneID);
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblModeTitle.Text = "Update Person";
            lblPersonID.Text = _Person.PersoneID.ToString();
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) 
            {

                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "This field is required");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
               
            }
        }

        private void guna2txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       
    }
}
