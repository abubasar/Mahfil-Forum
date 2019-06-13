namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCanceledPropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Congregrations", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Congregrations", "IsCancelled");
        }
    }
}
