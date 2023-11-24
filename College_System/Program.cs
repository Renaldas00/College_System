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
            Console.WriteLine("Information system");
            var dbContext = new InformationContext(new DbContextOptionsBuilder<InformationContext>()
                .UseSqlServer($"Server=DESKTOP-STN7AQ8\\SQLEXPRESS;Database=StudentInformationSystem;Trusted_Connection=True;TrustServerCertificate=True;").Options);
            //dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            // Call the menu method
            List.MenuList(dbContext);
        }
    }
}
