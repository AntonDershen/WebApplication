using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using Dal.Interface.DTO;
namespace Dal.Mapper
{
    public static class RoleMapper
    {
        public static Role ToRole(this DalRole dalRole)
        {
            return new Role()
            {
                Id = dalRole.Id,
                Description = dalRole.Descripition
                
            };
        }
        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Descripition = role.Description
            };
        }
    }
}
