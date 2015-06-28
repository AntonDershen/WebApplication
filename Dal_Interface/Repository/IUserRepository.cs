using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dal.Interface.DTO;
using Dal.Interface.Repository;
namespace Dal.Interface.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        IEnumerable<DalDocument> GetAllDocument(string userName);
        bool CheckUserRole(string userName,string userRole);
    }
}
