using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using Dal.Interface.DTO;
namespace BLL.Mapper
{
    public static class RoleMapper
    {
        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity
            {
                Id = dalRole.Id,
                Description = dalRole.Descripition
            };
        }
        public static DalRole ToDalRole(this RoleEntity bllRole)
        {
            return new DalRole
            {
                Id = bllRole.Id,
                Descripition = bllRole.Description
            };
        }
    }
}
