using TWG.Authentication.Core.Models;

namespace TWG.Authentication.Core.Providers.Interfaces
{
    internal interface IUserProvider
    {
        User Get(string userName);
        User GetById(int userId);
        LoginInfo GetLoginInfo(int userId); 
    }
}