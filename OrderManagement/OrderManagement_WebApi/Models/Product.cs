using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.Models
{
    public class Product
    {
        public Guid product_id;
        public string product_name;
        public string product_description;
        public float weight;
        public float height;
        public string image_url;
        public int SKU;
        public Guid barcode;
        public int available_qty;
        public decimal price;
    }

    public class ProductList
    {
        public List<Product> productList { get; set; }
        public int totalCount { get; set; }
    }
}