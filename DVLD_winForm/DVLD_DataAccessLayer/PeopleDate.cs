using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
   

    public static class clsPeopleDataAccess
    {
 
        public static bool GetPersoneInfoByID(int PersoneID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM People WHERE PersonID = @PersoneID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersoneID", PersoneID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                PersoneID = (int)reader["PersonID"];
                                NationalNo = (string)reader["NationalNo"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : ThirdName = default;
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = Convert.ToInt16( reader["Gendor"]);
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : Email = default;
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : ImagePath = default;

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception) {  }
            return isFound;

        }
        public static bool GetPersoneInfoByNationalNo(ref int PersoneID,  string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                PersoneID = (int)reader["PersonID"];
                                NationalNo = (string)reader["NationalNo"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : ThirdName = default;
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = Convert.ToInt16( reader["Gendor"]);
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : Email = default;
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : ImagePath = default;

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception) {  }
            return isFound;

        }
  
        public static int AddNewPersone(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            try
            {
                

                    string query = @"INSERT INTO People VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        command.Parameters.AddWithValue("@FirstName", FirstName);

                        command.Parameters.AddWithValue("@SecondName", SecondName);

                        if (ThirdName == null)
                            command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        command.Parameters.AddWithValue("@LastName", LastName);

                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                        command.Parameters.AddWithValue("@Gendor", Gendor);

                        command.Parameters.AddWithValue("@Address", Address);

                        command.Parameters.AddWithValue("@Phone", Phone);

                        if (Email == null)
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                        if (ImagePath == null)
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);



                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                
            }

            catch (Exception ) {  }
            finally { connection.Close(); }
           
            return ID;

        }


        public static bool UpdatePersone(int PersoneID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            try
            {


                string query = @"UPDATE People
	SET	NationalNo = @NationalNo,
	FirstName = @FirstName,
	SecondName = @SecondName,
	ThirdName = @ThirdName,
	LastName = @LastName,
	DateOfBirth = @DateOfBirth,
	Gendor = @Gendor,
	Address = @Address,
	Phone = @Phone,
	Email = @Email,
	NationalityCountryID = @NationalityCountryID,
	ImagePath = @ImagePath	WHERE PersonID = @PersoneID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@PersoneID", PersoneID);

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        command.Parameters.AddWithValue("@FirstName", FirstName);

                        command.Parameters.AddWithValue("@SecondName", SecondName);

                        if (ThirdName == null)
                            command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        command.Parameters.AddWithValue("@LastName", LastName);

                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                        command.Parameters.AddWithValue("@Gendor", Gendor);

                        command.Parameters.AddWithValue("@Address", Address);

                        command.Parameters.AddWithValue("@Phone", Phone);

                        if (Email == null)
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                        if (ImagePath == null)
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);

                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                
            }

            catch (Exception ) {  }
            finally { connection.Close(); }
            return (rowsAffected > 0);

        }
        public static bool DeletePersone(int PersoneID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE People WHERE PersonID = @PersoneID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PersoneID", PersoneID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }

            return (rowsAffected > 0);

        }

        public static bool IsPersoneExist(int PersoneID)
        {


            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM People WHERE PersonID= @PersoneID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PersoneID", PersoneID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ) { }

            return isFound;

        }
        public static bool IsNationalNoExist(string NationalNo)
        {

            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ) { }

            return isFound;

        }

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "Select * from ListPeople_View";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                            reader.Close();
                        }
                    }
                }
            }

            catch (Exception) {  }

            return dt;
        }


    }

}