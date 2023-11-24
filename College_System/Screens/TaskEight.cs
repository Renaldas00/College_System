using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
        public class TaskEight
        {

            public static void Task8(InformationContext dbContext)
            {
                // Display existing students
                Console.WriteLine("Existing Students:");
                var existingStudents = dbContext.Students.ToList();
                foreach (var student in existingStudents)
                {
                    Console.WriteLine($"{student.StudentId}. {student.StudentName}");
                }

                // Select a student
                Console.Write("Select a student by entering their ID: ");
                if (int.TryParse(Console.ReadLine(), out int selectedStudentId))
                {
                    // Get selected student from db
                    var selectedStudent = dbContext.Students
                        .Include(s => s.StudentLectures)
                        .ThenInclude(sl => sl.Lecture)
                        .FirstOrDefault(s => s.StudentId == selectedStudentId);

                    if (selectedStudent != null)
                    {
                        Console.WriteLine($"Lectures for Student {selectedStudent.StudentName}:");

                        foreach (var studentLecture in selectedStudent.StudentLectures)
                        {
                            var lecture = studentLecture.Lecture;
                            Console.WriteLine($"Lecture ID: {lecture.LectureId}, Name: {lecture.LectureName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student not found. Make sure the student exists in the database.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a valid student ID.");
                }
            }
        }
    }



