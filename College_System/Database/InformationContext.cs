using College_System.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_System.Database
{
    public class InformationContext : DbContext
    {
        public InformationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department to Lecture Relationship
            modelBuilder.Entity<Lecture>()
                .HasOne(lecture => lecture.Department)
                .WithMany(department => department.Lectures)
                .HasForeignKey(lecture => lecture.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade, depending on your needs

            // Department to Student Relationship
            modelBuilder.Entity<Student>()
                .HasOne(student => student.Department)
                .WithMany(department => department.Students)
                .HasForeignKey(student => student.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade, depending on your needs

            // Student to Lecture Relationship (Many-to-Many)
            modelBuilder.Entity<StudentLecture>()
                .HasKey(sl => new { sl.StudentId, sl.LectureId });

            modelBuilder.Entity<StudentLecture>()
                .HasOne(sl => sl.Student)
                .WithMany(student => student.StudentLectures)
                .HasForeignKey(sl => sl.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentLecture>()
                .HasOne(sl => sl.Lecture)
                .WithMany(lecture => lecture.StudentLectures)
                .HasForeignKey(sl => sl.LectureId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
