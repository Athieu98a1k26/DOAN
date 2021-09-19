using System;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class AuthenticateUser : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        ///     Securing cookie
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var tempSession =
                Convert.ToString(filterContext.HttpContext.Session["AuthenticationToken"]);
            var requestCookie = filterContext.HttpContext.Request.Cookies["AuthenticationToken"];
            var tempAuthCookie = requestCookie == null ? null : Convert.ToString(requestCookie.Value);
            if (tempAuthCookie != null)
            {
                if (!tempSession.Equals(tempAuthCookie))
                {
                    RedirectToLogin(filterContext);
                }
            }
            else
            {
                RedirectToLogin(filterContext);
            }
        }

        private void RedirectToLogin(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies[".AspNet.ApplicationCookie"] != null)
            {
                filterContext.HttpContext.Response.Cookies[".AspNet.ApplicationCookie"].Value = string.Empty;
                filterContext.HttpContext.Response.Cookies[".AspNet.ApplicationCookie"].Expires = DateTime.Now.AddMonths(-10);
            }
            var returnUrl = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.PathAndQuery);
            filterContext.Result = new RedirectResult("/Account?returnUrl=" + returnUrl);
        }
    }
}