using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoMVC.EntitiesFrameWork.Entites
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}