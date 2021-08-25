using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
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
        public Pager Pager { get; set; }
        public int? CategoryID { get; set; }
        public string searchTerm { get; set; }
        public int? pageNo { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class AuctionDetailsViewModel : PageViewModel
    {
        public Auction Auction { get; set; }
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public string AuctionPictures { get; set; }
        public List<AuctionPicture> AuctionPicturesList { get; set; }
        public Auction Auction { get; set; }
    }
}