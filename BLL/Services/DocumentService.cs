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
            documentName += Constants.Constant.documentAddition;
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
        public void CreateDocument(DocumentEntity documentEntity, HttpPostedFileBase file, string userName)
        {
            byte[] fileContext = new byte[file.ContentLength];
            file.InputStream.Read(fileContext,0,file.ContentLength);
            documentRepository.Create(documentEntity.ToDalDocument());
            int id = documentRepository.GetId(documentEntity.ToDalDocument());
            DocumentContextEntity docContext = new DocumentContextEntity()
            {
                Path = 1,
                Context = fileContext,
                DocumentId = id
            };
            documentRepository.SaveContext(docContext.ToDalContext());
        }
        public void DeleteDocument(DocumentEntity documentEntity,string userName)
        {
            if (userName == documentEntity.UserName)
            {
                documentRepository.Delete(documentEntity.ToDalDocument());
                uow.Commit();
            }
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
        public void ChangeAccess(int id)
        {
            documentRepository.ChangeAccess(id);
        }
        public byte[] GetFileContext(int id)
        {
           return documentRepository.GetFileContext(id);
        }
    }
}
