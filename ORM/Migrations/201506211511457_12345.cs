namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12345 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Authorizations", new[] { "UserId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Authorizations");
        }
    }
}
