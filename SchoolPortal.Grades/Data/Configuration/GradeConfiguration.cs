using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortal.Grades.Models;

namespace SchoolPortal.Grades.Data.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {


            builder.Property(g => g.CourseName)
                .HasMaxLength(100);

            builder.Property(g => g.Score)
                .HasColumnType("decimal(5,2)");

        }
    }
}