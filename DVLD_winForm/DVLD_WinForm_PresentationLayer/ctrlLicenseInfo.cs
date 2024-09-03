using DVLD_BussinessLayer;
using System;
using System.IO;
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
    public partial class ctrlLicenseInfo : UserControl
    {
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
        
        public void LoadDriverLiceseInfo(int LicenseID)
        {

            DataTable dt = clsLicense.GetAllLicensesInfo_View(LicenseID);
            DataRow dr = dt.Rows[0];
            if (dr != null)
            {
                lblLicenseClass.Text = dr["ClassName"].ToString();
                PersonName.Text = dr["Name"].ToString();
                lblLicenseID.Text = dr["LicenseID"].ToString();
                lblNationalNo.Text = dr["NationalNo"].ToString();
                lblIsDetained.Text = (string.IsNullOrEmpty(dr["IsReleased"].ToString())) ? "[???]" : (dr["IsReleased"].ToString() == "False") ? "Yes" : "No";
                lblGendor.Text = dr["Gendor"].ToString();

                if (lblGendor.Text == "Male")
                { 
                    pbGendor.Load("D:\\Rel_Schema for DVLD\\ICONS\\Man 32.png"); 
                }
                else
                {
                    pbGendor.Load("D:\\Rel_Schema for DVLD\\ICONS\\Woman 32.png");
                }

                if (string.IsNullOrEmpty(dr["ImagePath"].ToString()))
                {
                    if (lblGendor.Text == "Male")
                    {
                        pbLicenseInfo.Load("D:\\Rel_Schema for DVLD\\ICONS\\Male 512.png");
                    }
                    else
                    {
                        pbLicenseInfo.Load("D:\\Rel_Schema for DVLD\\ICONS\\Female 512.png");
                    }
                }
                else
                {
                    pbLicenseInfo.Load(dr["ImagePath"].ToString());
                }

                lblIssueDate.Text = Convert.ToDateTime(dr["IssueDate"]).ToString("d");
                lblExpirationDate.Text = Convert.ToDateTime(dr["ExpirationDate"]).ToString("d");
                lblDateOfBirth.Text = Convert.ToDateTime(dr["DateOfBirth"]).ToString("d");
                lblIsActive.Text = (Convert.ToBoolean(dr["IsActive"])) ? "Yes" : "No";
                lblDriverID.Text = dr["DriverID"].ToString();
                lblIssueReason.Text = dr["IssueReason"].ToString();
                lblNotes.Text = (string.IsNullOrEmpty(dr["Notes"].ToString())) ? "No Notes" : dr["Notes"].ToString();

            }
        }

        private void ctrlLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
