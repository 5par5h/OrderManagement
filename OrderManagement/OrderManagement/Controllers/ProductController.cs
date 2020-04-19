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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            string strStatus = string.Empty;
            string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            string apiUrl = BaseUrl + ApiEndPoint.productListUrl;
            var data = new NameValueCollection();
            WebClient wb = new WebClient();
            
            ResponseMessage<ProductList> Result = new ResponseMessage<ProductList>();
            #region Post Methods
            try
            {
                Result = ApiRequest.GetApi<ResponseMessage<ProductList>>(apiUrl, wb);
                if (Result.apistatus == 1)
                {
                    strStatus = Result.apimsg;
                    return View("Product", Result);
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