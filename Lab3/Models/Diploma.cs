using Lab3.Models;

namespace Lab3.Models
{
    public class Diploma
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // 1:1
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}