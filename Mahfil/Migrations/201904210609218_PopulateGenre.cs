namespace Mahfil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres Values('1','Islami')");
            Sql("Insert Into Genres Values('2','Islali')");
        }
        
        public override void Down()
        {
        }
    }
}
