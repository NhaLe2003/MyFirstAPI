
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Le",
                    LastName = "ABC",
                    Email = "ANC@gamil.com",
                    DateOfBirth = new DateTime(1993,8,15),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPaht = "Immage.abc"
                    
                }
                
                );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 2,
                    FirstName = "nguyen",
                    LastName = "xyz",
                    Email = "xyz@gamil.com",
                    DateOfBirth = new DateTime(1993, 8, 15),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPaht = "Immage.abc"
                }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 3,
                    FirstName = "Tran",
                    LastName = "DJC",
                    Email = "DJK@gamil.com",
                    DateOfBirth = new DateTime(1993, 8, 15),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPaht = "Immage.abc"
                }
                );
            //SaveChanges();
        }

    }
}
