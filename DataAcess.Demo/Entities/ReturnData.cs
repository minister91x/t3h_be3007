﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Entities
{
    public class ReturnData
    {
        public int ResponseCode { get; set; }
        public string Description { get; set; }
        public string Extention { get; set; }
        public string Expiration { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
