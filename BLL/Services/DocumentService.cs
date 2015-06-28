using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using Dal.Interface.Repository;
using Dal.Interface.DTO;
using BLL.Mapper;
using Constants;
using System.Web;
using System.IO;
namespace BLL.Services
{
    public class DocumentService:IDocumentService
    {
        private readonly IUnitOfWork uow;
        private readonly IDocumentRepository documentRepository;
        public DocumentService(IUnitOfWork uow, IDocumentRepository repository)
        {
            this.uow = uow;
            this.documentRepository = repository;
        }
        public int FindDocument(string documentName)
        {
            DocumentEntity entity = documentRepository.GetByName(documentName).ToBllAuthorization();
            int documentId = 0;
            if (entity == null)
                return documentId;
            documentName += Constants.Constant.DocumentAddition;
            StringBuilder name;
            while (true)
            {
                name = new StringBuilder(documentName);
                documentId++;
                name.Insert(name.Length-(documentId-1).ToString().Length, documentId);
                entity = documentRepository.GetByName(name.ToString()).ToBllAuthorization();
                if (entity == null)
                    return documentId;
            }
        }
        public void CreateDocument(DocumentEntity documentEntity)
        {
            documentRepository.Create(documentEntity.ToDalDocument());
            uow.Commit();
        
        }
        public void DeleteDocument(DocumentEntity documentEntity,string userName)
        {
            if (userName == documentEntity.UserName)
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + documentEntity.DocumentPath);
                documentRepository.Delete(documentEntity.ToDalDocument());
                uow.Commit();
            }
        }
        public string SaveFile(HttpPostedFileBase file,string userName)
        {
            string path = "Documents\\" + userName + "\\";
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + path)) Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory+path);
            string fileName = DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
            file.SaveAs(AppDomain.CurrentDomain.BaseDirectory + path + fileName);
            return path+fileName;
        }
        public DocumentEntity FindById(int id)
        {
            return documentRepository.GetById(id).ToBllAuthorization();
        }
        public IEnumerable<DocumentEntity> FindDocumentByAdmin(string documentName) {
            IEnumerable<DalDocument> dalDocument = documentRepository.FindDocumentByAdmin(documentName);
            if (dalDocument != null)
                return dalDocument.Select(x => x.ToBllAuthorization());
            return null;

        }
    }
}
