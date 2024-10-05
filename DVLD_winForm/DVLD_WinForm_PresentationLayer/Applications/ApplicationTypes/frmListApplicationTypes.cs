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
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvManageApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordCount.Text = dgvManageApplicationTypes.Rows.Count.ToString();
            if (dgvManageApplicationTypes.Rows.Count > 0)
            {
                dgvManageApplicationTypes.Columns[0].HeaderText = "ID";
                dgvManageApplicationTypes.Columns[0].Width = 110;

                dgvManageApplicationTypes.Columns[1].HeaderText = "Title";
                dgvManageApplicationTypes.Columns[1].Width = 400;

                dgvManageApplicationTypes.Columns[2].HeaderText = "Fees";     
                dgvManageApplicationTypes.Columns[2].Width = 100;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmEditApplicationTypes frm = new frmEditApplicationTypes((int)dgvManageApplicationTypes.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }

            frmListApplicationTypes_Load(null, null);
        }
    }
}
