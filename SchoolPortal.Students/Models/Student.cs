using System.ComponentModel.DataAnnotations;

namespace SchoolPortal.Students.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}