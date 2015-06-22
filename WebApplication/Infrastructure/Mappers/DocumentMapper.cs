using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using BLL.Interface.Entities;
namespace WebApplication.Infrastructure.Mappers
{
    public static class DocumentMapper
    {
        public static DocumentViewModel ToDocumentView(this DocumentEntity documentEntity)
        {
            return new DocumentViewModel()
            {
               Name = documentEntity.Name,
                DateTime = documentEntity.CreateDate,
                Type = documentEntity.Type
            };
        }
        public static DocumentEntity ToBllDocument(string documentName,int UserId,string Type,string path)
        {
            return new DocumentEntity()
            {
                Name = documentName,
                DocumentPath = path,
                UserId  = UserId,
                Type = Type,
                CreateDate = DateTime.Now
            };
        }
    }
}