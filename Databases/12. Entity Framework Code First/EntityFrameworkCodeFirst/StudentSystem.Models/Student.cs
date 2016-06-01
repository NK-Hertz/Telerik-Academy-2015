namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Homework> homeworks;
        private ICollection<Course> courses;

        public Student()
        {
            this.homeworks = new HashSet<Homework>();
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        [Required]
        [MinLength(1)]
		[MaxLength(100)]
        public string Name { get; set; }

        [Range(0, 150)]
        public int? Age { get; set; }

        [Required]
        public int Number { get; set; }

        public Gender Gender { get; set; }

        //public Material Avatar { get; set; }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
