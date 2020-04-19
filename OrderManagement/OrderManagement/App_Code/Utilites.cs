using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.App_Code
{
    public static class Uilities
    {
        static string strLastMenuFocus = string.Empty;
        public static string IsActiveTab(this HtmlHelper html, string toCheckInView, string returnValue = "active show")
        {
            string rVal = (html.ViewBag.CurrentLinkPage == toCheckInView) ? returnValue : string.Empty;
            return rVal;
        }

        public static string IsActive(this HtmlHelper html, string toCheckInView, string returnValue = "active show")
        {
            string rVal = (html.ViewBag.CurrentTab == toCheckInView) ? returnValue : string.Empty;
            return rVal;
        }

        //public static string WasSideNavCollpased(this HtmlHelper html, ISession curSession, string menuToggleClassName = "sidenav-toggled")
        //{
        //    string isCollapsed = curSession.GetString("sideNavCollapsed");
        //    var rVal = string.Empty;
        //    if (!string.IsNullOrEmpty(isCollapsed))
        //    {
        //        if (isCollapsed == "false")
        //        {
        //            rVal = menuToggleClassName;
        //        }
        //    }
        //    return rVal;
        //}
    }
}