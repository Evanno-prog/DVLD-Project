using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_WinForm_PresentationLayer.Global_Classes
{
    public class clsUtil
    {

        public static string GenerateGUID()
        {
            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();
            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name 
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // This funciton will copy the image to the
            // project images folder after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
           
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }

            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }


        // Hash password with Salt techniques
        // [1]: Generate salt
        public static string GenerateSalt(int size = 16)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[size];
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }

        }

        // [2]: Hash password with salt
        public static string HashPasswordWithSalt(string password, string salt)
        {

            var CombinedHashWithSalt = Encoding.UTF8.GetBytes(password + salt);

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] Hash = sha256.ComputeHash(CombinedHashWithSalt);
                return Convert.ToBase64String(Hash);
            }

        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;
            string salt = GenerateSalt();
            string HashPasswordWithsalt = HashPasswordWithSalt(NewPassword, salt);
            SqlConnection connection = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=sa123456;");
            string query = @"Update Users 
                 set Password = @Password,
                     Salt = @salt
                 where UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", HashPasswordWithsalt);
            command.Parameters.AddWithValue("@salt", salt);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static bool DoesHashedPasswordWithSaltMatch(int UserID, string EnteredPassword)
        {

            string StoredSalt = default;
            string StoredHashWithSalt = default;

            SqlConnection connection = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=sa123456;");
            string query = @"Select Password, Salt from Users 
                             where UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    StoredSalt = (string)reader["Salt"];
                    StoredHashWithSalt = (string)reader["Password"];
                    // First: Hash entered password with stored salt
                    string Enteredpassword = HashPasswordWithSalt(EnteredPassword, StoredSalt);
                    return Enteredpassword == StoredHashWithSalt;

                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }


        }


    }
}