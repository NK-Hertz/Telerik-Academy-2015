namespace StudentAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School
    {
        private IList<Course> courses;
        private IList<Student> students;
        private IList<int> uniqueStudentNumbers;

        public School()
        {
            this.courses = new List<Course>();
            this.students = new List<Student>();
            this.uniqueStudentNumbers = new List<int>();
        }

        public IList<Course> Courses
        {
            get { return new List<Course>(this.courses); }
        }

        public IList<Student> Students
        {
            get { return new List<Student>(this.students); }
        }

        public void AddStudent(Student student)
        {
            var studentWithSameUNIsEnlisted = this.uniqueStudentNumbers.IndexOf(student.UniqueNumber);
            if (studentWithSameUNIsEnlisted >= 0)
            {
                Console.WriteLine("Student with unique number: {0} is already enlisted in this school!", student.UniqueNumber);
                return;
            }

            this.students.Add(student);
            this.uniqueStudentNumbers.Add(student.UniqueNumber);
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }
    }
}
