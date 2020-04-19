using OrderManagement_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.DbConnectivity
{
    public class CartDb
    {
        DBExecution _dbProcess = new DBExecution();

        public bool AddProductIntoCart(Cart request)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {
                dbParam.Add(new SqlParameter { ParameterName = "@user_id", Value = request.user_id });
                dbParam.Add(new SqlParameter { ParameterName = "@product_id", Value = request.product_id });
                dbParam.Add(new SqlParameter { ParameterName = "@quantity", Value = request.quantity });
                dbParam.Add(new SqlParameter { ParameterName = "@amount", Value = request.amount });
                dbParam.Add(new SqlParameter { ParameterName = "@product_added_on", Value = DateTime.Now });

                result = _dbProcess.Execute("AddProductToCart", dbParam.ToArray());
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public bool DeleteProductFromCart(Guid product_id , Guid user_id)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {
                dbParam.Add(new SqlParameter { ParameterName = "@user_id", Value = user_id });
                dbParam.Add(new SqlParameter { ParameterName = "@product_id", Value = product_id });

                result = _dbProcess.Execute("DeleteProductFromCart", dbParam.ToArray());
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}