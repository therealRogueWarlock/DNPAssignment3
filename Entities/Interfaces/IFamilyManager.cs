using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IFamilyService
    {
        Task AddFamily(Family family);
        Task RemoveFamily(int familyId);
        Task<IList<Family>> GetFamilies();
        Task UpdateFamily(Family family);
        Task<Family> GetFamily(int familyId);

        
        
        Task RemoveAdult(int adultId);
        Task<IList<Adult>> GetAdults();
        Task<Adult> GetAdult(int id);
        Task UpdateAdult(Adult adult);
    }
}