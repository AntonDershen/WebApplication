using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Services;
using BLL.Interface.Entities;
namespace WebApplication.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {
        private IUserService userService;
        public override string ApplicationName { get; set; }

        public CustomRoleProvider()
        {
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            using (userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)))
            {
               return userService.CheckUserRole(login, roleName);
                
            }
        }

        public override string[] GetRolesForUser(string login)
        {
            using (userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)))
            {
                List<string> roles = new List<string>();
                if (userService.CheckUserRole(login, "User"))
                    roles.Add("User");
                if (userService.CheckUserRole(login, "Admin"))
                    roles.Add("Admin");
                return roles.ToArray();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

    }
}
