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
        private readonly IRepository<DalDocument> documentRepository;
        public DocumentService(IUnitOfWork uow, IRepository<DalDocument> repository)
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
            documentName += Constants.Constants.DocumentAddition;
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
        public void DeleteDocument(DocumentEntity documentEntity)
        {
            documentRepository.Delete(documentEntity.ToDalDocument());
            uow.Commit();

        }
        public string SaveFile(HttpPostedFileBase file,string name,string userName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory +userName+"\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            string fileName = name;
            file.SaveAs(path + fileName);
            return path;
        }
    }
}
