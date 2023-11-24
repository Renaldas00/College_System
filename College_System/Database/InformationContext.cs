using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System.Database
{
    // InformationContext class represents database context for the application.
    public class InformationContext : DbContext
    {
        // Constructor for InformationContext that accepts DbContextOptions.
        public InformationContext(DbContextOptions options) : base(options)
        {
        }
        // DbSet for the Department/Lecture/Student/etc... entity, representing the departments in the database.
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }
        public DbSet<DepartmentLecture> DepartmentLectures { get; set; }

        // Override of OnModelCreating to configure the relationships between entities.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department to Student relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);// Restrict deletion if there are associated students

            // Student to Lecture relationship
            modelBuilder.Entity<StudentLecture>()
                .HasKey(sl => new { sl.StudentId, sl.LectureId });

            modelBuilder.Entity<StudentLecture>()
                .HasOne(sl => sl.Student)
                .WithMany(s => s.StudentLectures)
                .HasForeignKey(sl => sl.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if there are associated student lectures

            modelBuilder.Entity<StudentLecture>()
                .HasOne(sl => sl.Lecture)
                .WithMany(l => l.StudentLectures)
                .HasForeignKey(sl => sl.LectureId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lecture to Department and Student relationships
            modelBuilder.Entity<DepartmentLecture>()
                .HasKey(dl => new { dl.DepartmentId, dl.LectureId });

            modelBuilder.Entity<DepartmentLecture>()
           .HasOne(dl => dl.Department)
            .WithMany(d => d.DepartmentLectures)
            .HasForeignKey(dl => dl.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartmentLecture>()
                .HasOne(dl => dl.Lecture)
                .WithMany(l => l.DepartmentLectures)
                .HasForeignKey(dl => dl.LectureId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if there are associated department lectures
        }
    }
}
