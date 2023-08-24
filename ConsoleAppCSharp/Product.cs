using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Product()
        {
        }
        public Product(string name, string des)
        {
            Name = name;
            Description = des;
        }
    }
}
