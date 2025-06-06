﻿using DVLD_BussinessLayer;
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
    public partial class frmListDrivers : Form
    {

        private DataTable _dtAllDrivers;

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void txtFilterNumber_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
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
                _dtAllDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}",
               FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
               FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtAllDrivers.Rows.Count.ToString();

        }

        private void cbFilterDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtAllDrivers;
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;
                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;
                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;
                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;
                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;
                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }

        }

        private void txtFilterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we only allow numbers incase person id or user id is selected.
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvDrivers.CurrentRow.Cells[1].Value)) 
            {
                frm.ShowDialog();
            }
            //  Refresh
            frmListDrivers_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory((int)dgvDrivers.CurrentRow.Cells[1].Value)) 
            {
                frm.ShowDialog();
            }
        }
    }
}
