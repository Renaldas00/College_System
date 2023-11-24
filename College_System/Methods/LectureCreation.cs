using College_System.Database.Models;
using College_System.Validation;
namespace College_System.Methods
{
    public class LectureCreation
    {
        // Create new Lecture object
        public static Lecture CreateLecture()
        {
            return new Lecture
            {
                // Set properties
                LectureName = LectureValidation.GetValidLectureName(),
                LectureLenght = GeneralValidation.GetValidInput("Enter the lecture length (format: starting hours ending hours): ", LectureValidation.IsValidLectureLength),
                LectureCredit = int.Parse(GeneralValidation.GetValidInput("Enter lecture credit score (whole number): ", GeneralValidation.IsValidCredit))
            };
        }
    }
}
