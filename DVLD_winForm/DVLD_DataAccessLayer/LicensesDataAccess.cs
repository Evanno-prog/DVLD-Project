﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
 
    public static class clsLicensesDataAccess
    {
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : Notes = default;
                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (int)reader["IssueReason"];
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

        public static bool GetLicenseInfoByApplicationID(ref int LicenseID, int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {

            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : Notes = default;
                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (int)reader["IssueReason"];
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
       
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Licenses VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        command.Parameters.AddWithValue("@DriverID", DriverID);

                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

                        command.Parameters.AddWithValue("@IssueDate", IssueDate);

                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                        if (Notes == null)
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);

                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        command.Parameters.AddWithValue("@IssueReason", IssueReason);

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

            catch (Exception ex) { }
            return ID;

        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Licenses
                    	SET	ApplicationID = @ApplicationID,
                    	DriverID = @DriverID,
                    	LicenseClass = @LicenseClass,
                    	IssueDate = @IssueDate,
                    	ExpirationDate = @ExpirationDate,
                    	Notes = @Notes,
                    	PaidFees = @PaidFees,
                    	IsActive = @IsActive,
                    	IssueReason = @IssueReason,
                    	CreatedByUserID = @CreatedByUserID	WHERE LicenseID = @LicenseID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        command.Parameters.AddWithValue("@DriverID", DriverID);

                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

                        command.Parameters.AddWithValue("@IssueDate", IssueDate);

                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                        if (Notes == null)
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);

                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        command.Parameters.AddWithValue("@IssueReason", IssueReason);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) {}
            return (rowsAffected > 0);

        }
   
        public static bool DeleteLicense(int LicenseID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Licenses WHERE LicenseID = @LicenseID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) {  }

            return (rowsAffected > 0);

        }

        public static bool IsLicenseExist(int LicenseID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Licenses WHERE LicenseID= @LicenseID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
     
        public static bool IsLicenseExistBySameAppliedLicenseClass(int DriverID, int LicenseClassID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "Select Found = 1 From Licenses Where DriverID = @DriverID and LicenseClass = @LicenseClassID and IsActive = 1;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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

        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                            reader.Close();
                        }
                    }
                }
            }

            catch (Exception ex) {  }

            return dt;
        }
   
        public static DataTable GetAllLicensesInfo_View(int LicenseID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ReturnLicenseInfo_View Where LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

            catch (Exception ex) {  }

            return dt;
        }
   
        public static DataTable GetLocalLicenseHistoryByLicenseID(int LicenseID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive FROM  LicenseClasses INNER JOIN Licenses ON LicenseClasses.LicenseClassID = Licenses.LicenseClass Where LicenseID = @LicenseID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

            catch (Exception ex) {  }

            return dt;
        }
   
        public static DataTable GetInternationalLicenseHistoryByLicenseID(int LicenseID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT InternationalLicenseID, ApplicationID, LLicenseID = IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive FROM InternationalLicenses Where IssuedUsingLocalLicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

            catch (Exception ex) {  }

            return dt;
        }


    }

}