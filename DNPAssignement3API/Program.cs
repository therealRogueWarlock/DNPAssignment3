
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.model;
using FileData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Models;


namespace DNPAssignement3API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            FamilyDBContext familyDbContext = new FamilyDBContext();

            FileContext fileContext = new FileContext();
            
            IList<Family> families = fileContext.Families;
            
            foreach (var family in families)
            {
                Console.WriteLine(family.GetFamilyName());
            }
            
            
            IList<User> users = new[]
            {
                new User
                {
                    City = "Horsens", Domain = "via.dk", Password = "123456", Role = "Teacher", BirthYear = 1986,
                    SecurityLevel = 4, UserName = "Troels"
                },
                new User
                {
                    City = "Aarhus", Domain = "hotmail.com", Password = "654321", Role = "Student", BirthYear = 1998,
                    SecurityLevel = 2, UserName = "Jakob"
                },
                new User
                {
                    City = "Randers", Domain = "via.dk", Password = "123", Role = "Student", BirthYear = 1995,
                    SecurityLevel = 3, UserName = "Sander"
                }
            }.ToList();

            familyDbContext.Families.AddRange(families);
            familyDbContext.Users.AddRange(users);
            familyDbContext.SaveChanges();

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}