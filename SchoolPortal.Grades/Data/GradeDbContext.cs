using Microsoft.EntityFrameworkCore;
using SchoolPortal.Grades.Models;

namespace SchoolPortal.Grades.Data
{
    public class GradeDbContext : DbContext
    {
        public GradeDbContext(DbContextOptions<GradeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GradeDbContext).Assembly);
        }
    }
}