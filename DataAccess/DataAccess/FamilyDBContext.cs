using Blazor_Authentication.model;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Family> Families { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasKey();
            modelBuilder.Entity<User>().HasKey(user => user.UserName);
            modelBuilder.Entity<Interest>().HasKey(interest => interest.Type);
        }
    }
}