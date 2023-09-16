using _15._09._23.CW.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace _15._09._23.CW.DAL
{
    public class StudentsContext : DbContext
    {
        public virtual DbSet<Student> Students {  get; set; }

        public virtual DbSet<StudentCard> StudentCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentCard)
                .WithOne(s => s.Student)
                .HasForeignKey<StudentCard>(sc => sc.ID);

            //var studentCard1 = new StudentCard
            //{
            //    ID = 1,
            //    StartDate = DateTime.Parse("2023-09-15"),
            //    IsActive = true
            //};

            //var studentCard2 = new StudentCard
            //{
            //    ID = 2,
            //    StartDate = DateTime.Parse("2023-01-15"),
            //    IsActive = true
            //};

            //var studentCard3 = new StudentCard
            //{
            //    ID = 3,
            //    StartDate = DateTime.Parse("2023-02-20"),
            //    IsActive = true
            //};

            //var studentCard4 = new StudentCard
            //{
            //    ID = 4,
            //    StartDate = DateTime.Parse("2023-03-10"),
            //    IsActive = true
            //};

            //modelBuilder.Entity<StudentCard>().HasData(
            //    studentCard1,
            //    studentCard2,
            //    studentCard3,
            //    studentCard4
            //    );

            //var student1 = new Student
            //{
            //    ID = 1,
            //    Name = "Ivan",
            //    LastName = "Sokolov",
            //    DateOfBirth = DateTime.Parse("2000-01-15"),
            //    Mail = "ivan@example.com",
            //    Phone = "+380991234567",
            //    StudentCard = studentCard1
            //};

            //var student2 = new Student
            //{
            //    ID = 2,
            //    Name = "Anna",
            //    LastName = "Petrova",
            //    DateOfBirth = DateTime.Parse("1998-05-20"),
            //    Mail = "anna@example.com",
            //    Phone = "+380981234567",
            //    StudentCard = studentCard2
            //};

            //var student3 = new Student
            //{
            //    ID = 3,
            //    Name = "Oleg",
            //    LastName = "Trynko",
            //    DateOfBirth = DateTime.Parse("2002-03-10"),
            //    Mail = "oleg@example.com",
            //    Phone = "+380971234567",
            //    StudentCard = studentCard3
            //};

            //var student4 = new Student
            //{
            //    ID = 4,
            //    Name = "Olena",
            //    LastName = "Kozlova",
            //    DateOfBirth = DateTime.Parse("1999-09-05"),
            //    Mail = "olena@example.com",
            //    Phone = "+380961234567",
            //    StudentCard = studentCard4
            //};

            //modelBuilder.Entity<Student>().HasData(
            //    student1,
            //    student2,
            //    student3,
            //    student4
            //    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
