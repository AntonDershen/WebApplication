using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Infrastructure.Mappers
{
    public static class DocumentMapper
    {
        public static DocumentModel ToDocument(this DocumentEntity documentEntity)
        {
            if (documentEntity != null)
            {
                return new DocumentModel()
                {
                    Name = documentEntity.Name,
                    CreateDate = documentEntity.CreateDate,
                    Type = documentEntity.Type,
                    Id = documentEntity.Id,
                    Access = documentEntity.Access,
                    UserName = documentEntity.UserName
                };
            }
            return null;
        }
      
    }
}