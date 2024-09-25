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
    public partial class ctrlPersonInformationFindBy : UserControl
    {
        public ctrlPersonInformationFindBy()
        {
            InitializeComponent();
        }

        public int Person_id { set; get; }

        public void IsEnableGbFilter(bool IsEnable)
        {
            gbFilterFindBy.Enabled = IsEnable;
        }

        public void LoadPersonInfoByPersonID(int Person_id)
        {
            ctrlPersonInformation1.LoadPersonInfoData(Person_id);
            this.Person_id = Person_id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            switch (cbFindPersonInfo.Text)
            {

                case "NationalNo":

                    if (!clsPerson.isPersonExist(txtFilterByNationalNo.Text))
                    {
                        MessageBox.Show("Sorry! NationalNo is not exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Person_id = -1;
                        return;
                    }
                    Person_id = clsPerson.Find(txtFilterByNationalNo.Text).PersonID;
                    ctrlPersonInformation1.LoadPersonInfoData(Person_id);
                    break;
                case "PersonID":
                    if (!clsPerson.isPersonExist(Convert.ToInt16(txtFilterByPersonID.Text)))
                    {
                        MessageBox.Show("Sorry! PersonID is not exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Person_id = -1;
                        return;
                    }
                    Person_id = clsPerson.Find(Convert.ToInt16(txtFilterByPersonID.Text)).PersonID;
                    ctrlPersonInformation1.LoadPersonInfoData(Person_id);
                    break;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (AddEditPersoneInfo frm = new AddEditPersoneInfo(-1))
            { 
                frm.DataBack += DataBack_PersonID;
                frm.ShowDialog();
            }
        }

        private void DataBack_PersonID(object sender, int PersonId)
        {
            LoadPersonInfoByPersonID(PersonId);
            cbFindPersonInfo.SelectedIndex = 1;
            txtFilterByPersonID.Text = PersonId.ToString();
        }

        private void txtFilterByPersonID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlPersonInformationFindBy_Load(object sender, EventArgs e)
        {
            cbFindPersonInfo.SelectedIndex = 0;
        }

        private void cbFindPersonInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbFindPersonInfo.Text)
            {
                case "NationalNo":
                    txtFilterByNationalNo.Visible = true;
                    txtFilterByPersonID.Visible = false;
                    break;
                case "PersonID":
                    txtFilterByPersonID.Visible = true; 
                    txtFilterByNationalNo.Visible = false;
                    break;
            }
        }
    
        
    }
}
