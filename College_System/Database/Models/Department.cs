using System.ComponentModel.DataAnnotations;

namespace College_System.Database.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public Guid Code { get; set; }
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }
    }
}