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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrder(ProductList product)
        {
            string strStatus = string.Empty;
            string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            string apiUrl = BaseUrl + ApiEndPoint.addOrder;
            var data = new NameValueCollection();
            data["userid"] = Session["EmailId"].ToString();
            WebClient wb = new WebClient();

            ResponseMessage<Order> Result = new ResponseMessage<Order>();
            #region Post Methods
            try
            {
                Result = ApiRequest.PostAPi<ResponseMessage<Order>>(apiUrl,data, wb);
                if (Result.apistatus == 1)
                {
                    TempData["msg"] = Result.apimsg;
                    return View("Order");
                }
                else
                {
                    TempData["msg"] = Result.apimsg;
                }
                return View("Product", Result);
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error While Login. Please Try again..";
                strStatus = "Error while Login - " + ex.Message.ToString() + ex.StackTrace;
                return View("Product", Result);
            }
            #endregion
        }
    }
}