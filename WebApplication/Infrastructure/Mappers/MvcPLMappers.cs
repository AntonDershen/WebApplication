using BLL.Interface.Entities;
using MvcPL.Models;

namespace WebApplication.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static UserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                Role = userEntity.RoleId.ToString()
            };
        }
        public static UserEntity ToBllUser(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                RoleId =  1
            };
        }
    }
}