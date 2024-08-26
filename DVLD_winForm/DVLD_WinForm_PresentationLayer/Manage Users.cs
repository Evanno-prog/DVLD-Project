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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class Manage_Users : Form
    {
        public Manage_Users()
        {
            InitializeComponent();
        }

        private void _RefreshListUsers()
        {
            DataView dv = clsUser.GetAllUsers().DefaultView;
            dataGridView1.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }

        private void Manage_Users_Load(object sender, EventArgs e)
        {
          
            _RefreshListUsers();    
            cbFilterUsers.SelectedIndex = 0;
        } 

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterNumber_TextChanged(object sender, EventArgs e)
        {

            DataView dv = clsUser.GetAllUsers().DefaultView;
            if (string.IsNullOrEmpty(txtFilterNumber.Text))
            {
                dataGridView1.DataSource = dv;
                lblRecordCount.Text = dv.Count.ToString();
                return;
            }

            switch (cbFilterUsers.Text)
            {

                case "PersonID":
                    dv.RowFilter = $"PersonID = '{txtFilterNumber.Text}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();
                    return;
                case "UserID":
                    dv.RowFilter = $"UserID = '{txtFilterNumber.Text}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();
                    return;
               
            }

        }

        private void txtFilterString_TextChanged(object sender, EventArgs e)
        {

            DataView dv = clsUser.GetAllUsers().DefaultView;

            if (string.IsNullOrEmpty(txtFilterString.Text))
            {
                dataGridView1.DataSource = dv;
                lblRecordCount.Text = dv.Count.ToString();
                return;
            }

            switch (cbFilterUsers.Text)
            {

                case "Full Name":
                    dv.RowFilter = $"[Full Name] = '{txtFilterString.Text}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();
                    return;
                case "UserName":
                    dv.RowFilter = $"UserName = '{txtFilterString.Text}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();
                    return;

            }

        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterUsers.Text)
            {

                case "None":
                    _RefreshListUsers();
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = false;
                    cbIsActive.Visible = false;
                    return;
                case "PersonID":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    cbIsActive.Visible = false;
                    return;
                case "UserID":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    cbIsActive.Visible = false;
                    return;
                case "Full Name":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    cbIsActive.Visible = false;
                    return;
                case "UserName":
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = true;
                    cbIsActive.Visible = false;
                    return;
                case "Is Active":
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = false;
                    cbIsActive.Visible = true;
                    cbIsActive.SelectedIndex = 0;
                    return;
                    
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataView dv = clsUser.GetAllUsers().DefaultView;
            switch (cbIsActive.Text)
            {
                
                case "All":
                    dv.RowFilter = $"IsActive = '{true}' or IsActive = '{false}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();  
                    break;
                case "Active":
                    dv.RowFilter = $"IsActive = '{true}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();
                    break;
                case "In Active":
                    dv.RowFilter = $"IsActive = '{false}'";
                    dataGridView1.DataSource = dv;
                    lblRecordCount.Text = dv.Count.ToString();
                    break;


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AddEditUser frm = new AddEditUser(-1))
            {
                frm.ShowDialog();
            }
            _RefreshListUsers();
        }

        private void AddNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddEditUser frm = new AddEditUser((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefreshListUsers();
        }

        private void DeletetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User deleted succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshListUsers();
                }
                else
                {
                    MessageBox.Show("Sorry! you can not delete this User,\n Beacuse there are another record linked with it", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("User deleted failed :-(", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This fitcher is not implemented yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This fitcher is not implemented yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePassword frm = new ChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value)) 
            {
                frm.ShowDialog();
            }
            _RefreshListUsers();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserInfoScreen frm = new UserInfoScreen((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }
    }
}
