namespace Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        // 1:1
        public Diploma? Diploma { get; set; }
        // 1:N
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        // N:N
        //public List<Course>? Courses { get; set; } = new List<Course>();
        public List<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
    }
}