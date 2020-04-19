using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.Models
{
    public class Order
    {
        public string shiping_address { get; set; }
        public int pincode { get; set; }
        public string email_address { get; set; }
        public List<Product> products { get; set; }
        public string phone_number { get; set; }
    }
}