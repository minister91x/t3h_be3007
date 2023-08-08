using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    internal class MyCustomException : Exception
    {
        public MyCustomException(string message)
        : base(String.Format("{0}", message))
        {

        }
    }
}
