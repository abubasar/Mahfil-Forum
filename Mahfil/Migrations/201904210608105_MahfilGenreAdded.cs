namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MahfilGenreAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mahfils",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Venue = c.String(nullable: false, maxLength: 55),
                        DateTime = c.DateTime(nullable: false),
                        Genre_Id = c.String(nullable: false, maxLength: 128),
                        Speaker_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Speaker_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Speaker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mahfils", "Speaker_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Mahfils", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Mahfils", new[] { "Speaker_Id" });
            DropIndex("dbo.Mahfils", new[] { "Genre_Id" });
            DropTable("dbo.Mahfils");
            DropTable("dbo.Genres");
        }
    }
}
