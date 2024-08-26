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
    public partial class ManageTestTypes : Form
    {
        public ManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshListTestTypes()
        {
            DataView dv = clsTestType.GetAllTestTypes().DefaultView;
            dgvManageTestTypes.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshListTestTypes();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UpdateTestTypes frm = new UpdateTestTypes((int)dgvManageTestTypes.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefreshListTestTypes();
        }
    }
}
