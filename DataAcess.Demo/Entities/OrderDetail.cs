﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string OrderID { get; set; } 
        public int ProductId { get; set; }
    }
}
