using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dal.Interface.DTO;
namespace Dal.Interface.Repository
{
     public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity e);
        void Delete(TEntity e);
        void Update(TEntity entity);
    }
}
