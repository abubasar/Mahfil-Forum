namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Attendances", new[] { "CongregrationId" });
            AlterColumn("dbo.Attendances", "CongregrationId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
            CreateIndex("dbo.Attendances", "CongregrationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Attendances", new[] { "CongregrationId" });
            AlterColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "CongregrationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attendances", "CongregrationId");
        }
    }
}
