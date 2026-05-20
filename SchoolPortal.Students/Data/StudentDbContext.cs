using Microsoft.EntityFrameworkCore;
using SchoolPortal.Students.Models;

namespace SchoolPortal.Students.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
        }
    }
}