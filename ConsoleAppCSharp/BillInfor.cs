﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    internal class BillInfor
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }

        public int TotalAmount { get; set; }
    }
}
