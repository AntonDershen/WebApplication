using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
        public void Dispose()
        {
            base.Dispose();
        }
    }
}