using College_System.Database;
using College_System.Database.Models;
using College_System.Validation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using College_System.Methods;

namespace College_System
{
        public class TaskTwo
        {
            public static void Task2(InformationContext dbContext)
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
                    var selectedDepartment = existingDepartments.FirstOrDefault(d => d.DepartmentId == selectedDepartmentId);

                    if (selectedDepartment != null)
                    {
                        // Add a new student
                        Student student = StudenCreation.CreateStudent(dbContext);
                        selectedDepartment.Students ??= new List<Student>();
                        selectedDepartment.Students.Add(student);

                        // Add a new lecture
                        Lecture lecture = LectureCreation.CreateLecture();
                        selectedDepartment.DepartmentLectures ??= new List<DepartmentLecture>();
                        selectedDepartment.DepartmentLectures.Add(new DepartmentLecture
                        {
                            Lecture = lecture
                        });

                        // Associate the student with the lecture
                        dbContext.StudentLectures.Add(new StudentLecture
                        {
                            Student = student,
                            Lecture = lecture
                        });

                        // Save changes to the database
                        dbContext.SaveChanges();

                        Console.WriteLine("New student, lecture, and association added to the selected department successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a valid department ID.");
                }
            }
        }
}

        
    


