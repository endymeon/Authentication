using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TWG.Authentication.Core.Services;
using TWG.Authentication.Core.Services.Interfaces;
using TWG.Authentication.Web.Attributes;
using TWG.Authentication.Web.Models;

namespace TWG.Authentication.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        private IUserService UserService
        {
            get { return _userService = _userService ?? new UserService(); }
        }

        [TwgAuthenticationAttributes]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var userinfo = new LoginModel();

            try
            {
                EnsureLoggedOut();
                userinfo.ReturnUrl = returnUrl;

                return View(userinfo);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                var user = UserService.Login(model.Username, model.Password);

                if (user != null)
                {
                    SignInRemember(model.Username, model.IsRemember);
                    Session["UserID"] = user.Id;

                    return RedirectToLocal(model.ReturnUrl);
                }
                else
                {
                    //Login Fail
                    TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                    return View(model);
                }
            }
            catch
            {
                //TODO : logging
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToLocal();
            }
            catch
            {
                throw;
            }
        }

        private void SignInRemember(string userName, bool isPersistent = false)
        {
            FormsAuthentication.SignOut();

            FormsAuthentication.SetAuthCookie(userName, isPersistent);
        }

        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Index", "Account");
            }
            catch
            {
                throw;
            }
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

    }

}