using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortal.Students.Models;

namespace SchoolPortal.Students.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            
         
            builder.Property(s => s.FirstName)
                .HasMaxLength(50);

            builder.Property(s => s.LastName)

                .HasMaxLength(50);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(s => s.Email)
                .IsUnique(); 

            builder.Property(s => s.DateOfBirth)
                .IsRequired();

    
        }
    }
}