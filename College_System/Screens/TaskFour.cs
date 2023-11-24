using College_System.Database;
using College_System.Database.Models;
using College_System.Methods;
using College_System.Validation;
using Microsoft.EntityFrameworkCore;

namespace College_System
{

        public class TaskFour
        {
        public static void Task4(InformationContext dbContext)
        {
            // Display existing departments
            Console.WriteLine("Existing Departments:");
            var existingDepartments = dbContext.Departments.ToList();
            foreach (var department in existingDepartments)
            {
                Console.WriteLine($"{department.DepartmentId}. {department.DepartmentName}");
            }

            // select a department
            Console.Write("Select a department by entering its ID: ");
            if (int.TryParse(Console.ReadLine(), out int selectedDepartmentId))
            {
                var selectedDepartment = existingDepartments.FirstOrDefault(d => d.DepartmentId == selectedDepartmentId);

                if (selectedDepartment != null)
                {
                    // Create a new student
                    Student newStudent = StudenCreation.CreateStudent(dbContext);

                    // Display existing lectures
                    Console.WriteLine("Existing Lectures:");
                    var existingLectures = dbContext.Lectures.ToList();
                    foreach (var lecture in existingLectures)
                    {
                        Console.WriteLine($"{lecture.LectureId}. {lecture.LectureName}");
                    }

                    // Select existing lectures for student
                    Console.WriteLine("Select existing lectures for the student (enter IDs separated by commas): ");
                    var selectedLectureIds = Console.ReadLine()?.Split(',').Select(id => int.Parse(id.Trim())).ToList();

                    if (selectedLectureIds != null)
                    {
                        // Get selected lectures from db
                        var selectedLectures = existingLectures.Where(lecture => selectedLectureIds.Contains(lecture.LectureId)).ToList();

                        if (selectedLectures.Count == selectedLectureIds.Count)
                        {
                            // Assign existing lectures to student using navigation property
                            newStudent.StudentLectures = selectedLectures.Select(lecture => new StudentLecture
                            {
                                Lecture = lecture
                            }).ToList();

                            // Associate the student with the department
                            newStudent.Department = selectedDepartment;

                            // Save new student to db
                            dbContext.Students.Add(newStudent);
                            dbContext.SaveChanges();

                            Console.WriteLine("Student created and assigned to an existing department with lectures successfully.");
                        }
                        else
                        {
                            Console.WriteLine("One or more selected lectures not found. Make sure lectures exist in the database.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for lecture IDs.");
                    }
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
 



