using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using System.Web;
namespace BLL.Interface.Services
{
    public interface IDocumentService
    {
        DocumentEntity FindById(int id);
        int FindDocument(string name);
        void DeleteDocument(DocumentEntity documentEntity,string userName);
        void CreateDocument(DocumentEntity documentEntity);
        string SaveFile(HttpPostedFileBase file,string userName);
        IEnumerable<DocumentEntity> FindDocumentByAdmin(string documentName);
    }
}
