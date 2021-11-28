using DataAccess.model;

namespace Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}