namespace DVLD_WinForm_PresentationLayer
{
    partial class ListInternationalDrivingLicenseApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListInternationalDrivingLicenseApplication));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtFilterNumber = new System.Windows.Forms.TextBox();
            this.txtFilterString = new System.Windows.Forms.TextBox();
            this.cbFilterIntLicense = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.dgvListIntLicenses = new System.Windows.Forms.DataGridView();
            this.btnAddIntLicnese = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmManageIntLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListIntLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmManageIntLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(590, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // txtFilterNumber
            // 
            this.txtFilterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterNumber.Location = new System.Drawing.Point(250, 183);
            this.txtFilterNumber.Name = "txtFilterNumber";
            this.txtFilterNumber.Size = new System.Drawing.Size(134, 26);
            this.txtFilterNumber.TabIndex = 34;
            this.txtFilterNumber.Visible = false;
            this.txtFilterNumber.TextChanged += new System.EventHandler(this.txtFilterNumber_TextChanged);
            this.txtFilterNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterNumber_KeyPress);
            // 
            // txtFilterString
            // 
            this.txtFilterString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterString.Location = new System.Drawing.Point(250, 182);
            this.txtFilterString.Name = "txtFilterString";
            this.txtFilterString.Size = new System.Drawing.Size(134, 26);
            this.txtFilterString.TabIndex = 33;
            this.txtFilterString.Visible = false;
            this.txtFilterString.TextChanged += new System.EventHandler(this.txtFilterString_TextChanged);
            // 
            // cbFilterIntLicense
            // 
            this.cbFilterIntLicense.BackColor = System.Drawing.Color.White;
            this.cbFilterIntLicense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterIntLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterIntLicense.FormattingEnabled = true;
            this.cbFilterIntLicense.Items.AddRange(new object[] {
            "None",
            "L.D.LAppID",
            "NationalNo",
            "Full Name",
            "Status"});
            this.cbFilterIntLicense.Location = new System.Drawing.Point(109, 183);
            this.cbFilterIntLicense.Name = "cbFilterIntLicense";
            this.cbFilterIntLicense.Size = new System.Drawing.Size(133, 26);
            this.cbFilterIntLicense.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Filter By:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(107, 500);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(19, 20);
            this.lblRecordCount.TabIndex = 30;
            this.lblRecordCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "# Records:";
            // 
            // guna2btnClose
            // 
            this.guna2btnClose.BorderThickness = 1;
            this.guna2btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnClose.FillColor = System.Drawing.Color.White;
            this.guna2btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2btnClose.ForeColor = System.Drawing.Color.Black;
            this.guna2btnClose.Image = ((System.Drawing.Image)(resources.GetObject("guna2btnClose.Image")));
            this.guna2btnClose.Location = new System.Drawing.Point(921, 495);
            this.guna2btnClose.Name = "guna2btnClose";
            this.guna2btnClose.Size = new System.Drawing.Size(90, 29);
            this.guna2btnClose.TabIndex = 28;
            this.guna2btnClose.Text = "Close";
            this.guna2btnClose.Click += new System.EventHandler(this.guna2btnClose_Click);
            // 
            // dgvListIntLicenses
            // 
            this.dgvListIntLicenses.AllowUserToAddRows = false;
            this.dgvListIntLicenses.AllowUserToDeleteRows = false;
            this.dgvListIntLicenses.AllowUserToOrderColumns = true;
            this.dgvListIntLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListIntLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListIntLicenses.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dgvListIntLicenses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvListIntLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListIntLicenses.ContextMenuStrip = this.cmManageIntLicense;
            this.dgvListIntLicenses.GridColor = System.Drawing.Color.DimGray;
            this.dgvListIntLicenses.Location = new System.Drawing.Point(18, 218);
            this.dgvListIntLicenses.Name = "dgvListIntLicenses";
            this.dgvListIntLicenses.ReadOnly = true;
            this.dgvListIntLicenses.Size = new System.Drawing.Size(1015, 272);
            this.dgvListIntLicenses.TabIndex = 27;
            // 
            // btnAddIntLicnese
            // 
            this.btnAddIntLicnese.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddIntLicnese.Image = ((System.Drawing.Image)(resources.GetObject("btnAddIntLicnese.Image")));
            this.btnAddIntLicnese.Location = new System.Drawing.Point(921, 135);
            this.btnAddIntLicnese.Name = "btnAddIntLicnese";
            this.btnAddIntLicnese.Size = new System.Drawing.Size(84, 74);
            this.btnAddIntLicnese.TabIndex = 26;
            this.btnAddIntLicnese.UseVisualStyleBackColor = true;
            this.btnAddIntLicnese.Click += new System.EventHandler(this.btnAddIntLicnese_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(348, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "International License Application";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(449, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // cmManageIntLicense
            // 
            this.cmManageIntLicense.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmManageIntLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.ShowLicenseDetails,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmManageIntLicense.Name = "contextMenuStrip1";
            this.cmManageIntLicense.Size = new System.Drawing.Size(240, 134);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(239, 36);
            this.showDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // ShowLicenseDetails
            // 
            this.ShowLicenseDetails.Image = ((System.Drawing.Image)(resources.GetObject("ShowLicenseDetails.Image")));
            this.ShowLicenseDetails.Name = "ShowLicenseDetails";
            this.ShowLicenseDetails.Size = new System.Drawing.Size(239, 36);
            this.ShowLicenseDetails.Text = "Show License Details";
            this.ShowLicenseDetails.Click += new System.EventHandler(this.ShowLicenseDetails_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonLicenseHistoryToolStripMenuItem.Image")));
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(239, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // ListInternationalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1042, 528);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFilterNumber);
            this.Controls.Add(this.txtFilterString);
            this.Controls.Add(this.cbFilterIntLicense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2btnClose);
            this.Controls.Add(this.dgvListIntLicenses);
            this.Controls.Add(this.btnAddIntLicnese);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ListInternationalDrivingLicenseApplication";
            this.Text = "List International License Application";
            this.Load += new System.EventHandler(this.ListInternationalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListIntLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmManageIntLicense.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtFilterNumber;
        private System.Windows.Forms.TextBox txtFilterString;
        private System.Windows.Forms.ComboBox cbFilterIntLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2btnClose;
        private System.Windows.Forms.DataGridView dgvListIntLicenses;
        private System.Windows.Forms.Button btnAddIntLicnese;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmManageIntLicense;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}