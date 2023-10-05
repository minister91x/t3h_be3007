using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Entities
{
    public class Product
    {
        [Key]
        public int PrductID { get; set; }
        public string? PrductName { get; set; }
        public string? DonViTinh { get; set; }
        public int DonGia { get; set; }

    }
}
