﻿using System;
using System.Data.SqlClient;
using System.Data;
using DVLD_DataAccessLayer.Global_Class;

namespace DVLD_DataAccessLayer
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                clsLogging.LogExceptionToTheEventLog(ex.Message);
                isFound = false;
            }

            finally
            {
                connection.Close();
            }

            return isFound;
        }
       
        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {
            bool isFound = false;
            SqlConnection connection = new
           SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    ID = (int)reader["CountryID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogging.LogExceptionToTheEventLog(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
       
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new
           SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries order by CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogging.LogExceptionToTheEventLog(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
