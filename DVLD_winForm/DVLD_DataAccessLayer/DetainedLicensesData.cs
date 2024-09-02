using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{

    public static class clsDetainedLicensesDataAccess
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                DetainID = (int)reader["DetainID"];
                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = (decimal)reader["FineFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"];
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : ReleaseDate = default;
                                ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int)reader["ReleasedByUserID"] : ReleasedByUserID = default;
                                ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : ReleaseApplicationID = default;

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {}
            return isFound;

        }
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO DetainedLicenses VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID?, @ReleaseApplicationID?)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        command.Parameters.AddWithValue("@DetainDate", DetainDate);

                        command.Parameters.AddWithValue("@FineFees", FineFees);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        if (ReleaseDate == null)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        if (ReleasedByUserID == null)
                            command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        if (ReleaseApplicationID == null)
                            command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);



                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                }
            }

            catch (Exception ex) {}
            return ID;

        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE DetainedLicenses
	SET	LicenseID = @LicenseID,
	DetainDate = @DetainDate,
	FineFees = @FineFees,
	CreatedByUserID = @CreatedByUserID,
	IsReleased = @IsReleased,
	ReleaseDate = @ReleaseDate,
	ReleasedByUserID = @ReleasedByUserID,
	ReleaseApplicationID = @ReleaseApplicationID	WHERE DetainID = @DetainID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        command.Parameters.AddWithValue("@DetainDate", DetainDate);

                        command.Parameters.AddWithValue("@FineFees", FineFees);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        if (ReleaseDate == null)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        if (ReleasedByUserID == null)
                            command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        if (ReleaseApplicationID == null)
                            command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) {}
            return (rowsAffected > 0);

        }
        public static bool DeleteDetainedLicense(int DetainID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE DetainedLicenses WHERE DetainID = @DetainID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) {}

            return (rowsAffected > 0);

        }

        public static bool IsDetainedLicenseExist(int DetainID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM DetainedLicenses WHERE DetainID= @DetainID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return isFound;

        }

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM DetainedLicenses";
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

            catch (Exception ex) { }

            return dt;
        }


    }

}