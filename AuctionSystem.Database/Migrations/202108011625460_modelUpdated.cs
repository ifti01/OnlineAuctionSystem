namespace AuctionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdated : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AuctionPictures", "AuctionID");
            AddForeignKey("dbo.AuctionPictures", "AuctionID", "dbo.Auctions", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionPictures", "AuctionID", "dbo.Auctions");
            DropIndex("dbo.AuctionPictures", new[] { "AuctionID" });
        }
    }
}
