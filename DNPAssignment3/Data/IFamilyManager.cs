using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IFamilyManager
    {
        Task AddFamily(Family family);
        Task RemoveFamily(Family family);
        Task<IList<Family>> GetFamilies();
        Task UpdateFamily(Family family);
        Task<Family> GetFamily(int familyId);

        
        
        Task RemoveAdult(int adultId);
        Task<IList<Adult>> GetAdults();
        Task<Adult> GetAdult(int id);
        Task UpdateAdult(Adult adult);
    }
}