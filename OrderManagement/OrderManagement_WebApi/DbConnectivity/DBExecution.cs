using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrderManagement_WebApi.DbConnectivity
{
    public class DBExecution
    {

        public DataTable GetData(string procedureName, SqlParameter[] parameterCollection)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString); 
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Connection = connection;
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                connection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                //TODO :
            }

            return new DataTable();
        }

        public DataTable GetData(string procedureName, SqlParameter[] parameterCollection, out int totalRecordCount)
        {
            totalRecordCount = 0;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderManagment"].ConnectionString); ;
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                // adding a return value param
                command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                command.Connection = connection;
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                totalRecordCount = (int)command.Parameters["@return_value"].Value;
                connection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                //TODO : 
            }

            return new DataTable();
        }

        public bool Execute(string procedureName, SqlParameter[] parameterCollection)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderManagment"].ConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Connection = connection;
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                    return true;
            }
            catch (Exception ex)
            {
                //TODO :
            }

            return false;
        }

        public bool Execute(string procedureName, SqlParameter[] parameterCollection, out int rowsAffected)
        {
            rowsAffected = 0;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString); ;
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Connection = connection;
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                    return true;
            }
            catch (Exception ex)
            {
                // TODO : 
            }

            return false;
        }

        public bool Execute(string procedureName, SqlParameter[] parameterCollection, out string lastRecord)
        {
            lastRecord = string.Empty;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString); ;
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                command.Connection = connection;
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                lastRecord = command.Parameters["@return_value"].Value.ToString();
                connection.Close();

                if (rowsAffected > 0)
                    return true;
            }
            catch (Exception ex)
            {
                // TODO : 
            }

            return false;
        }

        public string ExecuteReader(string procedureName, SqlParameter[] parameterCollection)
        {
            string data = string.Empty;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Connection = connection;
                connection.Open();
                using (SqlDataReader rd = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (rd.Read())
                    {
                        data = data + rd.GetString(0);
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                //TODO : 
            }

            return data;
        }

        public string ExecuteReader(string procedureName, SqlParameter[] parameterCollection, out int totalRecordCount)
        {
            string data = string.Empty;
            totalRecordCount = 0;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                command.Connection = connection;
                connection.Open();
                using (SqlDataReader rd = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (rd.Read())
                    {
                        data = data + rd.GetString(0);
                    }
                }
                totalRecordCount = (int)command.Parameters["@return_value"].Value;
                connection.Close();

            }
            catch (Exception ex)
            {
                //TODO : 
            }

            return data;
        }

        public string ExecuteReader(string procedureName, SqlParameter[] parameterCollection, out string valueName)
        {
            string data = string.Empty;
            valueName = string.Empty;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                command.Connection = connection;
                connection.Open();
                using (SqlDataReader rd = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (rd.Read())
                    {
                        data = data + rd.GetString(0);
                    }
                }
                valueName = command.Parameters["@return_value"].Value.ToString();
                connection.Close();

            }
            catch (Exception ex)
            {
                //TODO : 
            }

            return data;
        }

        public bool ProcessScalar(string procedureName, SqlParameter[] parameterCollection, out string rVal)
        {
            rVal = string.Empty;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Connection = connection;
                connection.Open();
                rVal = (string)command.ExecuteScalar();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                //TODO : 
            }

            return false;
        }

        public bool ProcessScalar(string procedureName, SqlParameter[] parameterCollection, out int rVal)
        {
            rVal = int.MinValue;
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameterCollection);
                command.Connection = connection;
                connection.Open();
                rVal = (int)command.ExecuteScalar();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                //TODO : 
            }

            return false;
        }

    }
}