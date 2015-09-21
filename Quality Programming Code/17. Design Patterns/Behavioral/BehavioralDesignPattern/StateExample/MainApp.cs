using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    class MainApp
    {
        static void Main()
        {
            Context c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state 
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }
}
