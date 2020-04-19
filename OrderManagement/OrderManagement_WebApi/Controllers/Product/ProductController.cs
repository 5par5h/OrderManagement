using OrderManagement_WebApi.Common;
using OrderManagement_WebApi.DbConnectivity;
using OrderManagement_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_WebApi.Controllers.Product
{
    public class ProductController : ApiController
    {
        ProductDb _productDb = new ProductDb();
        private HttpConfiguration configuration;
        public ProductController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public ProductController(HttpConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IHttpActionResult GetProductList()
        {
            var response = new ResponseMessage<ProductList>();
            response.apistatus = APIResponseStatus.Fail;
            response.apimsg = TextString.TextFail;
            string validationError = string.Empty;
            try
            {
                ProductList products = new ProductList();
                products.productList = _productDb.GetAllProducts();
                products.totalCount = products.productList.Count;
                if (products.productList.Count >= 0)
                {
                    response.apistatus = APIResponseStatus.Success;
                    response.apimsg = TextString.TextOkay;
                    response.Data = products;
                    return Ok(response);
                }
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = ErrorString.FailedToGetProductList });
            }
            catch (Exception exe)
            {
                //TODO :
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Success, apimsg = TextString.TextOkay, Data = ErrorString.APIError });
            }
        }
    }
}
