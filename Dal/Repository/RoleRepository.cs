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
   public class RoleRepository :IRoleRepository<DalRole>
    {
       private  DbContext context;
       public RoleRepository(DbContext context)
       {
           this.context = context;
       }
       public int GetIdByDescriptor(string descriptor)
       {
           return context.Set<Role>().FirstOrDefault(x => x.Description == descriptor).Id;
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
