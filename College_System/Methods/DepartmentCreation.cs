using College_System.Database.Models;
using College_System.Validation;
namespace College_System.Methods
{
   public class DepartmentCreation
      {
        public static Department CreateDepartment()
        {
            Department department;
            do
            {
                Console.Write("Enter the department name (3 to 100 letters and numbers): ");
                // Init the department variable with a new Department object
                // Set the DepartmentName property based on user input
                department = new Department { DepartmentName = Console.ReadLine() };
            } while (!GeneralValidation.IsValidDepartmentName(department.DepartmentName));

            // Generate and set the DepartmentCode property with a random code
            department.DepartmentCode = GeneralValidation.GenerateRandomCode(6);

            return department;
        }
   }
}
