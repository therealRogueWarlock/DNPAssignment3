using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.model;

namespace Blazor.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
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
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}