using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
namespace BLL.Interface.Services
{
    public interface IDocumentService
    {
        int FindDocument(string name);
        void DeleteDocument(DocumentEntity documentEntity);
        void CreateDocument(DocumentEntity documentEntity);

    }
}
