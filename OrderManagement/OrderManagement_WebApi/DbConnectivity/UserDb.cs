using Newtonsoft.Json;
using OrderManagement_WebApi.Models;
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
    public class UserDb
    {
        DBExecution _dbProcess = new DBExecution();

        public List<Users> GetAllUsers()
        {
            int recCount = 0;
            List<Users> userList = new List<Users>();
            string users = "";
            try
            {
                List<SqlParameter> dbParam = new List<SqlParameter>();
                users = _dbProcess.ExecuteReader("GetAllUserList", dbParam.ToArray(), out recCount);
            }
            catch (Exception ex)
            {

            }
            if (!string.IsNullOrEmpty(users))
            {
                userList = JsonConvert.DeserializeObject<List<Users>>(users).ToList();
            }
            return userList;
        }

        public Guid GetUserIdByEmail(string email)
        {
            Guid user_id = Guid.Empty;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {
                dbParam.Add(new SqlParameter { ParameterName = "@Email", Value = email });
                using ( DataTable data = _dbProcess.GetData("GetUserIdByEmail", dbParam.ToArray()))
                {
                    if (data.Rows.Count > 0)
                    {
                        DataRow dr = data.Rows[0];
                        user_id = Guid.Parse(dr["user_id"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return user_id;
        }

        public bool AddNewUser(Users request)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {

                dbParam.Add(new SqlParameter { ParameterName = "@user_id", Value = Guid.NewGuid()});
                dbParam.Add(new SqlParameter { ParameterName = "@first_name", Value = request.first_name });
                dbParam.Add(new SqlParameter { ParameterName = "@last_name", Value = request.last_name });
                dbParam.Add(new SqlParameter { ParameterName = "@email_address", Value = request.email_address });
                dbParam.Add(new SqlParameter { ParameterName = "@alternate_email_address", Value = request.alternate_email_address });
                dbParam.Add(new SqlParameter { ParameterName = "@Phone", Value = request.phone_number });
                dbParam.Add(new SqlParameter { ParameterName = "@Role", Value = request.user_role });
                dbParam.Add(new SqlParameter { ParameterName = "@IsDeactive", Value = true });
                dbParam.Add(new SqlParameter { ParameterName = "@Password", Value = request.password });
                dbParam.Add(new SqlParameter { ParameterName = "@CreatedDate", Value = DateTime.Now});

                result = _dbProcess.Execute("AddNewUser", dbParam.ToArray());
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool DeleteUser(string user_id)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {
                dbParam.Add(new SqlParameter { ParameterName = "@Id", Value = user_id });
                result = _dbProcess.Execute("DeleteUser", dbParam.ToArray());
            }
            catch (Exception ex)
            {
                //TODO :
            }
            return result;
        }

        public bool UpdateUser(Users request, string user_id)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {

                dbParam.Add(new SqlParameter { ParameterName = "@user_id", Value = user_id });
                dbParam.Add(new SqlParameter { ParameterName = "@first_name", Value = request.first_name });
                dbParam.Add(new SqlParameter { ParameterName = "@last_name", Value = request.last_name });
                dbParam.Add(new SqlParameter { ParameterName = "@email_address", Value = request.email_address });
                dbParam.Add(new SqlParameter { ParameterName = "@alternate_email_address", Value = request.alternate_email_address });
                dbParam.Add(new SqlParameter { ParameterName = "@Phone", Value = request.phone_number });
                dbParam.Add(new SqlParameter { ParameterName = "@Role", Value = request.user_role });
                dbParam.Add(new SqlParameter { ParameterName = "@IsDeactive", Value = request.IsDeactive });
                dbParam.Add(new SqlParameter { ParameterName = "@Password", Value = request.password });

                result = _dbProcess.Execute("UpdateUserById", dbParam.ToArray());
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}