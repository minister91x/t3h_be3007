﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    internal class MyException : Exception
    {
        public MyException(string message) : base(message)
        {

        }
    }
}
