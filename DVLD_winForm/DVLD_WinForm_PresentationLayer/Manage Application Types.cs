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
    public partial class Manage_Application_Types : Form
    {
        public Manage_Application_Types()
        {
            InitializeComponent();
        }

        private void _RefereshListApplicationTypes()
        {
            DataView dv = clsApplicationType.GetAllApplicationTypes().DefaultView;
            dgvManageApplicationTypes.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_Application_Types_Load(object sender, EventArgs e)
        {
            _RefereshListApplicationTypes();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UpdateApplicationTypes frm = new UpdateApplicationTypes((int)dgvManageApplicationTypes.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
            }
            _RefereshListApplicationTypes();
        }
    }
}
