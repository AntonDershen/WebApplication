using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
using ORM;
namespace Dal.Mapper
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this User user)
        {
            if (user != null)
            {
                return new DalUser()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            return null;
        }
        public static User ToUser(this DalUser dalUser)
        {
            if (dalUser != null)
            {
                return new User()
                {
                    Id = dalUser.Id,
                    UserName = dalUser.UserName
                };
            }
            return null;
        }

    }
}