using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Database
{
    public class AuctionSystemContext:DbContext
    { 
        public DbSet<Auction> Auctions { get; set; } 
        public DbSet<Picture> Pictures { get; set; }

        public DbSet<AuctionPicture> AuctionPictures { get; set; }
    }
}
