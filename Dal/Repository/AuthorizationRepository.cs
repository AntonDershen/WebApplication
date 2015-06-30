using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.Repository;
using Dal.Interface.DTO;
using System.Data.Entity;
using ORM;
using Dal.Mapper;
namespace Dal.Repository
{
    public class AuthorizationRepository : IRepository<DalAuthorization>
    {
        private  DbContext context;
        public AuthorizationRepository(DbContext context)
        {
            this.context = context;
        }
        public DalAuthorization GetById(int Id)
        {
            Authorization auth = context.Set<Authorization>().FirstOrDefault(x => x.Id == Id);
            return auth.ToDalAuth();

        }
        public IEnumerable<DalAuthorization> GetAll()
        {
            return context.Set<Authorization>().Select(user => user.ToDalAuth());
        }
        public void Create(DalAuthorization dalAuth)
        {
            context.Set<Authorization>().Add(dalAuth.ToAuth());

        }
        public void Delete(DalAuthorization dalAuth)
        {
            Authorization auth = dalAuth.ToAuth();
            auth = context.Set<Authorization>().Single(a => a.Id == auth.Id);
            context.Set<Authorization>().Remove(auth);
        }
        public int GetId(DalAuthorization dalAuth)
        {
            return context.Set<Authorization>().FirstOrDefault(x => x.Email == dalAuth.Email).Id;
        }
        public DalAuthorization GetByName(string Email)
        {
            return context.Set<Authorization>().FirstOrDefault(x => x.Email == Email).ToDalAuth();
        }
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();

            }
        }
    }
}
