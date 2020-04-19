using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.DbConnectivity
{
    public class ResponseMessage<T>
    {
        public APIResponseStatus apistatus { get; set; }
        public string apimsg { get; set; }
        public T Data { get; set; }
    }

    public enum APIResponseStatus
    {
        Fail = 0,
        Success = 1,
        TokenExpired = 2,
        TokenMisMatch = 3
    }
}