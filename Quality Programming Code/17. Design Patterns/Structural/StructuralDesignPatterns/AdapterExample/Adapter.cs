using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterExample
{
    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work 
            // and then call SpecificRequest 
            adaptee.SpecificRequest();
        }
    }
}
