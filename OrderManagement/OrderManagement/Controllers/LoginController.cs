using OrderManagement.Global;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult ProcessLogin(string email_address, string password)
        {
            if (ModelState.IsValid)
            {
                string strStatus = string.Empty;
                string strPassword = string.Empty;
                string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString() ;
                string apiUrl = BaseUrl + ApiEndPoint.loginUrl;
                var data = new NameValueCollection();
                WebClient wb = new WebClient();
                ResponseMessage<LoginResponse> Result = new ResponseMessage<LoginResponse>();
                #region Post Methods
                try
                {

                    strPassword = email_address;//login.password;
                    string strEmailId = password;// login.email_address;
                    data["email"] = strEmailId;
                    data["password"] = strPassword;

                    Result = ApiRequest.PostAPi<ResponseMessage<LoginResponse>>(apiUrl, data, wb);
                    if (Result.apistatus == 1)
                    {
                        ViewBag.emailId = Result.Data.email_address;
                        Session["EmailId"] = Result.Data.email_address;
                        Session["UserRole"] = Result.Data.user_role;
                        strStatus = Result.apimsg;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["msg"] = Result.apimsg;
                    }
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["msg"] = "Error While Login. Please Try again..";
                    strStatus = "Error while Login - " + ex.Message.ToString() + ex.StackTrace;
                    return RedirectToAction("Index", "Home");
                }
                #endregion
            }
            return RedirectToAction("Index", "Home");
        }
    }
}