using College_System.Database;
using College_System.Database.Models;
using College_System.Methods;
using College_System.Validation;
using Microsoft.EntityFrameworkCore;

namespace College_System
{

    public class TaskThree
    {
        public static void Task3(InformationContext dbContext)
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
                    // Create a new lecture
                    Lecture newLecture = LectureCreation.CreateLecture();

                    // Check if the Lecture already exists in the context
                    var existingLecture = dbContext.Lectures.FirstOrDefault(l => l.LectureId == newLecture.LectureId);

                    if (existingLecture == null)
                    {
                        // Add it to context
                        selectedDepartment.DepartmentLectures ??= new List<DepartmentLecture>();

                        // Check if the lecture is associated with the department
                        if (!selectedDepartment.DepartmentLectures.Any(dl => dl.LectureId == newLecture.LectureId))
                        {
                            selectedDepartment.DepartmentLectures.Add(new DepartmentLecture
                            {
                                // Assign the navigation property instead of the ID
                                Lecture = newLecture
                            });

                            // Save
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("The selected lecture is already associated with the department.");
                        }
                    }
                    else
                    {
                        // Lecture already exists, associate it with the department
                        selectedDepartment.DepartmentLectures ??= new List<DepartmentLecture>();

                        // Check if the lecture is not already associated with the department
                        if (!selectedDepartment.DepartmentLectures.Any(dl => dl.LectureId == existingLecture.LectureId))
                        {
                            selectedDepartment.DepartmentLectures.Add(new DepartmentLecture
                            {
                                // Assign the navigation property instead of the ID
                                Lecture = existingLecture
                            });

                            // Save
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("The selected lecture is already associated with the department.");
                        }
                    }

                    Console.WriteLine("Lecture created and assigned to a department successfully.");
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