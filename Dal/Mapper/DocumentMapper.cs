﻿using System;
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
                Id = dalDocument.Id,
                Name = dalDocument.Name,
                CreateDate = dalDocument.CreateDate,
                UserId = dalDocument.UserId,
                Type = dalDocument.Type,
                Access = dalDocument.Access
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
                    UserId = document.UserId,
                    Type = document.Type,
                    Access = document.Access,
                    UserName = document.User.UserName
                };
            }
            return null;
        }
    }
}
