using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System.Database.Models
{
    // Lecture class represents a lecture in the college info system.
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public string LectureLenght { get; set; }
        public int LectureCredit {get; set;}

        // Navigation property represents a collection of student lectures associated with the lecture. Many to many
        public List<StudentLecture> StudentLectures { get; set; }

        // Navigation property represents a collection of department lectures associated with the lecture. Many to many
        public List<DepartmentLecture> DepartmentLectures { get; set; }
    }
}