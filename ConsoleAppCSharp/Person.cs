using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        private string Passport { get; set; }

        public Person()
        {
            Console.WriteLine("Person Init");
        }

    }
}
