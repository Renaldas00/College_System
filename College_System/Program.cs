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
    internal class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Information system");
                // Create a new instance of the 'InformationContext' using SQL Server and specific options
                var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                    .UseSqlServer($"Server=PETSIA78\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
                // Ensure the database is created (or deleted if needed) before proceeding
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                // Call the menu method
                List.MenuList(dbContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
