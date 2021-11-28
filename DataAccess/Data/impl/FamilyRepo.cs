using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Blazor.Data.Impl
{
    public class FamilyRepo : IFamilyService
    {
        private FamilyDBContext _familyDbContext;
        
        public FamilyRepo(DbContext dbContext)
        {
            _familyDbContext = (FamilyDBContext) dbContext;
        }
        
         public async Task AddFamily(Family family)
        {
            _familyDbContext.Families.Add(family);
            await _familyDbContext.SaveChangesAsync();
        }

         public async Task RemoveFamily(int familyId)
         {
             Family family = _familyDbContext.Families
                 .Include(family => family.Adults)
                 .Include(family1 => family1.Children)
                 .Include(family1 => family1.Pets).First(f => f.FamilyId == familyId);

             _familyDbContext.Families.Remove(family);
             
             await _familyDbContext.SaveChangesAsync();
         }
         
        public async Task<IList<Family>> GetFamilies()
        {
            return _familyDbContext.Families.Include(family => family.Adults).ToList();
        }
        
        public async Task UpdateFamily(Family family)
        {
            _familyDbContext.Update(family);
            await _familyDbContext.SaveChangesAsync();
        }
        
        public async Task<Family> GetFamily(int familyId)
        {
            return 
                _familyDbContext.Families
                    .Include(family => family.Adults)
                    .ThenInclude(adult => adult.Job)
                    .FirstOrDefault(family => family.FamilyId == familyId);
        }

        public async Task RemoveAdult(int adultId)
        {
            Adult adultToRemove = await _familyDbContext.Adults.FindAsync(adultId);
            _familyDbContext.Adults.Remove(adultToRemove);
            _familyDbContext.SaveChanges();
        }

        public async Task<IList<Adult>> GetAdults()
        {
            return await _familyDbContext.Adults.Include(adult => adult.Job).ToListAsync();
        }

        public async Task<Adult> GetAdult(int id)
        {
            return GetAdults().Result.First(adult =>
                adult.Id == id);
        }

        public async Task AddAdult(Adult adult)
        {
            _familyDbContext.Adults.Add(adult);
            await _familyDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateAdult(Adult adultToUpdate)
        {
            _familyDbContext.Adults.Update(adultToUpdate);
            _familyDbContext.SaveChanges();
        }
        
    
    }
}