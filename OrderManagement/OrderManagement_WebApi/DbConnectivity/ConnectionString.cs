using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrderManagement_WebApi.DbConnectivity
{
    public class DBConnection
    {
        private static Configuration configuration;
        
        public static SqlConnection Connection(HttpConfiguration configuration)
        {
            string connStr = ConfigurationManager.ConnectionStrings["OrderMangement"].ConnectionString ;
            return new SqlConnection(connStr);
        }
    }
}