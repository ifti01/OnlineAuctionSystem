namespace AuctionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionPictures1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "URL");
        }
    }
}
