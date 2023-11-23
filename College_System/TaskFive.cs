using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        public class TaskFive
        {

        public static void Task5()
        {
            var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
              .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
            // Retrieve an existing student from the database (you should replace 1 with the actual ID of an existing student)
            Student student = dbContext.Students
                .Include(s => s.Lectures)
                .FirstOrDefault(s => s.StudentId == 1); // Replace with the actual student ID

            if (student != null)
            {
                // Retrieve an existing department from the database (you should replace 2 with the actual ID of an existing department)
                Department newDepartment = dbContext.Departments.Find(2); // Replace with the actual department ID

                if (newDepartment != null)
                {
                    // Assign the student to the new department
                    student.Department = newDepartment;

                    // Retrieve existing lectures from the database (you should replace 3 and 4 with the actual IDs of existing lectures)
                    Lecture newLecture122 = dbContext.Lectures.Find(3); // Replace with the actual lecture ID
                    Lecture newLecture222 = dbContext.Lectures.Find(4); // Replace with the actual lecture ID

                    if (newLecture122 != null && newLecture222 != null)
                    {
                        // Change the student's lectures
                        student.Lectures.Clear();
                        student.Lectures.Add(newLecture122);
                        student.Lectures.Add(newLecture222);

                        // Save changes to the database
                        dbContext.SaveChanges();

                        Console.WriteLine("Student transferred to another department and lectures changed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("One or more new lectures not found. Please make sure lectures exist in the database.");
                    }
                }
                else
                {
                    Console.WriteLine("New department not found. Please make sure the department exists in the database.");
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


