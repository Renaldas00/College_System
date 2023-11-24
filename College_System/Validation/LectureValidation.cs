using College_System.Database;

namespace College_System.Validation
{
    
        public class LectureValidation
        {

        public static string GetValidLectureName()
        {
            string lectureName;
            do
            {
                Console.Write("Enter the lecture name (more than 5 characters and unique): ");
                lectureName = Console.ReadLine();
            } while (!IsValidLectureName(lectureName));

            return lectureName;
        }

        public static bool IsValidLectureName(string name)
        {
            if (name.Length <= 5)
            {
                return false;
            }

            // Check if the name contains only white spaces letters and numbers
            return !string.IsNullOrEmpty(name) && name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        }

        public static bool IsValidLectureLength(string length)
        {
            // The format should be: starting hours ending hours
            string[] times = length.Split(' ');

            if (times.Length != 2)
            {
                Console.WriteLine("Invalid time format. Use the format: starting hours ending hours.");
                return false;
            }

            if (!int.TryParse(times[0].Trim(), out int startTime) || !int.TryParse(times[1].Trim(), out int endTime))
            {
                Console.WriteLine("Invalid time format. Enter valid integers for starting and ending hours.");
                return false;
            }

            // Validate time constraints
            if (!IsValidTime(startTime) || !IsValidTime(endTime) || startTime >= endTime)
            {
                Console.WriteLine("Invalid time range. Ensure that the starting time is earlier than the ending time, and both are between 7 and 22.");
                return false;
            }

            return true;
        }

        public static bool IsValidTime(int time)
        {
            // Validate time constraints (between 7h and 22h)
            return time >= 7 && time <= 22;
        }

        public static bool IsDuplicateLecture(string lectureName, InformationContext dbContext)
        {
            // Check if any lecture in the database has the same name
            return dbContext.Lectures.Any(lecture => lecture.LectureName == lectureName);
        }
    }
}
