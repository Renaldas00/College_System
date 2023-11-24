using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    public class TaskSix
    {
        public static void Task6(InformationContext dbContext)
        {
            // Display existing departments
            Console.WriteLine("Existing Departments:");
            var existingDepartments = dbContext.Departments.ToList();
            foreach (var department in existingDepartments)
            {
                Console.WriteLine($"{department.DepartmentId}. {department.DepartmentName}");
            }

            // Select a department
            Console.Write("Select a department by entering its ID: ");
            if (int.TryParse(Console.ReadLine(), out int selectedDepartmentId))
            {
                // Get selected department
                var selectedDepartment = dbContext.Departments
                    .Include(d => d.Students)
                    .FirstOrDefault(d => d.DepartmentId == selectedDepartmentId);

                if (selectedDepartment != null)
                {
                    Console.WriteLine($"Students in {selectedDepartment.DepartmentName} Department:");

                    foreach (var student in selectedDepartment.Students)
                    {
                        Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.StudentName}");
                    }
                }
                else
                {
                    Console.WriteLine("Department not found. Make sure the department exists in the database.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a valid department ID.");
            }
        }

    }
}


