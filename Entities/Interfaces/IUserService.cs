using System.Threading.Tasks;
using Blazor.model;

namespace Blazor.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}