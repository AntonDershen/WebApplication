using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
using Dal.Interface.Repository;
using ORM;
using System.Data.Entity;
using Dal.Mapper;
namespace Dal.Repository
{
    public class UserRepository : IUserRepository
        {
            private readonly DbContext context;
            public UserRepository(DbContext context)
            {
                this.context = context;
            }
            public DalUser GetById(int Id)
            {
                User user =  context.Set<User>().FirstOrDefault(x => x.Id == Id);
                return UserMapper.ToDalUser(user);
                
            }
            public IEnumerable<DalUser> GetAll()
            {
                return context.Set<User>().Select(user => UserMapper.ToDalUser(user));
            }
            public void Create(DalUser dalUser)
            {
                context.Set<User>().Add(UserMapper.ToUser(dalUser));
     
            }
            public void Delete(DalUser dalUser)
            {
                User user = UserMapper.ToUser(dalUser);
                user = context.Set<User>().Single(u => u.Id == user.Id);
                context.Set<User>().Remove(user);
            }
            public int GetId(DalUser dalUser) {
                return context.Set<User>().FirstOrDefault(x => x.UserName == dalUser.UserName).Id;
            }
            public DalUser GetByName(string UserName)
            {
                return context.Set<User>().FirstOrDefault(x => x.UserName == UserName).ToDalUser();
            }
            public IEnumerable<DalDocument> GetAllDocument(string userName)
            {
                User user = context.Set<User>().FirstOrDefault(u=>u.UserName == userName);
                if(user!=null)
                return user.Documents.Select(x=>x.ToDalDocument());
                return null;
            }

        }
}
