using System.Web;
using System.Web.Mvc;

namespace TWG.Authentication.Web.Attributes
{
    public class TwgAuthenticationAttributes : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["UserID"] != null && HttpContext.Current.Request.IsAuthenticated) return;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 302; 
                filterContext.HttpContext.Response.End();
            }
            else
            {
                filterContext.Result = new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl + "?ReturnUrl=" +
                                                          filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));
            }
        }
    }
}