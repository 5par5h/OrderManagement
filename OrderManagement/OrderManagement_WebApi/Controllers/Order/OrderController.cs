using OrderManagement_WebApi.Common;
using OrderManagement_WebApi.DbConnectivity;
using OrderManagement_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_WebApi.Controllers
{
    public class OrderController : ApiController
    {
        OrderDb _orderDb = new OrderDb();
        private HttpConfiguration configuration;
        public OrderController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public OrderController(HttpConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IHttpActionResult PlaceOrder(Order request)
        {
            var response = new ResponseMessage<string>();
            response.apistatus = APIResponseStatus.Fail;
            response.apimsg = TextString.TextFail;
            string validationError = string.Empty;
            try
            {
                if (_orderDb.AddOrder())
                {
                    //Call order Product by order number
                    response.apistatus = APIResponseStatus.Success;
                    response.apimsg = TextString.TextOkay;
                    response.Data = "";
                    return Ok(response);
                }
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Fail, apimsg = TextString.TextFail, Data = ErrorString.FailedToPlaceOrder });
            }
            catch (Exception exe)
            {
                //TODO :
                return Ok(new ResponseMessage<string> { apistatus = APIResponseStatus.Success, apimsg = TextString.TextOkay, Data = ErrorString.APIError });
            }
        }
    }
}
