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
    public partial class UpdateApplicationTypes : Form
    {
        private int _AppTypeID = 0;
        private clsApplicationType _AppTypes;
        public UpdateApplicationTypes(int appTypeID)
        {
            InitializeComponent();
            _AppTypeID = appTypeID;
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplicationTypes_Load_1(object sender, EventArgs e)
        {
            _AppTypes = clsApplicationType.Find(_AppTypeID);
            lblID.Text = _AppTypeID.ToString();
            guna2txtTitle.Text = _AppTypes.ApplicationTypeTitle;
            guna2txtFees.Text = _AppTypes.ApplicationFees.ToString();

        }

        private void guna2btnSave_Click_1(object sender, EventArgs e)
        {
            _AppTypes.ApplicationTypeTitle = guna2txtTitle.Text;
            _AppTypes.ApplicationFees = Convert.ToDecimal(guna2txtFees.Text);
            if (_AppTypes.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Data Saved failed :-(", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);





        }
    }
}
