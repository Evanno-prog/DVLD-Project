using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            { 
                _ShowAddPerson = value;
                guna2btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true; 
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilterFindBy.Enabled = _FilterEnabled;
            }
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtValueFilter.Text = PersonID.ToString();
            _FindNow();
        } 

        public void LoadPersonInfo(string NationalNo)
        {
            cbFilterBy.SelectedIndex = 0;
            txtValueFilter.Text = NationalNo;
            _FindNow();
        }

        private void _FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "PersonID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtValueFilter.Text));
                    break;

                case "NationalNo":
                    ctrlPersonCard1.LoadPersonInfo(txtValueFilter.Text);
                    break;
              
            }

            if (OnPersonSelected != null && FilterEnabled)
            {
                PersonSelected(PersonID);
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtValueFilter.Focus();
        }
     
        private void cbFindPersonInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValueFilter.Text = string.Empty;
            txtValueFilter.Focus();
        }

        private void DataBackEvent(object sender,int PersonID)
        {
         
            cbFilterBy.SelectedIndex = 1;
            txtValueFilter.Text = PersonID.ToString();
            _FindNow();
        }
    
        private void txtValueFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                guna2btnFind.PerformClick();
                return;
            }

            if (cbFilterBy.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void guna2btnFind_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! , put the mouse over the red icon(s) to see the error message", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();
        }

        private void guna2btnAddNewPerson_Click(object sender, EventArgs e)
        {
            using (frmAddEditPersoneInfo frm = new frmAddEditPersoneInfo())
            {
                frm.DataBack += DataBackEvent;
                frm.ShowDialog();
            }
        }

        public void FilterFocus()
        {
            txtValueFilter.Focus(); 
        }

        private void txtValueFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtValueFilter.Text))
            {
                errorProvider1.SetError(txtValueFilter, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtValueFilter, null);
                e.Cancel = false;
            }
        }
    }
}
