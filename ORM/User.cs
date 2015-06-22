using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class User
    {
        public User()
        {
            Authorizations = new HashSet<Authorization>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
