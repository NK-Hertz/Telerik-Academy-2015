using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryExample
{
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }
}
