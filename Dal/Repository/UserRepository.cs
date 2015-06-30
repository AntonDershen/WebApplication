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
using Constants;
namespace Dal.Repository
{
    public class UserRepository : IUserRepository
        {
            private  DbContext context;
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
                List<Document> documents = user.Documents.ToList();
                for(int i =0;i<documents.Count;i++)
                    context.Set<Document>().Remove(documents[i]);
                context.Set<User>().Remove(user);
            }
            public int GetId(DalUser dalUser) {
                return context.Set<User>().FirstOrDefault(x => x.UserName == dalUser.UserName).Id;
            }
            public DalUser GetByName(string UserName)
            {
                try
                {
                    return context.Set<User>().FirstOrDefault(x => x.UserName == UserName).ToDalUser();
                }
                catch { return null; }
            }
            public IEnumerable<DalDocument> GetAllDocument(string userName)
            {
                User user = context.Set<User>().FirstOrDefault(u=>u.UserName == userName);
                if(user!=null)
                return user.Documents.Select(x=>x.ToDalDocument());
                return null;
            }
            public bool CheckUserRole(string userName,string UserRole)
            {
                try{
                User user = context.Set<User>().FirstOrDefault(x => x.UserName == userName);
                if (user.Role.Description == UserRole)
                    return true;
                return false;
                }catch
                {
                    return false;
                }
            }
            public IEnumerable<DalUser> GetUserAdminFind(string userName) {

                IEnumerable<User> user = context.Set<User>().Where(x => x.UserName.Contains(userName));
                user = user.Where(x => x.Role.Description != Constant.admin);
                if(user!=null)
                    return user.Select(x => x.ToDalUser());
                return null;
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
