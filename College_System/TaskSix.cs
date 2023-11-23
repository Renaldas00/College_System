using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        // Task 6 //
        public class TaskSix
        {

            public static void Task6()
            {
                var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
               .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);

                // Retrieve an existing department from the database (you should replace 1 with the actual ID of an existing department)
                Department department2222 = dbContext.Departments
                    .Include(d => d.Students)
                    .FirstOrDefault(d => d.DepartmentId == 1); // Replace with the actual department ID

                if (department2222 != null)
                {
                    Console.WriteLine($"Students in {department2222.Name} Department:");

                    foreach (var student in department2222.Students)
                    {
                        Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}");
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


