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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }

        
        private void _RefreshListPeople()
        {
            DataView dv = clsPersone.GetAllPeople().DefaultView;
            dataGridView1.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshListPeople();
            cbFilterPeople.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditPersoneInfo frm = new AddEditPersoneInfo(-1);
            frm.ShowDialog();
            _RefreshListPeople();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersoneInfo frm = new AddEditPersoneInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshListPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Person ?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsPersone.DeletePersone((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshListPeople();
                }
                else
                {
                    MessageBox.Show("Sorry! you can not delete this Person,\n Beacuse there are another record linked with it", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Person deleted failed :-(", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
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
            PersonInfoScreen frm = new PersonInfoScreen((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void cbFilterPeople_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbFilterPeople.Text)
            {

                case "None":
                    _RefreshListPeople();
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = false;
                    return;
                case "PersonID":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    return;
                case "Phone":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    return;
                case "NationalNo":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "FirstName":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "SecondName":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "ThirdName":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "LastName":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return; 
                case "Nationality":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "Gendor":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "Email":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
      
            }

        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterNumber_TextChanged(object sender, EventArgs e)
        {

            DataView dv = clsPersone.GetAllPeople().DefaultView;

            if (string.IsNullOrEmpty(txtFilterNumber.Text))
            {
                dataGridView1.DataSource = dv;
                lblRecordCount.Text = dv.Count.ToString();  
                return;
            }
            else
            {
                 switch (cbFilterPeople.Text)
                 {
              
                       case "PersonID":
                           dv.RowFilter = $"PersonID = '{txtFilterNumber.Text}'";
                           dataGridView1.DataSource = dv;
                           lblRecordCount.Text = dv.Count.ToString();
                           return;
                       case "Phone":
                           dv.RowFilter = $"Phone = '{txtFilterNumber.Text}'";
                           dataGridView1.DataSource = dv;
                           lblRecordCount.Text = dv.Count.ToString();
                           return;
                 
                 }

            }


        }

        private void txtFilterString_TextChanged(object sender, EventArgs e)
        {

            DataView dv = clsPersone.GetAllPeople().DefaultView;

            if (string.IsNullOrEmpty(txtFilterString.Text))
            {
                dataGridView1.DataSource = dv;
                lblRecordCount.Text= dv.Count.ToString();
                return;
            }

            else
            {

                switch (cbFilterPeople.Text)
                {

                    case "NationalNo":
                        dv.RowFilter = $"NationalNo = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "FirstName":
                        dv.RowFilter = $"FirstName = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "SecondName":
                        dv.RowFilter = $"SecondName = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "ThirdName":
                        dv.RowFilter = $"ThirdName = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "LastName":
                        dv.RowFilter = $"LastName = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "Nationality":
                        dv.RowFilter = $"Nationality = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "Gendor":
                        dv.RowFilter = $"Gender = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "Email":
                        dv.RowFilter = $"Email = '{txtFilterString.Text}'";
                        dataGridView1.DataSource = dv;
                        dataGridView1.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;

                }

            }

        }
    }
}
