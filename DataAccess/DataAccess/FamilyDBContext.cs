using DataAccess.model;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Sander\RiderProjects\DNPAssignment3\DataAccess\Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.UserName);

            modelBuilder.Entity<Adult>().HasKey(adult => adult.Id);
            
        }
    }
}