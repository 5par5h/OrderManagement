using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
    public class Api
    {
    }
    public class ResponseMessage<T>
    {
        public int apistatus { get; set; }
        public string apimsg { get; set; }
        public T Data { get; set; }
    }

    public class FailResponse
    {
        public string msg { get; set; }
    }
}