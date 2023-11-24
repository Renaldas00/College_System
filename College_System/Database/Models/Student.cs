using System.ComponentModel.DataAnnotations;

namespace College_System.Database.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public int StudentNumber { get; set; }
        public string StudentEmail { get; set; }
        public int DepartmentId { get; set; }

        // Navigation property represents the department to which the student belongs. One to many
        public Department Department { get; set; }

        // Navigation property represents the lectures associated with the student. Many to many
        public List<StudentLecture> StudentLectures { get; set; }
    }
}