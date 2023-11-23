using College_System.Database;
using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_System
{
    public class TaskOne
    {

        public static void Task1()
        {

            var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
            // Create a department
            Department newDepartment = new Department
            {
                Name = "Computer Science", // Replace with the actual department name
            };

            // Add students to the department
            Student student1 = new Student
            {
                Name = "John Doe",
                Email = "dasd"// Replace with the actual student name
            };

            Student student2 = new Student
            {
                Name = "Jane Doe",
                Email = "sssss"// Replace with the actual student name
            };

            // Create a lecture
            Lecture lecture1 = new Lecture
            {
                Name = "Introduction to Programming",
                LectureLenght = "3"// Replace with the actual lecture name
            };

            Lecture lecture2 = new Lecture
            {
                Name = "Database Management",
                LectureLenght = "3"// Replace with the actual lecture name
            };

            // Associate students and lectures with the department
            newDepartment.Students = new List<Student> { student1, student2 };
            newDepartment.Lectures = new List<Lecture> { lecture1, lecture2 };

            // Save changes to the database
            dbContext.Departments.Add(newDepartment);
            dbContext.SaveChanges();

            Console.WriteLine("Department, students, and lectures added successfully.");

        }
    }
    //    public static void Task1()
    //    {
    //        Console.Write("Enter the department name: ");
    //        string departmentName = Console.ReadLine();

    //        var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
    //            .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);

    //        // Create a department
    //        Department newDepartment = new Department
    //        {
    //            Name = departmentName,
    //        };

    //        // Add students to the department
    //        Console.Write("Enter the name of the first student: ");
    //        string student1Name = Console.ReadLine();
    //        Student student1 = new Student
    //        {
    //            Name = student1Name,
    //        };

    //        Console.Write("Enter the name of the second student: ");
    //        string student2Name = Console.ReadLine();
    //        Student student2 = new Student
    //        {
    //            Name = student2Name,
    //        };

    //        // Create lectures
    //        Console.Write("Enter the name of the first lecture: ");
    //        string lecture1Name = Console.ReadLine();
    //        Lecture lecture1 = new Lecture
    //        {
    //            Name = lecture1Name,
    //        };

    //        Console.Write("Enter the name of the second lecture: ");
    //        string lecture2Name = Console.ReadLine();
    //        Lecture lecture2 = new Lecture
    //        {
    //            Name = lecture2Name,
    //        };

    //        // Associate students and lectures with the department
    //        newDepartment.Students = new List<Student> { student1, student2 };
    //        newDepartment.Lectures = new List<Lecture> { lecture1, lecture2 };

    //        // Save changes to the database
    //        dbContext.Departments.Add(newDepartment);
    //        dbContext.SaveChanges();

    //        Console.WriteLine("Department, students, and lectures added successfully.");
    //    }

    //}
    //public class Validation
    //{

    //    public static bool ValidateStudentName(string name)
    //    {
    //        // Check if the name is not null or empty
    //        if (string.IsNullOrWhiteSpace(name))
    //        {
    //            Console.WriteLine("Student name cannot be empty or whitespace.");
    //            return false;
    //        }

    //        // Check if the name length is between 2 and 50 characters
    //        if (name.Length < 2 || name.Length > 50)
    //        {
    //            Console.WriteLine("Student name should be between 2 and 50 characters.");
    //            return false;
    //        }

    //        // Additional validation logic can be added if needed

    //        return true;
    //    }

    //}















    //    public static void Task1()
    //    {
    //        Console.Write("Enter the department name: ");
    //        string departmentName = Console.ReadLine();

    //        if (!ValidateName(departmentName, "Department"))
    //        {
    //            return;
    //        }

    //        var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
    //            .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);

    //        // Create a department
    //        Department newDepartment = new Department
    //        {
    //            Name = departmentName,
    //        };

    //        // Add students to the department
    //        Console.Write("Enter the name of the first student: ");
    //        string student1Name = Console.ReadLine();

    //        if (!ValidateStudentName(student1Name))
    //        {
    //            return;
    //        }

    //        Student student1 = new Student
    //        {
    //            Name = student1Name,
    //        };

    //        Console.Write("Enter the name of the second student: ");
    //        string student2Name = Console.ReadLine();

    //        if (!ValidateStudentName(student2Name))
    //        {
    //            return;
    //        }

    //        Student student2 = new Student
    //        {
    //            Name = student2Name,
    //        };

    //        // Create lectures
    //        Console.Write("Enter the name of the first lecture: ");
    //        string lecture1Name = Console.ReadLine();

    //        if (!ValidateName(lecture1Name, "Lecture"))
    //        {
    //            return;
    //        }

    //        Lecture lecture1 = new Lecture
    //        {
    //            Name = lecture1Name,
    //        };

    //        Console.Write("Enter the name of the second lecture: ");
    //        string lecture2Name = Console.ReadLine();

    //        if (!ValidateName(lecture2Name, "Lecture"))
    //        {
    //            return;
    //        }

    //        Lecture lecture2 = new Lecture
    //        {
    //            Name = lecture2Name,
    //        };

    //        // Associate students and lectures with the department
    //        newDepartment.Students = new List<Student> { student1, student2 };
    //        newDepartment.Lectures = new List<Lecture> { lecture1, lecture2 };

    //        // Save changes to the database
    //        dbContext.Departments.Add(newDepartment);
    //        dbContext.SaveChanges();

    //        Console.WriteLine("Department, students, and lectures added successfully.");
    //    }

    //    // Validation for student names
    //    public static bool ValidateStudentName(string name, int maxAttempts = 5)
    //    {
    //        int validAttempts = 0;
    //        int invalidAttempts = 0;

    //        while (validAttempts + invalidAttempts < maxAttempts)
    //        {
    //            Console.Write($"Attempt {validAttempts + invalidAttempts + 1}: Enter the name of the student: ");
    //            name = Console.ReadLine();

    //            if (!string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit) && name.Length >= 2 && name.Length <= 50)
    //            {
    //                validAttempts++;
    //                Console.WriteLine("Valid input!");
    //            }
    //            else
    //            {
    //                invalidAttempts++;
    //                Console.WriteLine("Invalid input. Student name cannot be empty, contain whitespace, or include numbers.");
    //            }
    //        }

    //        Console.WriteLine($"Total valid attempts: {validAttempts}");
    //        Console.WriteLine($"Total invalid attempts: {invalidAttempts}");
    //        Console.WriteLine($"Exceeded maximum attempts ({maxAttempts}). Exiting.");
    //        return false;
    //    }

    //    public static bool ValidateName(string name, string entity, int maxAttempts = 5)
    //    {
    //        int validAttempts = 0;
    //        int invalidAttempts = 0;

    //        while (validAttempts + invalidAttempts < maxAttempts)
    //        {
    //            Console.Write($"Attempt {validAttempts + invalidAttempts + 1}: Enter the name of the {entity}: ");
    //            name = Console.ReadLine();

    //            if (!string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit))
    //            {
    //                validAttempts++;
    //                Console.WriteLine("Valid input!");
    //            }
    //            else
    //            {
    //                invalidAttempts++;
    //                Console.WriteLine($"Invalid input. {entity} name cannot be empty, contain whitespace, or include numbers.");
    //            }
    //        }

    //        Console.WriteLine($"Total valid attempts: {validAttempts}");
    //        Console.WriteLine($"Total invalid attempts: {invalidAttempts}");
    //        Console.WriteLine($"Exceeded maximum attempts ({maxAttempts}). Exiting.");
    //        return false;
    //    }

    //}

}

