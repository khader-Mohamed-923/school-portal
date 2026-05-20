using System;

namespace SchoolPortal.Grades.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string CourseName { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public DateTime GradeDate { get; set; } = DateTime.Now;
    }
}