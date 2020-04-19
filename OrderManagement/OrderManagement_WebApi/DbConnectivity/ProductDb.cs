using Newtonsoft.Json;
using OrderManagement_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.DbConnectivity
{
    public class ProductDb
    {
        DBExecution _dbProcess = new DBExecution();

        public bool AddProuct(Product request)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {

                dbParam.Add(new SqlParameter { ParameterName = "@product_id", Value = Guid.NewGuid() });
                dbParam.Add(new SqlParameter { ParameterName = "@product_name", Value = request.product_name });
                dbParam.Add(new SqlParameter { ParameterName = "@product_description", Value = request.product_description });
                dbParam.Add(new SqlParameter { ParameterName = "@weight", Value = request.weight });
                dbParam.Add(new SqlParameter { ParameterName = "@height", Value = request.height });
                dbParam.Add(new SqlParameter { ParameterName = "@image_url", Value = request.image_url });
                dbParam.Add(new SqlParameter { ParameterName = "@SKU", Value = request.SKU });
                dbParam.Add(new SqlParameter { ParameterName = "@barcode", Value = request.barcode });
                dbParam.Add(new SqlParameter { ParameterName = "@available_qty", Value = Convert.ToInt32(request.available_qty) });
                dbParam.Add(new SqlParameter { ParameterName = "@price", Value = Convert.ToDecimal(request.price) });
                result = _dbProcess.Execute("AddNewProduct", dbParam.ToArray());
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool DeleteProduct(Guid product_id)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {
                dbParam.Add(new SqlParameter { ParameterName = "@Id", Value = product_id.ToString() });
                result = _dbProcess.Execute("DeleteProductById", dbParam.ToArray());
            }
            catch (Exception ex)
            {
                //TODO :
            }
            return result;
        }

        public List<Product> GetAllProducts()
        {
            int recCount = 0;
            List<Product> productList = new List<Product>();
            string products = "";
            try
            {
                List<SqlParameter> dbParam = new List<SqlParameter>();
                products = _dbProcess.ExecuteReader("GetAllProducts", dbParam.ToArray(), out recCount);
            }
            catch (Exception ex)
            {

            }
            if (!string.IsNullOrEmpty(products))
            {
                productList = JsonConvert.DeserializeObject<List<Product>>(products).ToList();
            }
            return productList;
        }
        
        public bool UpdateProduct(Product request, Guid product_id)
        {
            bool result = false;
            List<SqlParameter> dbParam = new List<SqlParameter>();
            try
            {

                dbParam.Add(new SqlParameter { ParameterName = "@product_id", Value = Convert.ToString(product_id) });
                dbParam.Add(new SqlParameter { ParameterName = "@product_name", Value = request.product_name });
                dbParam.Add(new SqlParameter { ParameterName = "@product_description", Value = request.product_description });
                dbParam.Add(new SqlParameter { ParameterName = "@weight", Value = request.weight });
                dbParam.Add(new SqlParameter { ParameterName = "@height", Value = request.height });
                dbParam.Add(new SqlParameter { ParameterName = "@image_url", Value = request.image_url });
                dbParam.Add(new SqlParameter { ParameterName = "@SKU", Value = request.SKU });
                dbParam.Add(new SqlParameter { ParameterName = "@barcode", Value = request.barcode });
                dbParam.Add(new SqlParameter { ParameterName = "@available_qty", Value = Convert.ToInt32(request.available_qty) });
                dbParam.Add(new SqlParameter { ParameterName = "@price", Value = Convert.ToDecimal(request.price) });

                result = _dbProcess.Execute("UpdateProduct", dbParam.ToArray());
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public List<Product> GetProductByName(string product_name)
        {
            int recCount = 0;
            List<Product> productList = new List<Product>();
            string products = "";
            try
            {
                List<SqlParameter> dbParam = new List<SqlParameter>();
                dbParam.Add(new SqlParameter { ParameterName = "@product_name", Value = product_name });
                products = _dbProcess.ExecuteReader("GetAllProductByName", dbParam.ToArray(), out recCount);
            }
            catch (Exception ex)
            {

            }
            if (!string.IsNullOrEmpty(products))
            {
                productList = JsonConvert.DeserializeObject<List<Product>>(products).ToList();
            }
            return productList;
        }

    }
}