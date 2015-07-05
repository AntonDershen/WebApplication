using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using Dal.Interface.DTO;
namespace BLL.Mapper
{
    public static class ContextMapper
    {
        public static DalDocumentContext ToDalContext(this DocumentContextEntity contextEntity)
        {
            return new DalDocumentContext()
            {
               Id= contextEntity.Id,
               Path = contextEntity.Path,
               Context = contextEntity.Context,
               DocumentId = contextEntity.DocumentId
            };
        }
        public static DocumentContextEntity ToDalContext(this DalDocumentContext contextDal)
        {
            return new DocumentContextEntity()
            {
                Id = contextDal.Id,
                Path = contextDal.Path,
                Context = contextDal.Context,
                DocumentId = contextDal.DocumentId
            };
        }
    }
}
