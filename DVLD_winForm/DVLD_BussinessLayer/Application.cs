using System;
using System.Data;
using DVLD_DataAccessLayer;
namespace DVLD_BussinessLayer
{

    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplication()
        {
            this.ApplicationID = default;
            this.ApplicantPersonID = default;
            this.ApplicationDate = default;
            this.ApplicationTypeID = default;
            this.ApplicationStatus = default;
            this.LastStatusDate = default;
            this.PaidFees = default;
            this.CreatedByUserID = default;


            Mode = enMode.AddNew;

        }

        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;


            Mode = enMode.Update;

        }

        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplicationsDataAccess.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);

        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplicationsDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }

        public static clsApplication Find(int ApplicationID)
        {
            int ApplicantPersonID = default;
            DateTime ApplicationDate = default;
            int ApplicationTypeID = default;
            int ApplicationStatus = default;
            DateTime LastStatusDate = default;
            decimal PaidFees = default;
            int CreatedByUserID = default;


            if (clsApplicationsDataAccess.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }




            return false;
        }

        public static DataTable GetAllApplications() { return clsApplicationsDataAccess.GetAllApplications(); }
        public static DataTable GetLocalApplications(int LDL_ApplicationID) { return clsApplicationsDataAccess.GetLocalApplicationsInfoByID(LDL_ApplicationID); }

        public static bool DeleteApplication(int ApplicationID) { return clsApplicationsDataAccess.DeleteApplication(ApplicationID); }

        public static bool isApplicationExist(int ApplicationID) { return clsApplicationsDataAccess.IsApplicationExist(ApplicationID); }

        public static DataTable GetListApplicationLicenseClassPersonId(int PersonID)
        {
            return clsApplicationsDataAccess.GetListApplicationLicenseClassPersonId(PersonID);
        }
    }

}