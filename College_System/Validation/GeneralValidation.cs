using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System.Validation
{
    public partial class GeneralValidation
    {
        // Obtain valid input
        public static string GetValidInput(string prompt, Func<string, bool> validation)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!validation(input));

            // Return valid input
            return input;
        }

        public static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsValidDepartmentName(string name)
        {
            // Department name: 3 to 100 characters including letters, numbers, and spaces
            return !string.IsNullOrEmpty(name) && name.Length >= 3 && name.Length <= 100 && name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        }

        public static bool IsValidCredit(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
