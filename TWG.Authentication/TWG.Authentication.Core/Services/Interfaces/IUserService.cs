using TWG.Authentication.Core.Models;

namespace TWG.Authentication.Core.Services.Interfaces
{
    public interface IUserService
    {
        User Login(string userName, string password);
    }
}