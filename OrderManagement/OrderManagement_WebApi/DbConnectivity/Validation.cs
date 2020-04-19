using OrderManagement_WebApi.Common;
using OrderManagement_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrderManagement_WebApi.DbConnectivity
{
    public class Validation
    {
        UserDb db = new UserDb();
        #region User
        public bool ValidationNewUser(Users request,HttpConfiguration configuration,  out string validationError)
        {
            bool result = false;
            string user_id = "";
            validationError = "";
            if (!string.IsNullOrEmpty(request.first_name) && !string.IsNullOrEmpty(request.email_address) && !string.IsNullOrEmpty(request.phone_number)
               && !string.IsNullOrEmpty(request.user_role) && request.user_id != Guid.Empty)
            {
                user_id = db.GetUserIdByEmail(request.email_address, configuration).ToString();
                if (!string.IsNullOrEmpty(user_id))
                {
                    result = true;
                }
            }
            else
            {
                validationError = ErrorString.IncompleteUserDetails;
            }
            return result;
        }
        #endregion
    }
}