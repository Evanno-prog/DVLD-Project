using System;
using System.Data;
using DVLD_DataAccessLayer;
namespace DVLD_BussinessLayer
{

    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }


        public clsDetainedLicense()
        {
            this.DetainID = default;
            this.LicenseID = default;
            this.DetainDate = default;
            this.FineFees = default;
            this.CreatedByUserID = default;
            this.IsReleased = default;
            this.ReleaseDate = default;
            this.ReleasedByUserID = default;
            this.ReleaseApplicationID = default;


            Mode = enMode.AddNew;

        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;


            Mode = enMode.Update;

        }

        private bool _AddNewDetainedLicense()
        {
            //call DataAccess Layer 

            this.DetainID = clsDetainedLicensesDataAccess.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID , this.ReleaseApplicationID );

            return (this.DetainID != -1);

        }

        private bool _UpdateDetainedLicense()
        {
            //call DataAccess Layer 

            return clsDetainedLicensesDataAccess.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID , this.ReleaseApplicationID );

        }

        public static clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = default;
            DateTime DetainDate = default;
            decimal FineFees = default;
            int CreatedByUserID = default;
            bool IsReleased = default;
            DateTime ReleaseDate = default;
            int ReleasedByUserID = default;
            int ReleaseApplicationID = default;


            if (clsDetainedLicensesDataAccess.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID , ref ReleaseApplicationID ))
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID , ReleaseApplicationID );
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDetainedLicense();

            }




            return false;
        }

        public static DataTable GetAllDetainedLicenses() { return clsDetainedLicensesDataAccess.GetAllDetainedLicenses(); }

        public static bool DeleteDetainedLicense(int DetainID) { return clsDetainedLicensesDataAccess.DeleteDetainedLicense(DetainID); }

        public static bool isDetainedLicenseExist(int DetainID) { return clsDetainedLicensesDataAccess.IsDetainedLicenseExist(DetainID); }


    }

}