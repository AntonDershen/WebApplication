using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
using ORM;
namespace Dal.Mapper
{
    public static class AuthorizationMapper
    {
        public static DalAuthorization ToDalAuth(this Authorization auth)
        {
            if (auth != null)
            {
                return new DalAuthorization()
                {
                    Id = auth.Id,
                    Email = auth.Email,
                    Password = auth.Password,
                    UserId = auth.UserId
                };
            }
            return null;
        
        }
        public static Authorization ToAuth(this DalAuthorization dalAuth)
        {

            if (dalAuth != null)
            {
                return new Authorization()
                {
                    Id = dalAuth.Id,
                    Email = dalAuth.Email,
                    Password = dalAuth.Password,
                    UserId = dalAuth.UserId
                };
            }
            return null;
        }

    }
}
