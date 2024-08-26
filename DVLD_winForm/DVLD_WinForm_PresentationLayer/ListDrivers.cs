using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class ListDrivers : Form
    {
        public ListDrivers()
        {
            InitializeComponent();
        }

        private void _RefreshListDrivers()
        {
            DataView dv = clsDriver.GetAllDrivers().DefaultView;
            dgvManageDrivers.DataSource = dv;
            lblRecordCount.Text = dv.Count.ToString();
        }


        private void ListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshListDrivers();
            cbFilterDriver.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterNumber_TextChanged(object sender, EventArgs e)
        {
            DataView dv = clsDriver.GetAllDrivers().DefaultView;


            if (string.IsNullOrEmpty(txtFilterNumber.Text))
            {
                dgvManageDrivers.DataSource = dv;
                lblRecordCount.Text = dv.Count.ToString();
                return;
            }
            else
            {
                switch (cbFilterDriver.Text)
                {

                    case "PersonID":
                        dv.RowFilter = $"PersonID = '{txtFilterNumber.Text}'";
                        dgvManageDrivers.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "Phone":
                        dv.RowFilter = $"Phone = '{txtFilterNumber.Text}'";
                        dgvManageDrivers.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;

                    case "DriverID":
                        dv.RowFilter = $"DriverID = '{txtFilterNumber.Text}'";
                        dgvManageDrivers.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;

                }

            }

        }

        private void txtFilterString_TextChanged(object sender, EventArgs e)
        {

            DataView dv = clsDriver.GetAllDrivers().DefaultView;

            if (string.IsNullOrEmpty(txtFilterString.Text))
            {
                dgvManageDrivers.DataSource = dv;
                lblRecordCount.Text = dv.Count.ToString();
                return;
            }

            else
            {

                switch (cbFilterDriver.Text)
                {

                    case "NationalNo":
                        dv.RowFilter = $"NationalNo = '{txtFilterString.Text}'";
                        dgvManageDrivers.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;
                    case "FullName":
                        dv.RowFilter = $"FullName = '{txtFilterString.Text}'";
                        dgvManageDrivers.DataSource = dv;
                        lblRecordCount.Text = dv.Count.ToString();
                        return;

                }

            }


        }

        private void cbFilterDriver_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbFilterDriver.Text)
            {


                case "None":
                    _RefreshListDrivers();
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = false;
                    return;
                case "PersonID":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    return;
                case "DriverID":
                    txtFilterNumber.Visible = true;
                    txtFilterString.Visible = false;
                    return;
                case "Phone":
                    txtFilterString.Visible = false;
                    txtFilterNumber.Visible = true;
                    return;
                case "NationalNo":
                    txtFilterString.Visible = true;
                    txtFilterNumber.Visible = false;
                    return;
                case "FullName":
                    txtFilterNumber.Visible = false;
                    txtFilterString.Visible = true;
                    return;
            }
        }
   
    }
}
