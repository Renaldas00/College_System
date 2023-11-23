using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        public class TaskTwo
        {

       public static void Task2()
        {
            var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
              .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
            // Create a new department with no students or lectures assigned
            Department emptyDepartment = new Department
            {
                Name = "Slytherin", // Replace with the actual department name
            };

            // Save the empty department to the database
            dbContext.Departments.Add(emptyDepartment);
            dbContext.SaveChanges();

            Console.WriteLine("Empty department created successfully.");

            Department newlyCreatedDepartment = dbContext.Departments
                .OrderByDescending(d => d.DepartmentId)
                .FirstOrDefault(); // Retrieve the latest department

            if (newlyCreatedDepartment != null)
            {
                // Add students and lectures to the newly created department
                Student student3 = new Student
                {
                    Name = "Bob Smith", // Replace with the actual student name
                };

                Lecture lecture3 = new Lecture
                {
                    Name = "Advanced Algorithms", // Replace with the actual lecture name
                };

                // Associate the new student and lecture with the newly created department
                newlyCreatedDepartment.Students ??= new List<Student>();
                newlyCreatedDepartment.Lectures ??= new List<Lecture>();

                newlyCreatedDepartment.Students.Add(student3);
                newlyCreatedDepartment.Lectures.Add(lecture3);

                // Save changes to the database
                dbContext.SaveChanges();

                Console.WriteLine("Students and lectures added to the newly created department successfully.");
            }
            else
            {
                Console.WriteLine("No department found or something went wrong.");
            }
        }
        }
    }
}


