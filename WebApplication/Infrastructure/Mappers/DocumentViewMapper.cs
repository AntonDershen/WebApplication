using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using BLL.Interface.Entities;
namespace WebApplication.Infrastructure.Mappers
{
    public static class DocumentViewMapper
    {
        public static DocumentViewModel ToDocumentView(this DocumentEntity documentEntity)
        {
            return new DocumentViewModel()
            {
                Id = documentEntity.Id,
               Name = documentEntity.Name,
                DateTime = documentEntity.CreateDate,
                Type = documentEntity.Type,
                Path =documentEntity.DocumentPath,
                Access = documentEntity.Access,
                UserName = documentEntity.UserName
            };
        }
        public static DocumentEntity ToBllDocument(string documentName,int UserId,string Type,string path,bool Access)
        {
            return new DocumentEntity()
            {
                Name = documentName,
                DocumentPath = path,
                UserId  = UserId,
                Type = Type,
                CreateDate = DateTime.Now,
                Access = Access
            };
        }
    }
}