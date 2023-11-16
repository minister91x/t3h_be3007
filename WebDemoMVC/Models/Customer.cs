using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoMVC.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
    }

    public class OrderRequest
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
    public class CreateOrderRequestData: GetPrincipalFromExpiredTokenRequestData
    {
        public Customer customer { get; set; }
        public List<OrderRequest> orderItems { get; set; }


    }
}
