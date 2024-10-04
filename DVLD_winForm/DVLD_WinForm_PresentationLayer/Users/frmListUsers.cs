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

        private DataTable _dtGetAllUsers = null;

        private void Manage_Users_Load(object sender, EventArgs e)
        {

            _dtGetAllUsers = clsUser.GetAllUsers();
            dgvListUsers.DataSource = _dtGetAllUsers;
            lblRecordCount.Text = dgvListUsers.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvListUsers.Rows.Count > 0)
            {
                dgvListUsers.Columns[0].HeaderText = "User ID";
                dgvListUsers.Columns[0].Width = 110;
                dgvListUsers.Columns[1].HeaderText = "Person ID";
                dgvListUsers.Columns[1].Width = 120;
                dgvListUsers.Columns[2].HeaderText = "Full Name";
                dgvListUsers.Columns[2].Width = 350;
                dgvListUsers.Columns[3].HeaderText = "UserName";
                dgvListUsers.Columns[3].Width = 120;
                dgvListUsers.Columns[4].HeaderText = "Is Active";
                dgvListUsers.Columns[4].Width = 120;
            }
        } 

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmAddEditUser frm = new frmAddEditUser())
            {
                frm.ShowDialog();
            }
            Manage_Users_Load(null, null);
        }

        private void AddNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAddEditUser frm = new frmAddEditUser((int)dgvListUsers.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            Manage_Users_Load(null, null);
        }

        private void DeletetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvListUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User deleted succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Manage_Users_Load(null, null);
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
            MessageBox.Show("This Futcher is not implemented yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This fucher is not implemented yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmChangePassword frm = new frmChangePassword((int)dgvListUsers.CurrentRow.Cells[0].Value)) 
            {
                frm.ShowDialog();
            }
            Manage_Users_Load(null,null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmUserInfo frm = new frmUserInfo((int)dgvListUsers.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
        }


        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "UserID" || cbFilterBy.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                if (!txtFilterValue.Visible)
                {
                    _dtGetAllUsers.DefaultView.RowFilter = "";
                    lblRecordCount.Text = dgvListUsers.Rows.Count.ToString();
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";
            string FilterColumn = "IsActive";
            switch (cbIsActive.Text)
            {
                case "All":
                    break;
                case "Active":
                    FilterValue = "1";
                    break;
                case "In Active":
                    FilterValue = "0";
                    break;

            }

            if (cbIsActive.Text == "All")
                _dtGetAllUsers.DefaultView.RowFilter = "";
            else
                _dtGetAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordCount.Text = dgvListUsers.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "UserID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {

                _dtGetAllUsers.DefaultView.RowFilter = "";
                lblRecordCount.Text = dgvListUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtGetAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtGetAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",FilterColumn, txtFilterValue.Text.Trim());
          

            lblRecordCount.Text = dgvListUsers.Rows.Count.ToString();

        }
    }
}
