namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Mahfils", newName: "Congregrations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Congregrations", newName: "Mahfils");
        }
    }
}
