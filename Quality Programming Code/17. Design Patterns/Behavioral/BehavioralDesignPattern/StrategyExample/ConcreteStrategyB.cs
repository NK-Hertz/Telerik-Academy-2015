using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyExample
{
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
              "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }
}
