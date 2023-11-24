using College_System.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System
{
    public class List
    {
        public static void MenuList(InformationContext dbContext)
        {

            // List of methods
            List<Action<InformationContext>> tasks = new List<Action<InformationContext>>
            {
                TaskOne.Task1,
                TaskTwo.Task2,
                TaskThree.Task3,
                TaskFour.Task4,
                TaskFive.Task5,
                TaskSix.Task6,
                TaskSeven.Task7,
                TaskEight.Task8
            };
            // Display menu
            while (true)
            {
                var taskNames = new List<string>
                {
                    "Sukurti departamentą ir į jį pridėti studentus, paskaitas.",
                    "Pridėti studentus/paskaitas į jau egzistuojantį departamentą.",
                    "Sukurti paskaitą ir ją priskirti prie departamento.",
                    "Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.",
                    "Perkelti studentą į kitą departamentą.",
                    "Atvaizduoti visus departamento studentus.",
                    "Atvaizduoti visas departamento paskaitas.",
                    "Atvaizduoti visas paskaitas pagal studentą.",
                };

                Console.WriteLine("Choose an option:");
                for (int i = 0; i < taskNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {taskNames[i]}");
                }

                Console.WriteLine($"{tasks.Count + 1}. Exit");

                Console.Write("Enter the number of the task to run: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= tasks.Count)
                    {
                        tasks[choice - 1].Invoke(dbContext);
                        Console.WriteLine("Task completed. Press Enter to continue.");
                        Console.ReadLine();
                    }
                    else if (choice == tasks.Count + 1)
                    {
                        Console.WriteLine("Exiting the program.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Enter a valid option.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a valid number.");
                }

                Console.Clear();
            }

        }
    }
}
