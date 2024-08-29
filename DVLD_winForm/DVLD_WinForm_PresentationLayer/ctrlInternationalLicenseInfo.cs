using DVLD_BussinessLayer;
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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int IntLicenseID)
        {

            DataTable dt = clsInternationalLicense.GetInternationalLicenseInfo(IntLicenseID);
            DataRow dr = dt.Rows[0];
            if (dr != null)
            {

                lblPersonName.Text = dr["FullName"].ToString();
                lblIntLicenseID.Text = dr["InternationalLicenseID"].ToString();
                lblLicenseID.Text = dr["IssuedUsingLocalLicenseID"].ToString();
                lblNationalNo.Text = dr["NationalNo"].ToString();

                lblGendor.Text = (dr["Gendor"].ToString() == "Male") ? "Male" : "Female";
             
                
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
                        pbIntLicenseInfo.Load("D:\\Rel_Schema for DVLD\\ICONS\\male.png");
                    }
                    else
                    {
                        pbIntLicenseInfo.Load("D:\\Rel_Schema for DVLD\\ICONS\\Female 512.png");
                    }

                }
                else
                {
                    pbIntLicenseInfo.Load(dr["ImagePath"].ToString());
                }


                lblIssueDate.Text = Convert.ToDateTime(dr["IssueDate"]).ToString("d");
                lblApplicationID.Text = dr["ApplicationID"].ToString();
                lblIsActive.Text = (Convert.ToBoolean(dr["IsActive"])) ? "Yes" : "No";
                lblExpirationDate.Text = Convert.ToDateTime(dr["ExpirationDate"]).ToString("d");
                lblDateOfBirth.Text = Convert.ToDateTime(dr["DateOfBirth"]).ToString("d");
                lblDriverID.Text = dr["DriverID"].ToString();

            }

        }
    }
}
