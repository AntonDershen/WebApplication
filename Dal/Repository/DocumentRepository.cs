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
    
    public class DocumentRepository:IDocumentRepository
    {
        private  DbContext context;
        public DocumentRepository(DbContext context)
        {
            this.context = context;
        }
        public DalDocument GetById(int Id)
        {
           return context.Set<Document>().FirstOrDefault(x => x.Id == Id).ToDalDocument();
        }
        public IEnumerable<DalDocument> GetAll()
        {
            return null;
        }
        public void SaveContext(DalDocumentContext dalContext) {
            context.Set<DocumentContext>().Add(dalContext.ToContext());
            context.SaveChanges();
        }
        public void Create(DalDocument dalDocument)
        {
            context.Set<Document>().Add(dalDocument.ToDocument());
            context.SaveChanges();
           
        }
        public void Delete(DalDocument dalDocument)
        {
            List<DocumentContext> docContext = new List<DocumentContext>();
            Document doc = dalDocument.ToDocument();
            doc = context.Set<Document>().Single(a => a.Id == doc.Id);
            docContext = doc.DocumentContext.ToList();
            for (int i = 0; i < docContext.Count; i++)
                  context.Set<DocumentContext>().Remove(docContext[i]);
            context.Set<Document>().Remove(doc);
        }
        public int GetId(DalDocument dalDocument)
        {
            return context.Set<Document>().Where(x => x.UserId == dalDocument.UserId).FirstOrDefault(x => x.Name == dalDocument.Name).Id;
        }
        public DalDocument GetByName(string Name)
        {
            return context.Set<Document>().FirstOrDefault(x => x.Name == Name).ToDalDocument();
        }
        public IEnumerable<DalDocument> FindDocumentByAdmin(string documentName) {
            IEnumerable<Document> document = context.Set<Document>().Where(x => x.Name.Contains(documentName));
            if (document != null)
                return document.Select(x => x.ToDalDocument());
            return null;
        }
        public void ChangeAccess(int id)
        {
            try
            {
                context.Set<Document>().Find(id).Access = !context.Set<Document>().Find(id).Access;
                context.SaveChanges();
            }
            catch { };
        }
        public byte[] GetFileContext(int id)
        {
            Document document = context.Set<Document>().Find(id);
            List<DocumentContext> docContext = new List<DocumentContext>();
            int size=0;
            foreach (var documentContext in document.DocumentContext)
                size += documentContext.Context.Length;
            List<byte> fileContext = new List<Byte>();
            docContext = document.DocumentContext.ToList();
            for (int i = 0; i < docContext.Count; i++)
                fileContext.AddRange(docContext[i].Context);
            return fileContext.ToArray();
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
