using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoMVC.Models
{
    public class ReturnData
    {
        public int ResponseCode { get; set; }
        public string Description { get; set; }
        public string Extention { get; set; }
    }

    public class GetPrincipalFromExpiredTokenRequestData
    {
        public string token { get; set; }
    }
}