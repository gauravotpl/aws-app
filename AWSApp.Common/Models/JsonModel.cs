using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Models
{
    public class JsonModel
    {
        public string accessToken { get; set; }
        public string message { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        public object data { get; set; }
    }
}
