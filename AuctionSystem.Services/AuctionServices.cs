using AuctionSystem.Database;
using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class AuctionServices
    {
        public void SaveAuction(Auction auction)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Auctions.Add(auction);
            context.SaveChanges();

        }

        public Auction GetAuctionByID(int ID)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            return context.Auctions.Find(ID);

        }

        public List<Auction> GetAllAuction()
        {
            AuctionSystemContext context = new AuctionSystemContext();

            return context.Auctions.ToList();

        }
        public void UpdateAuction(Auction auction)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Entry(auction).State = EntityState.Modified;

            context.SaveChanges();

        }

        public void DeleteAuction(Auction auction)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Entry(auction).State = EntityState.Deleted;

            context.SaveChanges();

        }
    }
}
