namespace StudentAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private static int MaxStudentCount = 29;
        private IList<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name 
        {
            get { return this.name; }
            set 
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name can not be null or empty!");
                }

                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get { return new List<Student>(this.students); }
        }

        public void AddStudent(Student student)
        {
            if (this.Students.Count < MaxStudentCount)
            {
                this.students.Add(student);
            }
            else
            {
                Console.WriteLine("Course is full!");
            }
        }

        public void RemoveStudent(Student student)
        {
            var studentIndexInCourse = this.students.IndexOf(student);
            if (studentIndexInCourse >= 0)
            {
                this.students.Remove(student);
                Console.WriteLine("Student removed succesfully!");
            }
            else
            {
                Console.WriteLine("Student was not found in this course!");
            }
        }
    }
}
