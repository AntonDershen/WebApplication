using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using System.Web.Security;
namespace WebApplication.Filters
{
    public class CheckRoleAttribute : AuthorizeAttribute
    {
        private IUserService userService;
        private string[] allowedRoles = new string[] { };
        public CheckRoleAttribute()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!String.IsNullOrEmpty(base.Roles))
            {

                allowedRoles = base.Roles.Split(new char[] { ',' });
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }

            }
            return httpContext.Request.IsAuthenticated && Role(httpContext);
        }
        private bool Role(HttpContextBase httpContext)
        {
            using (userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)))
            {
                if (allowedRoles.Length > 0)
                {
                    HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie == null)
                        return false;
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    string name = ticket.Name;

                    for (int i = 0; i < allowedRoles.Length; i++)
                    {
                        if (userService.CheckUserRole(name, allowedRoles[i]))
                            return true;
                    }
                }
                return false;
            }
            return true;
        }
    }
}