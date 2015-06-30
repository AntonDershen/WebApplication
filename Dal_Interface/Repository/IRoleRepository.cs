using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
namespace Dal.Interface.Repository
{
    public interface IRoleRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        int GetIdByDescriptor(string descriptor);

    }
}
