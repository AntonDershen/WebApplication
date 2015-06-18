using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
using Dal.Interface.Repository;
using ORM;
using System.Data.Entity;
namespace Dal.Repository
{
        public class UserRepository : IUserRepository
        {
            private readonly DbContext context;

            public UserRepository(DbContext context)
            {
                this.context = context;
            }

            public IEnumerable<DalUser> GetAll()
            {
                return context.Set<User>().Select(user => new DalUser()
                {
                    Id = user.Id,
                    Name = user.Name,
                    RoleId = user.RoleId

                });
            }
            public void Create(DalUser e)
            {
                var user = new User()
                {
                    Name = e.Name,
                    RoleId = e.RoleId
                };
                context.Set<User>().Add(user);
            }
            public void Delete(DalUser e)
            {
                var user = new User()
                {
                    Id = e.Id,
                    Name = e.Name,
                    RoleId = e.RoleId
                };
                user = context.Set<User>().Single(u => u.Id == user.Id);
                context.Set<User>().Remove(user);
            }
            public void Update(DalUser entity)
            {
                throw new NotImplementedException();
            }
        }
}
