using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringTaskOne
{
    public class Outer
    {
        public const int MAX_COUNT = 6;

        public class Inner
        {
            public void DisplayBoolAsString(bool isTrue)
            {
                string boolAsString = isTrue.ToString();
                Console.WriteLine(boolAsString);
            }
        }

        public static void TestDisplayBoolAsString()
        {
            Inner innerInstance = new Inner();
            innerInstance.DisplayBoolAsString(true);
        }
    }
}
