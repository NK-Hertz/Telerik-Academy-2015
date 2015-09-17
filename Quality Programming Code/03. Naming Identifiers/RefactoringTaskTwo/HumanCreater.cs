using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringTaskTwo
{
    public class HumanCreater
    {
        static void Main(string[] args)
        {
            var pesho = new Human();
            pesho.CreateHuman(2);
            Console.WriteLine(pesho.Sex);
            Console.WriteLine(pesho.Age);
        }
    }
}
