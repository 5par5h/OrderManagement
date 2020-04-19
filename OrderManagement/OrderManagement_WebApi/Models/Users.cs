using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.Models
{
    public class Users
    {
        public Guid user_id ;
        public string first_name;
        public string last_name;
        public string email_address;
        public string password;
        public string alternate_email_address;
        public string phone_number;
        public DateTime created_date;
        public string user_role;
        public bool IsDeactive;
    }
    
}