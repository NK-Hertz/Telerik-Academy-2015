namespace RefactoringTaskTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Human
    {
        public Gender Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void CreateHuman(int age)
        {
            Human humanInstance = new Human();
            humanInstance.Age = age;
            if (age % 2 == 0)
            {
                humanInstance.Name = "Батката";
                humanInstance.Sex = Gender.UltraBatka;
            }
            else
            {
                humanInstance.Name = "Мацето";
                humanInstance.Sex = Gender.QkaMacka;
            }
        }
    }
}
