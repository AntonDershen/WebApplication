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
        private readonly IUserService UserService;
        private readonly IRoleService RoleService;
        public override string ApplicationName { get; set; }

        public CustomRoleProvider()
        {
            UserService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            RoleService = (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            UserEntity user = UserService.GetUserByName(login);
            int id = RoleService.GetIdByDescriptor(roleName);
            if (user != null && id == user.RoleId)
                return true;
            return false;
        }
        public CustomRoleProvider(IRoleService roleService, IUserService userService)
        {
            RoleService = roleService;
            UserService = userService;
        }
        public override string[] GetRolesForUser(string login)
        {
            UserEntity user = UserService.GetUserByName(login);
            List<RoleEntity> roles = RoleService.GetAll().Where(role=>role.Id == user.RoleId).ToList();
            List<string> userRole= new List<string>();
            foreach (var role in roles)
                userRole.Add(role.Description);
            return userRole.ToArray();
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

        #region UnusedMethods
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

        #endregion
    }
}
