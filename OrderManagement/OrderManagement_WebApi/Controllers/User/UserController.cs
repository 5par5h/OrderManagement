using OrderManagement_WebApi.Common;
using OrderManagement_WebApi.DbConnectivity;
using OrderManagement_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_WebApi.Controllers.User
{
    public class UserController : ApiController
    {
        UserDb _userDb = new UserDb();

        private HttpConfiguration configuration;
        public UserController()
            : this(GlobalConfiguration.Configuration)
        {
        }
       
        public UserController(HttpConfiguration configuration)
        {
            this.configuration = configuration;
        }

        Validation apiValidation = new Validation();

        [HttpPost]
        public IHttpActionResult AddUser(Users request)
        {
            //Users request = new Users();
            var response = new ResponseMessage<string>();
            response.apistatus = APIResponseStatus.Fail;
            response.apimsg = TextString.TextFail;
            string validationError = string.Empty;
            bool result = false;
            var isDuplicate = apiValidation.ValidationNewUser(request, configuration, out validationError);
            if (isDuplicate)
            {
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Success, apimsg = TextString.TextOkay, Data = validationError });
            }

            if (_userDb.AddNewUser(request))
            {
                response.apistatus = APIResponseStatus.Success;
                response.apimsg = TextString.TextOkay;
                response.Data = TextString.UserAdded;
                return Ok(response);
            }
            return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = TextString.FailedToAddUser });
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(Guid user_id)
        {
            var response = new ResponseMessage<string>();
            response.apistatus = APIResponseStatus.Fail;
            response.apimsg = TextString.TextFail;
            string validationError = string.Empty;
            try
            {
                if (_userDb.DeleteUser(user_id.ToString()))
                {
                    response.apistatus = APIResponseStatus.Success;
                    response.apimsg = TextString.TextOkay;
                    response.Data = TextString.UserDeleted;
                    return Ok(response);
                }
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = TextString.FailedToDeleteUser });
            }
            catch (Exception exe)
            {
                //TODO :
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = ErrorString.APIError });
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(Users request, string user_id)
        {

            var response = new ResponseMessage<string>();
            response.apistatus = APIResponseStatus.Fail;
            response.apimsg = TextString.TextFail;
            string validationError = string.Empty;
            bool result = false;
            try
            {
            if (_userDb.UpdateUser(request, user_id))
                {
                    response.apistatus = APIResponseStatus.Success;
                    response.apimsg = TextString.TextOkay;
                    response.Data = TextString.UserUpdated;
                    return Ok(response);
                }
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = TextString.FailedToUpdateUser });
            }
            catch (Exception exe)
            {
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = ErrorString.APIError});
            }
        }

        //[HttpGet]
        //public IHttpActionResult GetAllUsers(string user_id)
        //{

        //}

        //public IHttpActionResult GetUserByIdOrEmail(Users request)
        //{ }
    }
}
