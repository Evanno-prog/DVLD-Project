namespace DVLD_WinForm_PresentationLayer
{
    partial class Detain_License
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
            this.ctrlFilterByDriverLicenseInfo1 = new DVLD_WinForm_PresentationLayer.ctrlFilterByDriverLicenseInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlFilterByDriverLicenseInfo1
            // 
            this.ctrlFilterByDriverLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlFilterByDriverLicenseInfo1.Location = new System.Drawing.Point(12, 45);
            this.ctrlFilterByDriverLicenseInfo1.Name = "ctrlFilterByDriverLicenseInfo1";
            this.ctrlFilterByDriverLicenseInfo1.Size = new System.Drawing.Size(794, 407);
            this.ctrlFilterByDriverLicenseInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detain License";
            // 
            // Detain_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(808, 543);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlFilterByDriverLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Detain_License";
            this.Text = "Detain License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlFilterByDriverLicenseInfo ctrlFilterByDriverLicenseInfo1;
        private System.Windows.Forms.Label label1;
    }
}