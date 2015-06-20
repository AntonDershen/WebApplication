using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using Dal.Interface.DTO;

namespace BLL.Mapper
{
    public static  class AuthorizationMapper
    {
        public static DalAuthorization ToDalAuthorization(this AuthorizationEntity authorisationEntity)
        {
            return new DalAuthorization()
            {
                Id = authorisationEntity.Id,
                Login = authorisationEntity.Login,
                Password = authorisationEntity.Password
            };
        }
        public static AuthorizationEntity ToBllAuthorization(this DalAuthorization dalAuthorisation)
        {
            return new AuthorizationEntity()
            {
                Id = dalAuthorisation.Id,
                Login = dalAuthorisation.Login,
                Password = dalAuthorisation.Password
            };
        }
    }
}
