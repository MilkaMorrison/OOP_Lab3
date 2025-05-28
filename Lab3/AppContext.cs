using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Diploma> Diplomas => Set<Diploma>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
