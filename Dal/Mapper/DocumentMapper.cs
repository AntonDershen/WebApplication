using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
using ORM;
namespace Dal.Mapper
{
    public static class DocumentMapper
    {
        public static Document ToDocument (this DalDocument dalDocument)
        {
            return new Document()
            {

                Name = dalDocument.Name,
                CreateDate = dalDocument.CreateDate,
                DocumentPath = dalDocument.DocumentPath,
                UserId = dalDocument.UserId,
                Type = dalDocument.Type
            };
        }
        public static DalDocument ToDalDocument(this Document document)
        {
            if (document != null)
            {
                return new DalDocument()
                {
                    Id = document.Id,
                    Name = document.Name,
                    CreateDate = document.CreateDate,
                    DocumentPath = document.DocumentPath,
                    UserId = document.UserId,
                    Type = document.Type
                };
            }
            return null;
        }
    }
}
