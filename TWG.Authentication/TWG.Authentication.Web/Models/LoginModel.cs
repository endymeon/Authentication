namespace TWG.Authentication.Web.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool IsRemember { get; set; }
    }
}