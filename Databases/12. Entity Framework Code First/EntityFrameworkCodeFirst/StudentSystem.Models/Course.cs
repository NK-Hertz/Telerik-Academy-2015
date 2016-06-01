namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Homework> homeworks;
        private ICollection<Student> students;

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
		[MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.Homeworks = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
