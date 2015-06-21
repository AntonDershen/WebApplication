namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7777 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            AddForeignKey("dbo.Authorizations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Authorizations", "UserId", "dbo.Users", "Id");
        }
    }
}
