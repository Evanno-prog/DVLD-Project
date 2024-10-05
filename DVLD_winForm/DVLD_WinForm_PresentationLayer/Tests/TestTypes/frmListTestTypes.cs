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
    public partial class frmListTestTypes : Form
    {

        private DataTable _dtAllTestTypes;

        public frmListTestTypes()
        {
            InitializeComponent();
        }

   

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvManageTestTypes.DataSource = _dtAllTestTypes;
            lblRecordCount.Text = dgvManageTestTypes.Rows.Count.ToString();

            if (dgvManageTestTypes.Rows.Count > 0) 
            {
                dgvManageTestTypes.Columns[0].HeaderText = "ID";
                dgvManageTestTypes.Columns[0].Width = 120;
                dgvManageTestTypes.Columns[1].HeaderText = "Title";
                dgvManageTestTypes.Columns[1].Width = 200;
                dgvManageTestTypes.Columns[2].HeaderText = "Description";
                dgvManageTestTypes.Columns[2].Width = 400;
                dgvManageTestTypes.Columns[3].HeaderText = "Fees";
                dgvManageTestTypes.Columns[3].Width = 100;
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmEditTestTypes frm = new frmEditTestTypes((clsTestType.enTestType)dgvManageTestTypes.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            ManageTestTypes_Load(null, null);
        }
    }
}
