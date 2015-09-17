namespace StudentAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Student
    {
        private static int MinUniqueNumber = 10000;
        private static int MaxUniqueNumber = 99999;

        private string name;
        private int uniqueNumber;

        public Student(string name, int number)
        {
            this.Name = name;
            this.UniqueNumber = number;
        }

        public string Name 
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be empty!");
                }

                this.name = value;
            }
        }

        public int UniqueNumber 
        {
            get { return this.uniqueNumber; }
            set 
            {
                if (value < MinUniqueNumber || MaxUniqueNumber < value)
                {
                    throw new ArgumentOutOfRangeException("Unique number must be between " + MinUniqueNumber + " and " + MaxUniqueNumber + "!");
                }

                this.uniqueNumber = value;
            }
        }
    }
}
