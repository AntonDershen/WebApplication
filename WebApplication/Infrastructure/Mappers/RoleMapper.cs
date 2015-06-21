using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Infrastructure.Mappers
{
    public static class RoleMapper
    {
        public static RoleEntity ToBllRole(this RoleModel roleModel)
        {
            return new RoleEntity
            {

                Id = roleModel.Id,
                Description = roleModel.Description
            };

        }
        public static RoleModel ToBllRole(this RoleEntity roleEntity)
        {
            return new RoleModel
            {

                Id = roleEntity.Id,
                Description = roleEntity.Description
            };

        }
    }
}