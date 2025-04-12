using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsUser
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID { set; get; }
        public int PersonID { set; get; }

        public clsPerson PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public string Salt { set; get; }

        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            this.Salt = "";
            Mode = enMode.AddNew;
        }
        private clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive, string Salt)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Salt = Salt;
            Mode = enMode.Update;
        }
        private bool _AddNewUser()
        {
            //call DataAccess Layer 
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName,
            this.Password, this.IsActive, this.Salt);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName,
            this.Password, this.IsActive, this.Salt);
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "", Salt = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive, ref Salt);
            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, Salt);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "", Salt = "";
            bool IsActive = false;
            bool IsFound = clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive, ref Salt);
            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, Salt);
            else
                return null;
        }
 
        public static string HashPasswordWithSalt(string password, string salt)
        {

            var CombinedHashWithSalt = Encoding.UTF8.GetBytes(password + salt);

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] Hash = sha256.ComputeHash(CombinedHashWithSalt);
                return Convert.ToBase64String(Hash);
            }

        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {

            // Hash entered password with Stored salt
            string StoredSalt = GetStoredSaltByUserName(UserName);
            Password = HashPasswordWithSalt(Password, StoredSalt);

            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;
            string Salt = "";
            
            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive, ref Salt);
            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, Salt);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static string GetStoredSaltByUserName(string UserName)
        {
            return clsUserData.GetStoredSaltByUserName(UserName);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }

        public bool ChangePassword()
        {
            return clsUserData.ChangePassword(this.UserID, this.Password, this.Salt);
        }

    }
}
