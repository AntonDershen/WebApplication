using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
   public class DocumentContextEntity
    {
        public int Id { get; set; }
        public int Path { get; set; }
        public byte[] Context { get; set; }
        public int DocumentId { get; set; }
    }
}
