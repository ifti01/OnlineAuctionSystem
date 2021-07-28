using AuctionSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSystem.Web.ViewModels;

namespace AuctionSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionServices service = new AuctionServices();

        public ActionResult Index()
        {
            AuctionViewModel model = new AuctionViewModel();

            model.AllAuctions = service.GetAllAuction();
            model.FeaturedAuctions = service.GetFeaturedAuction();

            model.PageTitle = "Home Page";
            model.PageDescription = "This is a home page of the Auction System";
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}