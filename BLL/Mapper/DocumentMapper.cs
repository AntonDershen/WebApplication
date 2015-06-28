using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using Dal.Interface.DTO;

namespace BLL.Mapper
{
    public static class DocumentMapper
    {
        public static DalDocument ToDalDocument(this DocumentEntity documentEntity)
        {
            return new DalDocument()
            {
                Id = documentEntity.Id,
                CreateDate = documentEntity.CreateDate,
                DocumentPath = documentEntity.DocumentPath,
                Name = documentEntity.Name,
                UserId = documentEntity.UserId,
                Type = documentEntity.Type,
                Access = documentEntity.Access
            };
        }
        public static DocumentEntity ToBllAuthorization(this DalDocument dalDocument)
        {
            if (dalDocument != null)
            {
                return new DocumentEntity()
                {
                    Id = dalDocument.Id,
                    CreateDate = dalDocument.CreateDate,
                    DocumentPath = dalDocument.DocumentPath,
                    Name = dalDocument.Name,
                    UserId = dalDocument.UserId,
                    Type = dalDocument.Type,
                    Access = dalDocument.Access,
                    UserName = dalDocument.UserName
                };
            }
            return null;
        }
    }
}
