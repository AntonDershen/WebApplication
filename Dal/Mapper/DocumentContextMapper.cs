using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface.DTO;
using ORM;
namespace Dal.Mapper
{
    public static class DocumentContextMapper
    {
        public static DalDocumentContext ToDalContext(this DocumentContext context)
        {
            if (context != null)
            {
                return new DalDocumentContext()
                {
                    Id = context.Id,
                    Path = context.Path,
                    Context = context.Context,
                    DocumentId = context.DocumentId
                };
            }
            return null;

        }
        public static DocumentContext ToContext(this DalDocumentContext context)
        {

            if (context != null)
            {
                return new DocumentContext()
                {
                    Id = context.Id,
                    Path = context.Path,
                    Context = context.Context,
                    DocumentId = context.DocumentId
                };
            }
            return null;
        }
    }
}
