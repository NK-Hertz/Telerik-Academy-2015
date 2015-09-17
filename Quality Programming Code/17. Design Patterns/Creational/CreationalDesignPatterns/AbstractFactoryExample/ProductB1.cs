using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryExample
{
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }
}
