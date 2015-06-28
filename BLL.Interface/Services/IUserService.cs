using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
namespace BLL.Interface.Services
{
    public interface IUserService:IDisposable
    {
        IEnumerable<UserEntity> GetAllUserEntities();
        int CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        UserEntity GetUserById(int id);
        UserEntity GetUserByName(string name);
        IEnumerable<DocumentEntity> GetUserDocument(string userName);
        IEnumerable<UserEntity> GetUserAdminFind(string userName);
        bool CheckUserRole(string userName, string userRole);
    }
}
