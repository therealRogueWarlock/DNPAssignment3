using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor;
using Blazor.Data;
using Blazor.model;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class UserService : IUserService
    {
        private List<User> users;
        
        public UserService(DbContext dbContext)
        {
            FamilyDBContext _familyDbContext = (FamilyDBContext) dbContext;

            users = _familyDbContext.Users.ToList();
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