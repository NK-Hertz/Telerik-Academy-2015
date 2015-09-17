using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterExample
{
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
