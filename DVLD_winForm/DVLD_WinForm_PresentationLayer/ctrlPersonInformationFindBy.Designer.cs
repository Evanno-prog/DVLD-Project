namespace DVLD_WinForm_PresentationLayer
{
    partial class ctrlPersonInformationFindBy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonInformationFindBy));
            this.ctrlPersonInformation1 = new DVLD_WinForm_PresentationLayer.ctrlPersonInformation();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilterFindBy = new System.Windows.Forms.GroupBox();
            this.txtFilterByNationalNo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilterByPersonID = new System.Windows.Forms.TextBox();
            this.cbFindPersonInfo = new System.Windows.Forms.ComboBox();
            this.gbFilterFindBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPersonInformation1
            // 
            this.ctrlPersonInformation1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInformation1.Location = new System.Drawing.Point(2, 96);
            this.ctrlPersonInformation1.Name = "ctrlPersonInformation1";
            this.ctrlPersonInformation1.Size = new System.Drawing.Size(811, 298);
            this.ctrlPersonInformation1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find By:";
            // 
            // gbFilterFindBy
            // 
            this.gbFilterFindBy.Controls.Add(this.txtFilterByNationalNo);
            this.gbFilterFindBy.Controls.Add(this.pictureBox2);
            this.gbFilterFindBy.Controls.Add(this.pictureBox1);
            this.gbFilterFindBy.Controls.Add(this.txtFilterByPersonID);
            this.gbFilterFindBy.Controls.Add(this.cbFindPersonInfo);
            this.gbFilterFindBy.Controls.Add(this.label1);
            this.gbFilterFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterFindBy.Location = new System.Drawing.Point(3, 13);
            this.gbFilterFindBy.Name = "gbFilterFindBy";
            this.gbFilterFindBy.Size = new System.Drawing.Size(800, 75);
            this.gbFilterFindBy.TabIndex = 2;
            this.gbFilterFindBy.TabStop = false;
            this.gbFilterFindBy.Text = "Filter";
            // 
            // txtFilterByNationalNo
            // 
            this.txtFilterByNationalNo.Location = new System.Drawing.Point(334, 33);
            this.txtFilterByNationalNo.Name = "txtFilterByNationalNo";
            this.txtFilterByNationalNo.Size = new System.Drawing.Size(179, 26);
            this.txtFilterByNationalNo.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(623, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(537, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtFilterByPersonID
            // 
            this.txtFilterByPersonID.Location = new System.Drawing.Point(334, 32);
            this.txtFilterByPersonID.Name = "txtFilterByPersonID";
            this.txtFilterByPersonID.Size = new System.Drawing.Size(179, 26);
            this.txtFilterByPersonID.TabIndex = 3;
            this.txtFilterByPersonID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterByPersonID_KeyPress);
            // 
            // cbFindPersonInfo
            // 
            this.cbFindPersonInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindPersonInfo.FormattingEnabled = true;
            this.cbFindPersonInfo.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cbFindPersonInfo.Location = new System.Drawing.Point(132, 31);
            this.cbFindPersonInfo.Name = "cbFindPersonInfo";
            this.cbFindPersonInfo.Size = new System.Drawing.Size(178, 28);
            this.cbFindPersonInfo.TabIndex = 2;
            this.cbFindPersonInfo.SelectedIndexChanged += new System.EventHandler(this.cbFindPersonInfo_SelectedIndexChanged);
            // 
            // ctrlPersonInformationFindBy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilterFindBy);
            this.Controls.Add(this.ctrlPersonInformation1);
            this.Name = "ctrlPersonInformationFindBy";
            this.Size = new System.Drawing.Size(817, 402);
            this.Load += new System.EventHandler(this.ctrlPersonInformationFindBy_Load);
            this.gbFilterFindBy.ResumeLayout(false);
            this.gbFilterFindBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonInformation ctrlPersonInformation1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFilterFindBy;
        private System.Windows.Forms.TextBox txtFilterByPersonID;
        private System.Windows.Forms.ComboBox cbFindPersonInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFilterByNationalNo;
    }
}
