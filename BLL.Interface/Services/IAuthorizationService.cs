using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAuthorizationService
    {
        void CreateAuthorization(AuthorizationEntity authorization);
        void DeleteAuthorization(AuthorizationEntity authorization);
        AuthorizationEntity GetAuthorizationById(int id);
        bool CheckForm(AuthorizationEntity authorization);
        AuthorizationEntity GetAuthorizationByEmail(string Email);
    }
}
