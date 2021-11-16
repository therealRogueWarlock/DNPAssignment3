using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Blazor_Authentication.Data
{
    public interface IFamilyManager
    {
        Task AddFamily(Family family);
        Task RemoveFamily(Family family);
        Task<IList<Family>> GetFamilies();
        Task Update();
        Task<Family> GetFamily(int familyId);

        
        
        Task RemoveAdult(int adultId);
        Task<IList<Adult>> GetAdults();
        Task<Adult> GetAdult(int id);
        
    }
}