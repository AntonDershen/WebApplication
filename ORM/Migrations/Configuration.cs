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
            context.Role.Add(new Role() { Description = Constants.Constant.user });
            context.Role.Add(new Role() {  Description = Constants.Constant.admin });
            context.SaveChanges();
            context.Users.Add(new User() { Id = 1, RoleId = 2, UserName = Constants.Constant.adminName });
            context.SaveChanges();
            context.Authorization.Add(new Authorization() { UserId = 1, Email = Constants.Constant.adminEmail, Password = Constants.Constant.adminPassword });
            context.SaveChanges();
        }
    }
}
