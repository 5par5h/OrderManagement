using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyCart()
        {
            return View();
        }

        public ActionResult MyWishlist()
        {
            return View();
        }

        public ActionResult MyOrder()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            return View();
        }

        public ActionResult MyNotification()
        {
            return View();
        }
    }
}