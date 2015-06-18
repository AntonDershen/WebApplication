using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int RolesId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
