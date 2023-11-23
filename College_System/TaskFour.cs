using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        public class TaskFour
        {

public        static void Task4()
        {
            var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
              .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
            // Retrieve an existing department from the database (you should replace 1 with the actual ID of an existing department)
            Department department2 = dbContext.Departments.Find(1); // Replace with the actual department ID

            if (department2 != null)
            {
                // Create a new student
                Student newStudent = new Student
                {
                    Name = "Alice Johnson", // Replace with the actual student name
                    Department = department2,
                };

                // Retrieve existing lectures from the database (you should replace 1 and 2 with the actual IDs of existing lectures)
                Lecture lecture1 = dbContext.Lectures.Find(1); // Replace with the actual lecture ID
                Lecture lecture2 = dbContext.Lectures.Find(2); // Replace with the actual lecture ID

                if (lecture1 != null && lecture2 != null)
                {
                    // Assign existing lectures to the student
                    newStudent.Lectures = new List<Lecture>
                {
                    lecture1,
                    lecture2,
                };

                    // Save the new student to the database
                    dbContext.Students.Add(newStudent);
                    dbContext.SaveChanges();

                    Console.WriteLine("Student created and assigned to an existing department with lectures successfully.");
                }
                else
                {
                    Console.WriteLine("One or more lectures not found. Please make sure lectures exist in the database.");
                }
            }
            else
            {
                Console.WriteLine("Department not found. Please create a department first.");
            }
        }
        }
    }
}


