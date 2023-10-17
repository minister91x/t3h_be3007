using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoMVC.Models
{
    public class ProductListRequestData: RequestData
    {
        public string KeySearch { get; set; }
    }

    public class RequestData
    {
        public string token { get; set; }
    }
}