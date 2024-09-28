using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }

        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
      
        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                                      "FirstName", "SecondName",
                                                                      "ThirdName", "LastName",
                                                                      "GendorCaption", "DateOfBirth",
                                                                      "CountryName",
                                                                      "Phone", "Email");
        private void _RefreshListPeople()
        {

            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                                          "FirstName", "SecondName",
                                                                          "ThirdName", "LastName",
                                                                          "GendorCaption", "DateOfBirth",
                                                                          "CountryName",
                                                                          "Phone", "Email");
            dgvPeople.DataSource = _dtPeople;
            lblRecordCount.Text = _dtPeople.Rows.Count.ToString();
        } 

    

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            dgvPeople.DataSource = _dtPeople;
            lblRecordCount.Text = _dtPeople.Rows.Count.ToString();
       
            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 90;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 90;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 100;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 100;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 100;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 100;

                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[6].Width = 80;

                dgvPeople.Columns[7].HeaderText = "Date of birth";
                dgvPeople.Columns[7].Width = 110;

                dgvPeople.Columns[8].HeaderText = "Country";
                dgvPeople.Columns[8].Width = 100;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 100;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 150;

            }

        }


        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson_Click(null, null);
            _RefreshListPeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAddEditPersoneInfo frm = new frmAddEditPersoneInfo((int)dgvPeople.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        //  Refresh for Grid
            _RefreshListPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Person deleted succfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshListPeople();   
            }
            else
                MessageBox.Show("Person not deleted because, there is another data link to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This future is not implemented yet", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This future is not implemented yet", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            //  Refresh grid
            _RefreshListPeople();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            using (frmAddEditPersoneInfo frm = new frmAddEditPersoneInfo())
            {
                frm.ShowDialog();
            }
        //  Refresh Grid
            _RefreshListPeople();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordCount.Text = _dtPeople.Rows.Count.ToString();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "None":
                    FilterColumn = "None";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "FirstName":
                    FilterColumn = "FirstName";
                    break;
                case "SecondName":
                    FilterColumn = "SecondName";
                    break;
                case "ThirdName":
                    FilterColumn = "ThirdName";
                    break;
                case "LastName":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break; 
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
              
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
          
            if ((FilterColumn == "None") || txtFilterValue.Text.Trim() == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordCount.Text = _dtPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
            {
                //in this case we deal with integer not string.
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            }

            lblRecordCount.Text = dgvPeople.Rows.Count.ToString();

        }
    }
}
