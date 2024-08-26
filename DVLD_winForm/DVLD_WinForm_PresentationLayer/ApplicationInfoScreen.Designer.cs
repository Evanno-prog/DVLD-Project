namespace DVLD_WinForm_PresentationLayer
{
    partial class ApplicationInfoScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationInfoScreen));
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlL_D_L_ApplicationInfo1 = new DVLD_WinForm_PresentationLayer.ctrlL_D_L_ApplicationInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(637, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 29);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlL_D_L_ApplicationInfo1
            // 
            this.ctrlL_D_L_ApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlL_D_L_ApplicationInfo1.Location = new System.Drawing.Point(2, 0);
            this.ctrlL_D_L_ApplicationInfo1.Name = "ctrlL_D_L_ApplicationInfo1";
            this.ctrlL_D_L_ApplicationInfo1.Size = new System.Drawing.Size(862, 422);
            this.ctrlL_D_L_ApplicationInfo1.TabIndex = 0;
            // 
            // ApplicationInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 456);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlL_D_L_ApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ApplicationInfoScreen";
            this.Text = "Application Info Screen";
            this.Load += new System.EventHandler(this.ApplicationInfoScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlL_D_L_ApplicationInfo ctrlL_D_L_ApplicationInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}