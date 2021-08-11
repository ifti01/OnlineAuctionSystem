using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionSystem.Entities;

namespace AuctionSystem.Web.ViewModels
{
    public class CategoryViewModel : PageViewModel
    {
        public List<Category> AllCategories { get; set; }
    }

    public class CategoryListingViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Auction> Auctions { get; set; }
    }

    public class CategoryDetailsViewModel : PageViewModel
    {
        public Category Category { get; set; }
    }

    public class CreateCategoryViewModel : PageViewModel
    {
        public  int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Auction> Auctions { get; set; }

    }
}