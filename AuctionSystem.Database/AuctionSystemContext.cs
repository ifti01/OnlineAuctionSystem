using AuctionSystem.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Database
{
    public class AuctionSystemContext: IdentityDbContext<AuctionSystemUser>
    {
        public AuctionSystemContext()
            : base("AuctionSystemContext")
        {
        }

        public DbSet<Auction> Auctions { get; set; } 
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AuctionPicture> AuctionPictures { get; set; }
        public DbSet<Category> Categories  { get; set; }

        public static AuctionSystemContext Create()
        {
            return new AuctionSystemContext();
        }

        //public System.Data.Entity.DbSet<AuctionSystem.Entities.Auction> Auctions { get; set; }
    }
}
