namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _666 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
            DropIndex("dbo.Authorizations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Authorizations");
        }
    }
}
