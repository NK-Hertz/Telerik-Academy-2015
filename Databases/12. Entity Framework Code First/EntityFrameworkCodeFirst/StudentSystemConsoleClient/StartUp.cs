namespace StudentSystemConsoleClient
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var db = new StudentSystemDbContext();
            using (db)
            {
                var courses = new List<Course> { new Course
                    {
                        Name = "Бази данни 2015",
                        Description = "Ако имате проблеми със създаването на нова база на локалните компютри, моля пуснете скрипта, който ще намерите на тзи линк",
                    }, new Course
                    {
                        Name = "CSS стилизиране (май 2016)",
                        Description = "Практически изпит: 3 юни (групите за изпит ще бъдат обявени допълнително)* \n Поради вътрешно събитие на Telerik, a Progress Company, занятия няма да се провеждат в периода 16 - 19 май 2016 г."
                    }, new Course
                    {
                        Name = "C# за напреднали (май 2016)",
                        Description = "Практически изпит: 3 юни (групите за изпит ще бъдат обявени допълнително)* \n Поради вътрешно събитие на Telerik, a Progress Company, занятия няма да се провеждат в периода 16 - 19 май 2016 г."
                    }
                };

                var numberOfStudents = 30;
                for (int i = 0; i < numberOfStudents; i++)
                {
                    var currentStudent = new Student
                    {
                        Name = ((i*10/1.3+15)/3).ToString(),
                        Number = i + 10000,
                        Age = (int)(i * 1.75)
                    };

                    if (i <= 10)
                    {
                        currentStudent.Gender = Gender.Male;
                        currentStudent.Courses.Add(courses[0]);
                    }
                    else if (i >= 10 && i <= 20)
                    {
                        currentStudent.Gender = Gender.Female;
                        currentStudent.Courses.Add(courses[1]);
                    }
                    else
                    {
                        currentStudent.Gender = Gender.Male;
                        currentStudent.Courses.Add(courses[2]);
                    }

                    db.Students.Add(currentStudent);
                }

                db.SaveChanges();
            }
        }
    }
}
