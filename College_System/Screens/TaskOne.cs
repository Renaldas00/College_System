using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using College_System.Methods;
using College_System.Validation;
namespace College_System
{
    public class TaskOne
    {
        public static void Task1(InformationContext dbContext)
        {
            // Create a department
            Department newDepartment = DepartmentCreation.CreateDepartment();

            // Display existing lectures
            Console.WriteLine("Existing Lectures:");
            List<Lecture> existingLectures = dbContext.Lectures.ToList();
            foreach (var lecture in existingLectures)
            {
                Console.WriteLine($"- {lecture.LectureName}");
            }

            List<Lecture> selectedLectures = new List<Lecture>();
            bool addNewLecture;

            do
            {
                Lecture selectedLecture = null;
                addNewLecture = false;

                // Select an existing lecture or add a new one
                Console.Write("Do you want to add a new lecture (Y/N)? ");
                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    addNewLecture = true;
                    selectedLecture = LectureCreation.CreateLecture();

                    // Check for duplicate lecture name
                    while (LectureValidation.IsDuplicateLecture(selectedLecture.LectureName, dbContext))
                    {
                        Console.WriteLine($"Lecture with name '{selectedLecture.LectureName}' already exists. Enter a different name.");
                        selectedLecture = LectureCreation.CreateLecture();
                    }

                    // Save changes to the database
                    dbContext.Lectures.Add(selectedLecture);
                    //dbContext.SaveChanges();
                }
                else
                {
                    Console.Write("Enter the name of the existing lecture: ");
                    string existingLectureName = Console.ReadLine();

                    // Find the existing lecture in the context
                    selectedLecture = existingLectures.FirstOrDefault(l => l.LectureName == existingLectureName);

                    if (selectedLecture == null)
                    {
                        Console.WriteLine($"Lecture with name '{existingLectureName}' not found. Adding a new lecture.");
                        do
                        {
                            selectedLecture = LectureCreation.CreateLecture();
                        } while (LectureValidation.IsDuplicateLecture(selectedLecture.LectureName, dbContext));

                        // Save changes to the database
                        dbContext.Lectures.Add(selectedLecture);
                        dbContext.SaveChanges();
                    }
                }

                selectedLectures.Add(selectedLecture);

                // Continue or move on ?
                Console.Write("Do you want to add another lecture (Y/N)? Press 'Q' to finish: ");
            } while (Console.ReadLine()?.Trim().ToUpper() == "Y");

            // Add students to the department
            List<Student> students = new List<Student>();

            foreach (var selectedLecture in selectedLectures)
            {
                do
                {
                    // Add a new student to the list
                    Student newStudent = StudenCreation.CreateStudent(dbContext);
                    newStudent.StudentLectures = new List<StudentLecture> { new StudentLecture { Lecture = selectedLecture } };
                    students.Add(newStudent);

                    Console.WriteLine("Student added to the department.");

                    // Continue or move finish ?
                    Console.Write("Do you want to add another student (Y/N)? Press 'Q' to finish: ");
                } while (Console.ReadLine()?.Trim().ToUpper() == "Y");
            }

            newDepartment.Students = students;
            newDepartment.DepartmentLectures = selectedLectures.Select(lecture => new DepartmentLecture { Lecture = lecture }).ToList();

            // Save
            dbContext.Departments.Add(newDepartment);
            dbContext.SaveChanges();

            Console.WriteLine("Department, students, and lectures added successfully.");
        }

    }
}

