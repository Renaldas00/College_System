using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    public class TaskSeven
    {
        public static void Task7(InformationContext dbContext)
        {
            // Display existing departments
            Console.WriteLine("Existing Departments:");
            var existingDepartments = dbContext.Departments.ToList();
            foreach (var department in existingDepartments)
            {
                Console.WriteLine($"{department.DepartmentId}. {department.DepartmentName}");
            }

            // Prompt the user to select a department
            Console.Write("Select a department by entering its ID: ");
            if (int.TryParse(Console.ReadLine(), out int selectedDepartmentId))
            {
                // Get selected department
                var selectedDepartment = dbContext.Departments
                    .Include(d => d.DepartmentLectures)
                    .ThenInclude(dl => dl.Lecture)
                    .FirstOrDefault(d => d.DepartmentId == selectedDepartmentId);

                if (selectedDepartment != null)
                {
                    Console.WriteLine($"Lectures in {selectedDepartment.DepartmentName} Department:");

                    foreach (var departmentLecture in selectedDepartment.DepartmentLectures)
                    {
                        var lecture = departmentLecture.Lecture;
                        Console.WriteLine($"Lecture ID: {lecture.LectureId}, Name: {lecture.LectureName}");
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

