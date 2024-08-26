using System;
using System.IO;
namespace DVLD_BussinessLayer
{

    public class UserPersistenceManager
    {

        private const string TXT_FILE_PATH = "Users.txt";
        public static void SaveUser(string username, string password)
        {
            string textToWrite = $"{username} {password}";
            File.WriteAllText(TXT_FILE_PATH, textToWrite);
        }

        public static (string username, string password)? LoadUser()
        {

            if (File.Exists(TXT_FILE_PATH))
            {
                string[] lines = File.ReadAllLines(TXT_FILE_PATH);
                if (lines.Length > 0)
                {
                    string[] userData = lines[0].Split(' ');
                    if (userData.Length >= 2)
                    {
                        return (userData[0], userData[1]);
                    }
                }
            }

            return null;
        }
    
        public static void DeleteSavedUser()
        {
            if (File.Exists(TXT_FILE_PATH))
            {
                File.Delete(TXT_FILE_PATH);
            }
        }
    }
}
