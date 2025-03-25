using DVLD_DataAccessLayer.Global_Class;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    

    public static class clsRetakeTestsDataAccess
    {
        public static bool GetRetakeTestInfoByID(int RetakeTestID, ref int TestAppointment_id, ref decimal RetakeTestFees)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM RetakeTests WHERE RetakeTestID = @RetakeTestID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RetakeTestID", RetakeTestID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                RetakeTestID = (int)reader["RetakeTestID"];
                                TestAppointment_id = (int)reader["TestAppointment_id"];
                                RetakeTestFees = (decimal)reader["RetakeTestFees"];

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }
            return isFound;

        }
        public static bool GetRetakeTestInfoByTestAppointmentID(ref int RetakeTestID,  int TestAppointment_id, ref decimal RetakeTestFees)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM RetakeTests WHERE TestAppointment_id = @TestAppointment_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointment_id", TestAppointment_id);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                RetakeTestID = (int)reader["RetakeTestID"];
                                TestAppointment_id = (int)reader["TestAppointment_id"];
                                RetakeTestFees = (decimal)reader["RetakeTestFees"];

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }
            return isFound;

        }
 
        public static int AddNewRetakeTest(int TestAppointment_id, decimal RetakeTestFees)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO RetakeTests VALUES (@TestAppointment_id, @RetakeTestFees)
                             SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@TestAppointment_id", TestAppointment_id);

                        command.Parameters.AddWithValue("@RetakeTestFees", RetakeTestFees);




                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                }
            }

            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }
            return ID;

        }


        public static bool UpdateRetakeTest(int RetakeTestID, int TestAppointment_id, decimal RetakeTestFees)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE RetakeTests
                        	SET	TestAppointment_id = @TestAppointment_id,
                        	RetakeTestFees = @RetakeTestFees	WHERE RetakeTestID = @RetakeTestID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@RetakeTestID", RetakeTestID);

                        command.Parameters.AddWithValue("@TestAppointment_id", TestAppointment_id);

                        command.Parameters.AddWithValue("@RetakeTestFees", RetakeTestFees);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }
            return (rowsAffected > 0);

        }
        public static bool DeleteRetakeTest(int RetakeTestID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE RetakeTests WHERE RetakeTestID = @RetakeTestID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@RetakeTestID", RetakeTestID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }

            return (rowsAffected > 0);

        }

        public static bool IsRetakeTestExist(int RetakeTestID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM RetakeTests WHERE RetakeTestID= @RetakeTestID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@RetakeTestID", RetakeTestID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }

            return isFound;

        }

        public static DataTable GetAllRetakeTests()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM RetakeTests";
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

            catch (Exception ex) { clsLogging.LogExceptionToTheEventLog(ex.Message); }

            return dt;
        }

    }

}