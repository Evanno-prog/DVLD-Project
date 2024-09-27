namespace DVLD_WinForm_PresentationLayer
{
    partial class ctrlPersonCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCardWithFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilterFindBy = new System.Windows.Forms.GroupBox();
            this.txtValueFilter = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.guna2btnAddNewPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2btnFind = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ctrlPersonCard1 = new DVLD_WinForm_PresentationLayer.ctrlPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterFindBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.gbFilterFindBy.Controls.Add(this.guna2btnFind);
            this.gbFilterFindBy.Controls.Add(this.guna2btnAddNewPerson);
            this.gbFilterFindBy.Controls.Add(this.txtValueFilter);
            this.gbFilterFindBy.Controls.Add(this.cbFilterBy);
            this.gbFilterFindBy.Controls.Add(this.label1);
            this.gbFilterFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterFindBy.Location = new System.Drawing.Point(3, 13);
            this.gbFilterFindBy.Name = "gbFilterFindBy";
            this.gbFilterFindBy.Size = new System.Drawing.Size(800, 75);
            this.gbFilterFindBy.TabIndex = 2;
            this.gbFilterFindBy.TabStop = false;
            this.gbFilterFindBy.Text = "Filter";
            // 
            // txtValueFilter
            // 
            this.txtValueFilter.Location = new System.Drawing.Point(334, 32);
            this.txtValueFilter.Name = "txtValueFilter";
            this.txtValueFilter.Size = new System.Drawing.Size(179, 26);
            this.txtValueFilter.TabIndex = 3;
            this.txtValueFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueFilter_KeyPress);
            this.txtValueFilter.Validating += new System.ComponentModel.CancelEventHandler(this.txtValueFilter_Validating);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cbFilterBy.Location = new System.Drawing.Point(132, 31);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(178, 28);
            this.cbFilterBy.TabIndex = 2;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFindPersonInfo_SelectedIndexChanged);
            // 
            // guna2btnAddNewPerson
            // 
            this.guna2btnAddNewPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2btnAddNewPerson.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("guna2btnAddNewPerson.Image")));
            this.guna2btnAddNewPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2btnAddNewPerson.ImageRotate = 0F;
            this.guna2btnAddNewPerson.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2btnAddNewPerson.Location = new System.Drawing.Point(647, 19);
            this.guna2btnAddNewPerson.Name = "guna2btnAddNewPerson";
            this.guna2btnAddNewPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2btnAddNewPerson.Size = new System.Drawing.Size(55, 42);
            this.guna2btnAddNewPerson.TabIndex = 6;
            this.guna2btnAddNewPerson.Click += new System.EventHandler(this.guna2btnAddNewPerson_Click);
            // 
            // guna2btnFind
            // 
            this.guna2btnFind.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2btnFind.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2btnFind.Image = ((System.Drawing.Image)(resources.GetObject("guna2btnFind.Image")));
            this.guna2btnFind.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2btnFind.ImageRotate = 0F;
            this.guna2btnFind.ImageSize = new System.Drawing.Size(45, 45);
            this.guna2btnFind.Location = new System.Drawing.Point(565, 19);
            this.guna2btnFind.Name = "guna2btnFind";
            this.guna2btnFind.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2btnFind.Size = new System.Drawing.Size(55, 42);
            this.guna2btnFind.TabIndex = 7;
            this.guna2btnFind.Click += new System.EventHandler(this.guna2btnFind_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(2, 96);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(811, 298);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilterFindBy);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(817, 402);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.gbFilterFindBy.ResumeLayout(false);
            this.gbFilterFindBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFilterFindBy;
        private System.Windows.Forms.TextBox txtValueFilter;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2ImageButton guna2btnAddNewPerson;
        private Guna.UI2.WinForms.Guna2ImageButton guna2btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
