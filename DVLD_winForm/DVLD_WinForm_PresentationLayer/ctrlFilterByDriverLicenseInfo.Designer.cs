﻿namespace DVLD_WinForm_PresentationLayer
{
    partial class ctrlFilterByDriverLicenseInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlFilterByDriverLicenseInfo));
            this.ctrlLicenseInfo1 = new DVLD_WinForm_PresentationLayer.ctrlLicenseInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindLicenseID = new System.Windows.Forms.Button();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(3, 81);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(796, 373);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindLicenseID);
            this.groupBox1.Controls.Add(this.txtLicenseID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnFindLicenseID
            // 
            this.btnFindLicenseID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicenseID.Image = ((System.Drawing.Image)(resources.GetObject("btnFindLicenseID.Image")));
            this.btnFindLicenseID.Location = new System.Drawing.Point(466, 23);
            this.btnFindLicenseID.Name = "btnFindLicenseID";
            this.btnFindLicenseID.Size = new System.Drawing.Size(71, 47);
            this.btnFindLicenseID.TabIndex = 4;
            this.btnFindLicenseID.UseVisualStyleBackColor = true;
            this.btnFindLicenseID.Click += new System.EventHandler(this.btnFindLicenseID_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(131, 33);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(313, 26);
            this.txtLicenseID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "LicenseID:";
            // 
            // ctrlFilterByDriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlFilterByDriverLicenseInfo";
            this.Size = new System.Drawing.Size(792, 448);
            this.Load += new System.EventHandler(this.ctrlFilterByDriverLicenseInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindLicenseID;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label1;
    }
}