namespace ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Constants;
    internal sealed class Configuration : DbMigrationsConfiguration<ORM.EntityModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ORM.EntityModel context)
        {
            context.Role.Add(new Role() {  Description = Constants.User });
            context.Role.Add(new Role() {  Description = Constants.Admin });
            context.SaveChanges();
            context.Users.Add(new User(){Id = 1 ,RoleId = 2, UserName = Constants.AdminName});
            context.SaveChanges();
            context.Authorization.Add(new Authorization() { UserId = 1, Email = Constants.AdminEmail, Password = Constants.AdminPassword });
            context.SaveChanges();
        }
    }
}
