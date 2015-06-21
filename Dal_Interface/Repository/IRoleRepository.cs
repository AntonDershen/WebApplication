using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
namespace Dal.Interface.Repository
{
    public interface IRoleRepository<TEntity> where TEntity : IEntity
    {
        void InitializeDb(IEnumerable<TEntity> entities);
        int GetIdByDescriptor(string descriptor);

    }
}
