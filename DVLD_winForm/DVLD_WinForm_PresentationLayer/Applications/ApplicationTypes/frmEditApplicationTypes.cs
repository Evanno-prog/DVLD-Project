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
    public partial class frmEditApplicationTypes : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationType _ApplicationTypes;
        public frmEditApplicationTypes(int appTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = appTypeID;
        }

        private void guna2btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplicationTypes_Load_1(object sender, EventArgs e)
        {
            
            lblID.Text = _ApplicationTypeID.ToString();
            _ApplicationTypes = clsApplicationType.Find(_ApplicationTypeID);
            if (_ApplicationTypes != null)
            {
                guna2txtTitle.Text = _ApplicationTypes.Title;
                guna2txtFees.Text = _ApplicationTypes.Fees.ToString();
            }

        }

        private void guna2btnSave_Click_1(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationTypes.Title = guna2txtTitle.Text;
            _ApplicationTypes.Fees = Convert.ToSingle(guna2txtFees.Text);

            if (_ApplicationTypes.Save())
            {
                MessageBox.Show("Data Saved succfully :-)", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Error: Data not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void guna2txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(guna2txtTitle.Text.Trim()))
            {
                errorProvider1.SetError(guna2txtTitle, "This field is required!");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(guna2txtTitle, null);
        }

        private void guna2txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(guna2txtTitle.Text.Trim()))
            {
                errorProvider1.SetError(guna2txtTitle, "This field is required!");
                e.Cancel = true;
                return;
            }
            else
                errorProvider1.SetError(guna2txtTitle, null);


            if (!clsValidation.IsNumber(guna2txtFees.Text.Trim())) 
            {
                errorProvider1.SetError(guna2txtTitle, "Invalid Number!");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(guna2txtFees, null);
        }
    }
}
