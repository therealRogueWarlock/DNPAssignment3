using Blazor_Authentication.model;

namespace Blazor_Authentication.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}