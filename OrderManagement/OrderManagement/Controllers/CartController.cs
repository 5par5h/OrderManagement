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
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(string product_id)
        {
            string strStatus = string.Empty;
            string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            string apiUrl = BaseUrl + ApiEndPoint.addToCart;
            var data = new NameValueCollection();
            data["user_id"] = Session["EmailId"].ToString();
            data["product_id"] = product_id;
            WebClient wb = new WebClient();

            ResponseMessage<string> Result = new ResponseMessage<string>();
            #region Post Methods
            try
            {
                Result = ApiRequest.PostAPi<ResponseMessage<string>>(apiUrl,data, wb);
                if (Result.apistatus == 1)
                {
                    strStatus = Result.apimsg;
                    return RedirectToAction("Index","Product");
                }
                else
                {
                    TempData["msg"] = Result.apimsg;
                }
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error While Login. Please Try again..";
                strStatus = "Error while Login - " + ex.Message.ToString() + ex.StackTrace;
                return RedirectToAction("Index", "Product");
            }
            #endregion

        }
    }
}