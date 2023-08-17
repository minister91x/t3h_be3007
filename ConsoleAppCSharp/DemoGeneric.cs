using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public class DemoGeneric<T>
    {
        private T genericField;

        public T genericProperty { get; set; }

        // Constructor
        public DemoGeneric(T val)
        {
            genericField = val;
        }


        public T genericMethod(T genericParameter)
        {
            T rtn = default(T);

            Console.WriteLine("Field type: {0}, value: {1}", typeof(T).ToString(), genericField);

            return rtn;

        }

    }
}
