using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    internal partial class Program
    {
        /////// Task 3 //////
        public class TaskThree
        {

            // Retrieve a department from the database (you should replace 1 with the actual ID of an existing department)
            public static void Task3(){
                var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
                Department department = dbContext.Departments.Find(1); // Replace with the actual department ID

            if (department != null)
            {
                // Create a new lecture
                Lecture newLecture = new Lecture
                {
                    Name = "Introduction to Machine Learning", // Replace with the actual lecture name
                    Department = department,
                };

                // Save the new lecture to the database
                dbContext.Lectures.Add(newLecture);
                dbContext.SaveChanges();

                Console.WriteLine("Lecture created and assigned to a department successfully.");
            }
            else
            {
                Console.WriteLine("Department not found. Please create a department first.");
            }
        }
} 
                }
            }


