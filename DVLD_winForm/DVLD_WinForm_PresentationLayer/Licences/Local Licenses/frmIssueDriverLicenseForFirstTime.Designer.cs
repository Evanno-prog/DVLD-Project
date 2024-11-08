namespace DVLD_WinForm_PresentationLayer
{
    partial class frmIssueDriverLicenseForFirstTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueDriverLicenseForFirstTime));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new DVLD_WinForm_PresentationLayer.ctrlLocalDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(88, 414);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(130, 420);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(733, 100);
            this.txtNotes.TabIndex = 3;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(672, 525);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(90, 29);
            this.guna2Button1.TabIndex = 17;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2btnSave
            // 
            this.guna2btnSave.BorderThickness = 1;
            this.guna2btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnSave.FillColor = System.Drawing.Color.White;
            this.guna2btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2btnSave.ForeColor = System.Drawing.Color.Black;
            this.guna2btnSave.Image = ((System.Drawing.Image)(resources.GetObject("guna2btnSave.Image")));
            this.guna2btnSave.Location = new System.Drawing.Point(772, 525);
            this.guna2btnSave.Name = "guna2btnSave";
            this.guna2btnSave.Size = new System.Drawing.Size(90, 29);
            this.guna2btnSave.TabIndex = 18;
            this.guna2btnSave.Text = "Issue";
            this.guna2btnSave.Click += new System.EventHandler(this.guna2btnSave_Click);
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(3, -1);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(870, 419);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 19;
            // 
            // IssueDriverLicenseForFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(878, 558);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.guna2btnSave);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IssueDriverLicenseForFirstTime";
            this.Text = "Issue Driver License For First Time";
            this.Load += new System.EventHandler(this.IssueDriverLicenseForFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2btnSave;
        private ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1;
    }
}