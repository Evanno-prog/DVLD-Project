﻿using DVLD_BussinessLayer;
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
    public partial class frmShowLicenseInfo : Form
    {

        private int _LicenseID = -1;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;   
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadInfo(_LicenseID);
        }
    }
}