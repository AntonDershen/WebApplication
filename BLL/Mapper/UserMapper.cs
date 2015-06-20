using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using Dal.Interface.DTO;
namespace BLL.Mapper
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                RoleId = userEntity.RoleId
            };
        }
        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.UserName,
                RoleId = dalUser.RoleId
            };
        }
    }
}
