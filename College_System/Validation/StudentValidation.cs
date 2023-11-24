using College_System.Database;

namespace College_System.Validation
{
    public class StudentValidation
    {
        public static bool IsValidStudentName(string name)
        {
            // Validate student name: 2 to 50 characters including letters and spaces
            return !string.IsNullOrEmpty(name) && name.Length >= 2 && name.Length <= 50 && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        public static bool IsValidStudentNumber(int number, InformationContext dbContext)
        {
            // Validate student number: 8 digits
            if (number.ToString().Length != 8)
            {
                return false;
            }

            // Check if the student number is unique in the database
            return !dbContext.Students.Any(student => student.StudentNumber == number);
        }


        public static bool IsValidEmail(string email, string studentName, string studentLastName)
        {
            // Expected email format: StudentName.StudentLastName@gmail.com
            string expectedEmail = $"{studentName}.{studentLastName}@gmail.com";

            return email.Equals(expectedEmail, StringComparison.OrdinalIgnoreCase);
        }


    }
}
