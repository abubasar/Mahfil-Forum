namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primaryAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Congregrations", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Congregrations", name: "Speaker_Id", newName: "SpeakerId");
            RenameIndex(table: "dbo.Congregrations", name: "IX_Speaker_Id", newName: "IX_SpeakerId");
            RenameIndex(table: "dbo.Congregrations", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Congregrations", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Congregrations", name: "IX_SpeakerId", newName: "IX_Speaker_Id");
            RenameColumn(table: "dbo.Congregrations", name: "SpeakerId", newName: "Speaker_Id");
            RenameColumn(table: "dbo.Congregrations", name: "GenreId", newName: "Genre_Id");
        }
    }
}
