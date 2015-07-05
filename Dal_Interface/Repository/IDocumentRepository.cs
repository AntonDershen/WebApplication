using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.Repository;
using Dal.Interface.DTO;
namespace Dal.Interface.Repository
{
   public interface IDocumentRepository : IRepository<DalDocument>
    {
       IEnumerable<DalDocument> FindDocumentByAdmin(string documentName);
       void ChangeAccess(int id);
       void SaveContext(DalDocumentContext dalContext);
       byte[] GetFileContext(int id);
    }
}
