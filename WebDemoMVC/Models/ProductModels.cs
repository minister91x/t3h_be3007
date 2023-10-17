using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoMVC.Models
{
    public class ProductModels
    {
        public int prductID { get; set; }
        public string prductName { get; set; }
        public string donViTinh { get; set; }
        public int donGia { get; set; }
    }

    public class ProductGetListRequest
    {
        public int prductID { get; set; }
    }

    public class FunctionModels
    {
        public int FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionURL { get; set; }
    }
}