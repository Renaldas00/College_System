namespace College_System.Database.Models
{
    // DepartmentLecture class represents association between department and lecture classes, tables in db.
    public class DepartmentLecture
    {
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }
    }
}