using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorExample
{
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }
}
