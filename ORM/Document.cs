using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string DocumentPath { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
    }
}
