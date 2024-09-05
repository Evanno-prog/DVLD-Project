using System;
using System.Data;
using DVLD_DataAccessLayer;
namespace DVLD_BussinessLayer
{

    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
   
        public enMode Mode = enMode.AddNew;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            this.LicenseID = default;
            this.ApplicationID = default;
            this.DriverID = default;
            this.LicenseClass = default;
            this.IssueDate = default;
            this.ExpirationDate = default;
            this.Notes = default;
            this.PaidFees = default;
            this.IsActive = default;
            this.IssueReason = default;
            this.CreatedByUserID = default;


            Mode = enMode.AddNew;

        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;


            Mode = enMode.Update;

        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicensesDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);

        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicensesDataAccess.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = default;
            int DriverID = default;
            int LicenseClass = default;
            DateTime IssueDate = default;
            DateTime ExpirationDate = default;
            string Notes = default;
            decimal PaidFees = default;
            bool IsActive = default;
            int IssueReason = default;
            int CreatedByUserID = default;


            if (clsLicensesDataAccess.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;

        }
     
        public static clsLicense FindLicenseInfoByApplicationID(int ApplicationID)
        {
            
            int LicenseID = default;
            int DriverID = default;
            int LicenseClass = default;
            DateTime IssueDate = default;
            DateTime ExpirationDate = default;
            string Notes = default;
            decimal PaidFees = default;
            bool IsActive = default;
            int IssueReason = default;
            int CreatedByUserID = default;


            if (clsLicensesDataAccess.GetLicenseInfoByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static DataTable GetAllLicenses() { return clsLicensesDataAccess.GetAllLicenses(); }
    
        public static DataTable GetAllLicensesInfo_View(int LicenseID) { return clsLicensesDataAccess.GetAllLicensesInfo_View(LicenseID); }
        public static DataTable GetAllLocalLicenseHistoryByDriverID(int DriverID) { return clsLicensesDataAccess.GetAllLocalLicenseHistoryByDriverID(DriverID); }

        public static bool DeleteLicense(int LicenseID) { return clsLicensesDataAccess.DeleteLicense(LicenseID); }

        public static bool isLicenseExist(int LicenseID) { return clsLicensesDataAccess.IsLicenseExist(LicenseID); }
     
        public static bool IsLicenseExistBySameAppliedLicenseClass(int DriverID, int LicenseClassID) { return clsLicensesDataAccess.IsLicenseExistBySameAppliedLicenseClass(DriverID,LicenseClassID); }


    }

}
