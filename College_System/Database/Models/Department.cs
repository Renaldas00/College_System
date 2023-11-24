using System.ComponentModel.DataAnnotations;

namespace College_System.Database.Models
{
    // Department class represents a department in the college info system.
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string DepartmentCode { get; set; }

        // Navigation property which represents a collection of students associated with the department. Many to many
        public List<Student> Students { get; set; }

        // Navigation property that represents a collection of department lectures associated with the department. Many to many
        public List<DepartmentLecture> DepartmentLectures { get; set; }

    }

}