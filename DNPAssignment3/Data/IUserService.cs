using System.Threading.Tasks;
using DataAccess.model;

namespace DataAccess.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}