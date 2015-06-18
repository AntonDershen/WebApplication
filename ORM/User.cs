using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Authorization Authorization { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
