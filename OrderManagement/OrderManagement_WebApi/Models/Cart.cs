using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.Models
{
    public class Cart
    {
        public Guid user_id;
        public Guid product_id;
        public int quantity;
        public decimal amount;
        public decimal total_amount;
        public bool IsOrdered;
        public DateTime product_added_on;
    }
}