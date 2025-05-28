namespace Lab3.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // N:N
        //public List<Student>? Students { get; set; } = new List<Student>();
        public List<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
    }
}