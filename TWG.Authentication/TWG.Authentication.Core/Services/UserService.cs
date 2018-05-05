using System.Runtime.InteropServices;
using TWG.Authentication.Core.Enums;
using TWG.Authentication.Core.Helper;
using TWG.Authentication.Core.Models;
using TWG.Authentication.Core.Providers;
using TWG.Authentication.Core.Providers.Interfaces;
using TWG.Authentication.Core.Services.Interfaces;

namespace TWG.Authentication.Core.Services
{
    public class UserService : IUserService
    {
        private IUserProvider _userProvider;

        private IUserProvider UserProvider
        {
            get { return _userProvider = _userProvider ?? new UserProvider(); }
        }

        public User Login(string userName, string password)
        {
            var result = UserProvider.Get(userName);

            if (result == null) return null;
            if (result.Status == Status.Inactive) return null;

            var login = UserProvider.GetLoginInfo(result.Id);

            return login.Password == HashHelper.GetPasswordHash(userName, password, login.Salt) ? result : null;
        }
    }
}