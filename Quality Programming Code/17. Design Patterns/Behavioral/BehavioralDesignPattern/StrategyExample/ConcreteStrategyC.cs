using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyExample
{
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
              "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }
}
