using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionSystem.Entities;

namespace AuctionSystem.Web.ViewModels
{
    public class AuctionViewModel:PageViewModel
    { 
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> FeaturedAuctions { get; set; }
    }

    public class AuctionListingViewModel : PageViewModel
    {
        public List<Auction> Auctions { get; set; }
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public string AuctionPictures { get; set; }
        public List<Category> Categories { get; set; }

    }
}