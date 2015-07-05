using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public bool Access { get; set; }
        public string UserName { get; set; }
    }
}
