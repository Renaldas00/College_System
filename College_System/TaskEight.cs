using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        // Task 8 //
        public class TaskEight
        {

            // Retrieve an existing student from the database (you should replace 1 with the actual ID of an existing student)
            public static void Task8()
            {
                var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
                Student student22222 = dbContext.Students
                .Include(s => s.Lectures)
                .FirstOrDefault(s => s.StudentId == 1); // Replace with the actual student ID

                if (student22222 != null)
                {
                    Console.WriteLine($"Lectures for Student {student22222.Name}:");

                    foreach (var studentLecture in student22222.Lectures)
                    {
                        Console.WriteLine($"Lecture ID: {studentLecture.LectureId}, Name: {studentLecture.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found. Please make sure the student exists in the database.");
                }
            }
        }
    }
}



