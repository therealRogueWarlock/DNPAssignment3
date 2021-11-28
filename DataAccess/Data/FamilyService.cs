using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DNPAssignement3API.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Blazor_Authentication.Data.Impl
{
    public class FamilyService : IFamilyService
    {
        private FamilyDBContext _familyDbContext;
        
        public FamilyService(DbContext dbContext)
        {
            _familyDbContext = (FamilyDBContext) dbContext;
        }
        
        public async Task AddFamily(Family family)
        {
            _familyDbContext.Families.Add(family);
            await Update();
        }

        public async Task RemoveFamily(int familyId)
        {
            GetFamilies().Result.Remove(GetFamilies().Result.First(f => f.Id == familyId));
            await Update();
        }

        public async Task<IList<Family>> GetFamilies()
        {
            return _familyDbContext.Families.ToList();
        }

        
        public async Task Update()
        {
            await _familyDbContext.SaveChangesAsync();
        }
        
        
        public async Task<Family> GetFamily(int familyId)
        {
            return _familyDbContext.Families.FirstOrDefault(family =>
                family.Id == familyId);
        }

        public async Task RemoveAdult(int adultId)
        {
            foreach (Family family in _familyDbContext.Families)
            {
                Adult adult = family.Adults.FirstOrDefault(adult =>
                    adult.Id == adultId);

                if (adult != null)
                {
                    family.Adults.Remove(adult);
                    break;
                }
            }
            
            _familyDbContext.SaveChanges();
        }

        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> _adults = new();

            foreach (var family in _familyDbContext.Families)
            {
                _adults.AddRange(family.Adults);
            }

            return _adults;
        }

        public async Task<Adult> GetAdult(int id)
        {
            return GetAdults().Result.FirstOrDefault(adult =>
                adult.Id == id);
        }
    }
}