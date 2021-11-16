using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssignement3API.Data;
using FileData;
using Models;

namespace Blazor_Authentication.Data.Impl
{
    public class FamilyService : IFamilyService
    {
        private FileContext _fileContext;

        
        
        public FamilyService()
        {
            _fileContext = new FileContext();
            Console.WriteLine("commentar");
        }
        public async Task AddFamily(Family family)
        {
            _fileContext.Families.Add(family);
            _fileContext.SaveChanges();
        }

        public async Task RemoveFamily(int familyId)
        {
            GetFamilies().Result.Remove(GetFamilies().Result.First(f => f.Id == familyId));
            _fileContext.SaveChanges();
        }

        public async Task<IList<Family>> GetFamilies()
        {
            return _fileContext.Families;
        }

        
        public async Task Update()
        {
            _fileContext.SaveChanges();
        }
        
        
        
        public async Task<Family> GetFamily(int familyId)
        {
            return _fileContext.Families.FirstOrDefault(family =>
                family.Id == familyId);
        }

        public async Task RemoveAdult(int adultId)
        {
            foreach (Family family in _fileContext.Families)
            {
                Adult adult = family.Adults.FirstOrDefault(adult =>
                    adult.Id == adultId);

                if (adult != null)
                {
                    family.Adults.Remove(adult);
                    break;
                }
            }
            
            _fileContext.SaveChanges();
        }

        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> _adults = new();

            foreach (var family in _fileContext.Families)
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