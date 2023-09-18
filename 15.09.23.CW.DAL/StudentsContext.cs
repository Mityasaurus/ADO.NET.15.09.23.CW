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

            base.OnModelCreating(modelBuilder);
        }
    }
}
