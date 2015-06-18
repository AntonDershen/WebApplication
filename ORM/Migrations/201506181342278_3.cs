namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Documents1", newName: "DocumentDescriptions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DocumentDescriptions", newName: "Documents1");
        }
    }
}
