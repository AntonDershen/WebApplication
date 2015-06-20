using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Infrastructure.Mappers
{
    public static class RegisterMapper
    {
        public static UserEntity ToBllUser(this RegisterModel registerModel)
        {
            return new UserEntity
            {
                UserName = registerModel.UserName,
                RoleId = 1
            };
        }
        public static AuthorizationEntity ToBllAuthorization(this RegisterModel registerModel)
        {
            return new AuthorizationEntity
            {
                Login = registerModel.UserName,
                Password = registerModel.Password
            };
        
        }
    }
}