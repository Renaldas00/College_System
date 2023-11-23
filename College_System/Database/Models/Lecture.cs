using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System.Database.Models
{

    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }
        public string Name { get; set; }

        public string LectureLenght { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Student> Students { get; set; }

        public List<StudentLecture> StudentLectures { get; set; }

    }
}