namespace DVLD_WinForm_PresentationLayer
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
            this.gbFilterByLicenseID = new System.Windows.Forms.GroupBox();
            this.btnFindLicenseID = new System.Windows.Forms.Button();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLicenseInfo1 = new DVLD_WinForm_PresentationLayer.ctrlDriverLicenseInfo();
            this.gbFilterByLicenseID.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilterByLicenseID
            // 
            this.gbFilterByLicenseID.Controls.Add(this.btnFindLicenseID);
            this.gbFilterByLicenseID.Controls.Add(this.txtLicenseID);
            this.gbFilterByLicenseID.Controls.Add(this.label1);
            this.gbFilterByLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterByLicenseID.Location = new System.Drawing.Point(5, 3);
            this.gbFilterByLicenseID.Name = "gbFilterByLicenseID";
            this.gbFilterByLicenseID.Size = new System.Drawing.Size(561, 81);
            this.gbFilterByLicenseID.TabIndex = 1;
            this.gbFilterByLicenseID.TabStop = false;
            this.gbFilterByLicenseID.Text = "Filter";
            // 
            // btnFindLicenseID
            // 
            this.btnFindLicenseID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindLicenseID.Enabled = false;
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
            this.txtLicenseID.TextChanged += new System.EventHandler(this.txtLicenseID_TextChanged);
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
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
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(3, 90);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(788, 368);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // ctrlFilterByDriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilterByLicenseID);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlFilterByDriverLicenseInfo";
            this.Size = new System.Drawing.Size(794, 459);
            this.gbFilterByLicenseID.ResumeLayout(false);
            this.gbFilterByLicenseID.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDriverLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFilterByLicenseID;
        private System.Windows.Forms.Button btnFindLicenseID;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label1;
    }
}
