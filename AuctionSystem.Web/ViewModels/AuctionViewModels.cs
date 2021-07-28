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
}