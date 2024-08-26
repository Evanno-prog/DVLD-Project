using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{

    public static class clsApplicationsDataAccess
    {
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = (int)reader["ApplicationStatus_id"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {  }
            return isFound;

        }
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Applications VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

                        command.Parameters.AddWithValue("@PaidFees", PaidFees);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                }
            }

            catch (Exception ex) {  }
            return ID;

        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Applications
	SET	ApplicantPersonID = @ApplicantPersonID,
	ApplicationDate = @ApplicationDate,
	ApplicationTypeID = @ApplicationTypeID,
	ApplicationStatus_id = @ApplicationStatus,
	LastStatusDate = @LastStatusDate,
	PaidFees = @PaidFees,
	CreatedByUserID = @CreatedByUserID	WHERE ApplicationID = @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

                        command.Parameters.AddWithValue("@PaidFees", PaidFees);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) {}
            return (rowsAffected > 0);

        }
        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Applications WHERE ApplicationID = @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) {  }

            return (rowsAffected > 0);

        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Applications WHERE ApplicationID= @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex) {  }

            return isFound;

        }

        public static DataTable GetAllApplications()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM LocalDrivingLicenseApplication_View";
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

        public static DataTable GetLocalApplicationsInfoByID(int LDLApplicationID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "Select * From LocalDrivingLicenseApplication_View where LocalDrivingLicenseApplicationID = @LDLAPPId;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LDLAppId", LDLApplicationID);
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


        public static DataTable GetListApplicationLicenseClassPersonId(int PersonID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    
                    string query = "SELECT LocalDrivingLicenseApplications.LicenseClassID,Applications.ApplicationStatus_id FROM Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID " +
                        "Where ApplicantPersonID = @PersonID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
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

            catch (Exception )  { }

            return dt;

        }
    }

}