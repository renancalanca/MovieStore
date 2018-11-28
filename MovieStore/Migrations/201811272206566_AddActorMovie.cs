namespace MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActorMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Actor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Actor");
        }
    }
}
