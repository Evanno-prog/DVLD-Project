using System;
using System.Data;
using DVLD_DataAccessLayer;
namespace DVLD_BussinessLayer
{

    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }


        public clsLicenseClass()
        {
            this.LicenseClassID = default;
            this.ClassName = default;
            this.ClassDescription = default;
            this.MinimumAllowedAge = default;
            this.DefaultValidityLength = default;
            this.ClassFees = default;


            Mode = enMode.AddNew;

        }

        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;


            Mode = enMode.Update;

        }

        private bool _AddNewLicenseClass()
        {
            //call DataAccess Layer 

            this.LicenseClassID = clsLicenseClassesDataAccess.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

            return (this.LicenseClassID != -1);

        }

        private bool _UpdateLicenseClass()
        {
            //call DataAccess Layer 

            return clsLicenseClassesDataAccess.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = default;
            string ClassDescription = default;
            byte MinimumAllowedAge = default;
            byte DefaultValidityLength = default;
            decimal ClassFees = default;


            if (clsLicenseClassesDataAccess.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClass();

            }




            return false;
        }

        public static DataTable GetAllLicenseClasses() { return clsLicenseClassesDataAccess.GetAllLicenseClasses(); }

        public static bool DeleteLicenseClass(int LicenseClassID) { return clsLicenseClassesDataAccess.DeleteLicenseClass(LicenseClassID); }

        public static bool isLicenseClassExist(int LicenseClassID) { return clsLicenseClassesDataAccess.IsLicenseClassExist(LicenseClassID); }


    }

}