using TWG.Authentication.Core.Enums;

namespace TWG.Authentication.Core.Models
{
    internal class LoginInfo
    {
        public int Id { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
    }
}