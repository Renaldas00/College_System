using College_System.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System
{
    internal partial class Program
    {
        static void Main()
        {

            Console.WriteLine("Many to many");

            var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            ////////////// Task 1 /////////////
            TaskOne.Task1();
            //////////////// TASK 2 ////////////////
            //TaskTwo.Task2();
            //// Task 3 //
            //TaskThree.Task3();
            /////// Task 4 /////
            //TaskFour.Task4();
            /////// Task 5 /////
            //TaskFive.Task5();
            //// Task 6 //
            //TaskSix.Task6();
            //// Task 7 //
            //TaskSeven.Task7();
            //// Task 8 //
            //TaskEight.Task8();
        }
    }
}


