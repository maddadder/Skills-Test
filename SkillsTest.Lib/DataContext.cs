using Microsoft.EntityFrameworkCore;

namespace SkillsTest.Lib
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<X_Student_Course> StudentCourses {get;set;}

        public DataContext(DbContextOptions options) : base(options)
        {
            // Nothing to do here
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<X_Student_Course>()
            .HasOne(e => e.Course)
            .WithMany(e => e.StudentCourses);

            modelBuilder.Entity<X_Student_Course>()
                .HasOne(e => e.Student)
                .WithMany(e => e.StudentCourses);

            modelBuilder.Entity<X_Student_Course>()
            .HasKey(c => new { c.CourseId, c.StudentId });
        }
    }
}