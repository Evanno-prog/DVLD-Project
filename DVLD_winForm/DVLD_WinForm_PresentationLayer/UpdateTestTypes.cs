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
    public partial class UpdateTestTypes : Form
    {
        private int _TestTypeID = 0;
        private clsTestType _TestType;
        public UpdateTestTypes(int testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;   
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);
            lblID.Text = _TestType.TestTypeID.ToString();
            guna2txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            guna2txtFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeTitle = guna2txtTitle.Text;
            _TestType.TestTypeDescription = txtDescription.Text;
            _TestType.TestTypeFees = Convert.ToDecimal(guna2txtFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Data Saved failed :-(", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


    }
}
