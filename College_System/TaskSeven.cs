using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        // Task 7 //
        public class TaskSeven
        {
            public static void Task7() {
                var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                    .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);

            // Retrieve an existing department from the database (you should replace 1 with the actual ID of an existing department)
            Department department22222 = dbContext.Departments
                .Include(d => d.Lectures)
                .FirstOrDefault(d => d.DepartmentId == 1); // Replace with the actual department ID

            if (department22222 != null)
            {
                Console.WriteLine($"Lectures in {department22222.Name} Department:");

                foreach (var lecture in department22222.Lectures)
                {
                    Console.WriteLine($"Lecture ID: {lecture.LectureId}, Name: {lecture.Name}");
                }
            }
            else
            {
                Console.WriteLine("Department not found. Please make sure the department exists in the database.");
            }
        }
            }
                }
            }


