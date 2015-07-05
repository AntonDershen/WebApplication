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
                Access = documentEntity.Access,
                UserName = documentEntity.UserName
            };
        }
        public static DocumentEntity ToBllDocument(string documentName,int UserId,string Type,bool Access,string userName)
        {
            return new DocumentEntity()
            {
                Name = documentName,
                UserId  = UserId,
                Type = Type,
                CreateDate = DateTime.Now,
                Access = Access,
                UserName = userName
            };
        }
    }
}