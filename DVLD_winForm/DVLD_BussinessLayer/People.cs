using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{

    public class clsPersone
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersoneID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }


        public clsPersone()
        {
            this.PersoneID = default;
            this.NationalNo = default;
            this.FirstName = default;
            this.SecondName = default;
            this.ThirdName = default;
            this.LastName = default;
            this.DateOfBirth = default;
            this.Gendor = default;
            this.Address = default;
            this.Phone = default;
            this.Email = default;
            this.NationalityCountryID = default;
            this.ImagePath = default;


            Mode = enMode.AddNew;

        }

        private clsPersone(int PersoneID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersoneID = PersoneID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;


            Mode = enMode.Update;

        }

        private bool _AddNewPersone()
        {
            //call DataAccess Layer 

            this.PersoneID = clsPeopleDataAccess.AddNewPersone(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersoneID != -1);

        }

        private bool _UpdatePersone()
        {
            //call DataAccess Layer 

            return clsPeopleDataAccess.UpdatePersone(this.PersoneID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }

        public static clsPersone Find(int PersoneID)
        {
            string NationalNo = default;
            string FirstName = default;
            string SecondName = default;
            string ThirdName = default;
            string LastName = default;
            DateTime DateOfBirth = default;
            int Gendor = default;
            string Address = default;
            string Phone = default;
            string Email = default;
            int NationalityCountryID = default;
            string ImagePath = default;


            if (clsPeopleDataAccess.GetPersoneInfoByID(PersoneID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                return new clsPersone(PersoneID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;

        }
      
        public static clsPersone Find(string NationalNo)
        {
            int PersonID = default;
            string FirstName = default;
            string SecondName = default;
            string ThirdName = default;
            string LastName = default;
            DateTime DateOfBirth = default;
            int Gendor = default;
            string Address = default;
            string Phone = default;
            string Email = default;
            int NationalityCountryID = default;
            string ImagePath = default;


            if (clsPeopleDataAccess.GetPersoneInfoByNationalNo(ref PersonID,  NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                return new clsPersone(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPersone())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePersone();

            }




            return false;
        }

        public static DataTable GetAllPeople() { return clsPeopleDataAccess.GetAllPeople(); }

        public static bool DeletePersone(int PersoneID) { return clsPeopleDataAccess.DeletePersone(PersoneID); }

        public static bool isPersoneExist(int PersoneID) { return clsPeopleDataAccess.IsPersoneExist(PersoneID); }
        public static bool IsNationalNoExist(string NationalNo) { return clsPeopleDataAccess.IsNationalNoExist(NationalNo); }

        
    }

}