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
    public partial class ctrlPersonInformation : UserControl
    {
        private int _PersonID = 0;
        clsPersone Persone;
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (AddEditPersoneInfo frm = new AddEditPersoneInfo(_PersonID))
            {
                frm.DataBack += DataBack_Personid;
                frm.ShowDialog();
            }

        }

        private void DataBack_Personid(int PersonID)
        {
            LoadPersonInfoData(PersonID);
        }
   
        public void LoadPersonInfoData(int PersonID)
        {
            _PersonID = PersonID;
            Persone = clsPersone.Find(_PersonID);
            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = $"{Persone.FirstName} {Persone.SecondName} {Persone.ThirdName} {Persone.LastName}";
            lblNationalNo.Text = Persone.NationalNo;
            if (Persone.Gendor == 0)
            {
                pbGendor.Load("D:\\Rel_Schema for DVLD\\ICONS\\Man 32.png");
                lblGendor.Text = "Male";
            }
            else
            {
                pbGendor.Load("D:\\Rel_Schema for DVLD\\ICONS\\Woman 32.png");
                lblGendor.Text = "Female";
            }
            
            lblEmail.Text = Persone.Email;  
            lblAddress.Text = Persone.Address;
            lblPhone.Text = Persone.Phone;
            lblDateOfBirth.Text = Persone.DateOfBirth.ToString("dd/MM/yyyy");
            lblCountry.Text = clsCountry.Find(Persone.NationalityCountryID).CountryName;
            if (Persone.ImagePath != null)
            {
                pbPersonPhoto.Load(Persone.ImagePath);
            }
           
        }

        private void ctrlPersonInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
