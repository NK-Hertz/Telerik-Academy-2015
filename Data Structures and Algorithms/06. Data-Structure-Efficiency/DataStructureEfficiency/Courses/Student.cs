namespace Courses
{
    public class Student
    {
        public Student()
        { }

        public Student(string firstName, string familyName)
        {
            this.FirstName = firstName;
            this.FamilyName = familyName;
        }

        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public override string ToString()
        {
            var result = this.FirstName + " " + this.FamilyName;
            return result; 
        }
    }
}
