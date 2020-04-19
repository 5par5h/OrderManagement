using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
    public class Product
    {
        public Guid product_id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public string image_url { get; set; }
        public int SKU { get; set; }
        public Guid barcode { get; set; }
        public int available_qty { get; set; }
        public decimal price { get; set; }
    }

    public class ProductList
    {
        public List<Product> productList;
    }
}