using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryExample
{
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
}
