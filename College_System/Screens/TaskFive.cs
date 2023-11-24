using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    public class TaskFive
    {
        public static void Task5(InformationContext dbContext)
        {
            // Display existing students to the user
            Console.WriteLine("Existing Students:");
            var existingStudents = dbContext.Students.ToList();
            foreach (var existingStudent in existingStudents)
            {
                Console.WriteLine($"{existingStudent.StudentId}. {existingStudent.StudentName}");
            }

            // Select a student
            Console.Write("Select a student by entering their ID: ");
            if (int.TryParse(Console.ReadLine(), out int selectedStudentId))
            {
                // Retrieve the selected student with related data from the database
                var student = dbContext.Students
                    .Include(s => s.StudentLectures)
                    .Include(s => s.Department)
                    .FirstOrDefault(s => s.StudentId == selectedStudentId);

                if (student != null)
                {
                    // Display existing departments to the user
                    Console.WriteLine("Existing Departments:");
                    var existingDepartments = dbContext.Departments.ToList();
                    foreach (var department in existingDepartments)
                    {
                        Console.WriteLine($"{department.DepartmentId}. {department.DepartmentName}");
                    }

                    // Select a department
                    Console.Write("Select a department by entering its ID or name: ");
                    string selectedDepartmentInput = Console.ReadLine();

                    Department selectedDepartment;
                    if (int.TryParse(selectedDepartmentInput, out int selectedDepartmentId))
                    {
                        selectedDepartment = existingDepartments.FirstOrDefault(d => d.DepartmentId == selectedDepartmentId);
                    }
                    else
                    {
                        selectedDepartment = existingDepartments.FirstOrDefault(d => d.DepartmentName == selectedDepartmentInput);
                    }

                    if (selectedDepartment != null)
                    {
                        // Retrieve existing lectures from the database
                        Console.WriteLine("Existing Lectures:");
                        var existingLectures = dbContext.Lectures.ToList();
                        foreach (var lecture in existingLectures)
                        {
                            Console.WriteLine($"{lecture.LectureId}. {lecture.LectureName}");
                        }

                        // Select new lectures for the student
                        Console.WriteLine("Select new lectures for the student (enter IDs separated by commas): ");
                        var selectedLectureIds = Console.ReadLine()?.Split(',').Select(id => int.Parse(id.Trim())).ToList();

                        if (selectedLectureIds != null)
                        {
                            // Retrieve selected lectures from the database
                            var selectedLectures = existingLectures.Where(lecture => selectedLectureIds.Contains(lecture.LectureId)).ToList();

                            if (selectedLectures.Count == selectedLectureIds.Count)
                            {
                                // Update students department and lectures
                                student.Department = selectedDepartment;
                                student.StudentLectures = selectedLectures.Select(lecture => new StudentLecture
                                {
                                    Lecture = lecture
                                }).ToList();

                                // Save changes to the database
                                dbContext.SaveChanges();

                                Console.WriteLine("Student transferred to another department and lectures changed successfully.");
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
                    Console.WriteLine("Student not found. Make sure the student exists in the database.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a valid student ID.");
            }
        }
    }
}


