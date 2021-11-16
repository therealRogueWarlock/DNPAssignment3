using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DNPAssignement3API.Data
{
    public interface IFamilyService
    {
        Task AddFamily(Family family);
        Task RemoveFamily(int familyId);
        Task<IList<Family>> GetFamilies();
        Task Update();
        Task<Family> GetFamily(int familyId);
        
        Task RemoveAdult(int adultId);
        Task<IList<Adult>> GetAdults();
        Task<Adult> GetAdult(int id);
        
    }
}