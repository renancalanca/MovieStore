namespace MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Action')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Animation')");
        }
        
        public override void Down()
        {
        }
    }
}
