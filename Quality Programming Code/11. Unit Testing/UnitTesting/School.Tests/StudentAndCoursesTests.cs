using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentAndCourses.Tests
{
    [TestClass]
    public class StudentAndCoursesTests
    {
        [TestMethod]
        public void AddingCourseShouldCorrectlyAddCourseToTheSchool()
        {
            var school = new School();
            var course = new Course("What the hell!");
            school.AddCourse(course);
            Assert.AreEqual(1, school.Courses.Count, "School courses is not added properly!");
        }

        [TestMethod]
        public void AddingStudentInCourseShouldWorkProperly()
        {
            var course = new Course("asdad");
            course.AddStudent(new Student("Jigubigulq", 12312));
            course.AddStudent(new Student("Jigubigulq", 12321));
            Assert.AreEqual(2, course.Students.Count, "Course is not adding students properly!");
        }

        [TestMethod]
        public void RemoveStudentShouldRemoveHimFromCourse()
        {
            var course = new Course("asdad");
            var student = new Student("Jigubigulq", 12312);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count, "Course is not adding students properly!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GettingCourseNameShouldThrowExceptionIfNullIsEntered()
        {
            var student = new Course(null);
        }

        [TestMethod]
        public void AddingStudentsShouldBeLessThan30()
        {
            var course = new Course("C# Part 1");
            for (int i = 0; i < 35; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + i));
            }

            Assert.AreEqual(29, course.Students.Count, "Students are added after 29 people in course!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithNullNameShouldThrowException()
        { 
            var student = new Student(null ,10000);
        }

        [TestMethod]
        public void AddStudentInSchoolShouldBeReportedInsideSchool()
        {
            var school = new School();
            school.AddStudent(new Student("Ivaylo", 10000));
            Assert.AreEqual(1, school.Students.Count, "Student is not added properly in school!");
        }

        public void AddingStudentWithSameUNTwiceShouldNotAddHimTwice()
        {
            var school = new School();
            school.AddStudent(new Student("Ivaylo", 10000));
            school.AddStudent(new Student("Ivaylo", 10000));
            Assert.AreEqual(1, school.Students.Count, "Student with same UN is added and should not!");
        }
    }
}
