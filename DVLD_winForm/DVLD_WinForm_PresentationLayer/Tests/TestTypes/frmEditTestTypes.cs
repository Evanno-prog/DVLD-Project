using DVLD_BussinessLayer;
using DVLD_WinForm_PresentationLayer.Global_Classes;
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
    public partial class frmEditTestTypes : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;
        public frmEditTestTypes(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;   
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                lblID.Text = ((int)_TestType.ID).ToString();
                guna2txtTitle.Text = _TestType.Title;
                txtDescription.Text = _TestType.Description;
                guna2txtFees.Text = _TestType.Fees.ToString();
            }
            else
                MessageBox.Show($"Could not found TestTypeID = {_TestTypeID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void guna2btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! , put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = guna2txtTitle.Text.Trim();
            _TestType.Description = txtDescription.Text.Trim();
            _TestType.Fees = Convert.ToSingle(guna2txtFees.Text.Trim());

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Error: Data Not Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void guna2txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(guna2txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(guna2txtTitle, null);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }

        }

        private void guna2txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(guna2txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(guna2txtFees, null);
            }

            if (!clsValidation.IsNumber(guna2txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(guna2txtFees, null);
            }

        }
    }
}
