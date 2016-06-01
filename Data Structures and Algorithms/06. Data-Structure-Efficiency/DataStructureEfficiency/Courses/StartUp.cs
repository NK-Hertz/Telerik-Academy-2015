namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var courses = new SortedDictionary<string, List<Student>>();
            string separator = " | ";
            var filePath = "../../../students.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var courseStartIndex = line.LastIndexOf(separator) + separator.Length;
                    var course = line.Substring(courseStartIndex, line.Length - courseStartIndex).Trim();

                    var familyNameStartIndex = line.IndexOf(separator) + separator.Length;
                    var familyNameLength = line.Length - course.Length - separator.Length - familyNameStartIndex;
                    var familyName = line.Substring(familyNameStartIndex, familyNameLength).Trim();

                    var firstName = line.Substring(0, familyNameStartIndex - separator.Length).Trim();

                    var students = new List<Student>();
                    if (courses.ContainsKey(course))
                    {
                        students = courses[course];
                    }

                    var student = new Student(firstName, familyName);
                    students.Add(student);

                    courses.Remove(course);
                    courses.Add(course, students);
                }

                foreach (var pair in courses)
                {
                    var students = pair.Value.OrderBy(s => s.FamilyName).ThenBy(s => s.FirstName).ToList();
                    Console.WriteLine("{0} : {1}", pair.Key, string.Join(", ", students));
                }
            }
        }
    }
}
