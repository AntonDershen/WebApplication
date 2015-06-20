namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234567 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Authorization_Id", "dbo.Authorizations");
            DropIndex("dbo.Users", new[] { "Authorization_Id" });
            DropColumn("dbo.Users", "RoleId");
            DropColumn("dbo.Users", "Authorization_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Authorization_Id", c => c.Int());
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Authorization_Id");
            AddForeignKey("dbo.Users", "Authorization_Id", "dbo.Authorizations", "Id");
        }
    }
}
