﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
