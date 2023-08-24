using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public class Candidate : Person
    {
        public Candidate()
        {
            Console.WriteLine("Candidate Init");
        }

        public void ShowInfor()
        {

        }
        public string ShowInfor(string name)
        {
            return name;
        }

        public void ShowInfor(string name,int Age)
        {

        }
    }
}
