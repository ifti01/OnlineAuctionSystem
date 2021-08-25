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

            return context.Auctions.Include(x=>x.AuctionPictures).Include("AuctionPictures.Picture").Where(x => x.ID == ID).First();

        }

        public List<Auction> GetAllAuction()
        { 
            AuctionSystemContext context = new AuctionSystemContext();
            return context.Auctions.ToList();
        }

        //get auctions by filtering them using search, category, and page no
        public List<Auction> SearchAuctions(int? categoryID, string searchTerm, int? pageNo,int pageSize)
        {

            AuctionSystemContext context = new AuctionSystemContext();

            var auctions = context.Auctions.AsQueryable();
            if (categoryID.HasValue && categoryID.Value>0)
            {
                auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            int skipCount = pageSize * (pageNo.Value - 1);

            return auctions.OrderByDescending(a => a.ID).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetAuctionsCount()
        {
            AuctionSystemContext context = new AuctionSystemContext();

            return context.Auctions.Count();
        }

        public List<Auction> GetFeaturedAuction()
        {
            AuctionSystemContext context = new AuctionSystemContext();
            return context.Auctions.Take(4).ToList();

        }

        public void UpdateAuction(Auction auction)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            var existingAuction = context.Auctions.Where(x => x.ID == auction.ID).Include(x => x.AuctionPictures).First();
            
            context.AuctionPictures.RemoveRange(existingAuction.AuctionPictures);

            context.Entry(existingAuction).CurrentValues.SetValues(auction);

            context.AuctionPictures.AddRange(auction.AuctionPictures);

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
