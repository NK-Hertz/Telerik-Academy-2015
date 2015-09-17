using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arbitrary extrinsic state 
            int extrinsicstate = 22;

            FlyweightFactory f = new FlyweightFactory();

            // Work with different flyweight instances 
            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = f.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight uf = new
              UnsharedConcreteFlyweight();

            uf.Operation(--extrinsicstate);
        }
    }
}
