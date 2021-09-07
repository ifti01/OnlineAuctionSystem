using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int CategoryID { get; set; }

        [Required, MinLength(15), MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Range(10, 1000000)]
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }
        

        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public string AuctionPictures { get; set; }
        public List<AuctionPicture> AuctionPicturesList { get; set; }
        public Auction Auction { get; set; }
    }
}