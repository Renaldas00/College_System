using System.ComponentModel.DataAnnotations;

namespace College_System.Database.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        public int Number { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<Lecture> Lectures { get; set; }

        public List<StudentLecture> StudentLectures { get; set; }

    }
}