using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryExample
{
    class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;

        public Client(AbstractFactory factory)
        {
            AbstractProductB = factory.CreateProductB();
            AbstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            AbstractProductB.Interact(AbstractProductA);
        }
    }
}
