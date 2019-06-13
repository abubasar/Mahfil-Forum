namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.String(nullable: false, maxLength: 128),
                        CongregrationId = c.String(maxLength: 128),
                        AttendeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId)
                .ForeignKey("dbo.Congregrations", t => t.CongregrationId)
                .Index(t => t.CongregrationId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "CongregrationId", "dbo.Congregrations");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "CongregrationId" });
            DropTable("dbo.Attendances");
        }
    }
}
