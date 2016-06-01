namespace StudentSystem.Data
{
    using Migrations;
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Course> Courses { get; set; }
        public virtual IDbSet<Homework> Homeworks { get; set; }
        //public virtual IDbSet<Material> Materials { get; set; }
    }
}
