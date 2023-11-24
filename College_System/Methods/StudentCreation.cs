using College_System.Database;
using College_System.Database.Models;
using College_System.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System.Methods
{
    public class StudenCreation
    {
        public static Student CreateStudent(InformationContext dbContext)
        {
            string studentName = GeneralValidation.GetValidInput("Enter the students first name (2 to 50 letters): ", StudentValidation.IsValidStudentName);
            string studentLastName = GeneralValidation.GetValidInput("Enter the students last name (2 to 50 letters): ", StudentValidation.IsValidStudentName);

            string studentEmail = GeneralValidation.GetValidInput("Enter the students email: ", input =>
            {
                bool isValid = StudentValidation.IsValidEmail(input, studentName, studentLastName);
                if (!isValid)
                {
                    Console.WriteLine("Error: Invalid email format. Please use the format 'name.lastname@gmail.com'.");
                }
                return isValid;
            });

            return new Student
            {
                // Set properties
                StudentName = studentName,
                StudentLastName = studentLastName,
                StudentNumber = int.Parse(GeneralValidation.GetValidInput("Enter the student number (8 digits): ", input =>
                    StudentValidation.IsValidStudentNumber(int.Parse(input), dbContext))),
                StudentEmail = studentEmail
            };
        }


    }
}
