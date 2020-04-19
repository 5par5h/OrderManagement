using Newtonsoft.Json;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace OrderManagement.Global
{
    public class ApiRequest
    {
        public static T PostAPi<T>(string strUrl, NameValueCollection data, WebClient wb)
        {
            var response = wb.UploadValues(strUrl, "Post", data);
            string responseInString = Encoding.UTF8.GetString(response);
            dynamic chkResult = JsonConvert.DeserializeObject<dynamic>(responseInString);
            if (chkResult.apistatus == 1)
            {
                T Result = JsonConvert.DeserializeObject<T>(responseInString);
                return (T)Convert.ChangeType(Result, typeof(T));
            }
            else
            {
                FailResponse l = new FailResponse();
                chkResult.apimsg = chkResult.data;
                chkResult.data = l.msg;
                T Result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(chkResult));
                return (T)Convert.ChangeType(Result, typeof(T));
            }
        }

        public static T GetApi<T>(string strUrl, WebClient data)
        {
            string responseInString = data.DownloadString(strUrl);
            dynamic chkResult = JsonConvert.DeserializeObject<dynamic>(responseInString);
            if (chkResult.apistatus == 1)
            {
                T Result = JsonConvert.DeserializeObject<T>(responseInString);
                return (T)Convert.ChangeType(Result, typeof(T));
            }
            else
            {
                FailResponse l = new FailResponse();
                chkResult.apimsg = chkResult.data;
                chkResult.data = l.msg;
                T Result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(chkResult));
                return (T)Convert.ChangeType(Result, typeof(T));
            }
        }

        public static T PutApi<T>(string strUrl, NameValueCollection data, WebClient wb)
        {
            var response = wb.UploadValues(strUrl, "PUT", data);
            string responseInString = Encoding.UTF8.GetString(response);
            dynamic chkResult = JsonConvert.DeserializeObject<dynamic>(responseInString);
            if (chkResult.apistatus == 1)
            {
                T Result = JsonConvert.DeserializeObject<T>(responseInString);
                return (T)Convert.ChangeType(Result, typeof(T));
            }
            else
            {
                FailResponse l = new FailResponse();
                chkResult.apimsg = chkResult.data;
                chkResult.data = l.msg;
                T Result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(chkResult));
                return (T)Convert.ChangeType(Result, typeof(T));
            }

        }

        public static T DeleteAPI<T>(string strUrl, string strType, WebClient wb)
        {
            //WebClient client = new WebClient();
            //client.QueryString.Add("id", strID);
            string response = wb.UploadString(strUrl, strType, string.Empty);
            T Result = JsonConvert.DeserializeObject<T>(response);
            return (T)Convert.ChangeType(Result, typeof(T));
        }
    }
}