using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
    public class Cart
    {
        public Guid user_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; }
        public decimal amount { get; set; }
        public decimal total_amount { get; set; }
        public bool IsOrdered { get; set; }
        public DateTime product_added_on { get; set; }
    }

    public class CartList
    {
        public List<Cart> cartList { get; set; }
    }
}