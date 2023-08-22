using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    abstract class Animal
    {
        public void Eat()
        {
            Console.WriteLine("glass");
        }
        public abstract void AnimalSound();
    }
}
