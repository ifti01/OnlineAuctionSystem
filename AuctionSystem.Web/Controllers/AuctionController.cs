using AuctionSystem.Entities;
using AuctionSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSystem.Web.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace AuctionSystem.Web.Controllers
{
    public class AuctionController : Controller
    {
        AuctionServices service = new AuctionServices();

        CategoriesService categoriesService = new CategoriesService();
        // GET: Auction
        public ActionResult Index()
        {
            AuctionListingViewModel model = new AuctionListingViewModel();
            
            //model.PageTitle = "Auction Page";
            model.PageDescription = "List of the Auctions";

            return View(model);
            
        }

        public ActionResult Listing()
        {
            AuctionListingViewModel model = new AuctionListingViewModel();

            //model.PageTitle = "Auction Page";
            model.PageDescription = "List of the Auctions";

            model.Auctions = service.GetAllAuction();

            return View(model);

        }

        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();

            model.Categories = categoriesService.GetAllCategories();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            Auction auction = new Auction();

            auction.Title = model.Title;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndTime = model.EndTime;
            auction.CategoryID = model.CategoryID;

            var pictureID = model.AuctionPictures.Split(',').Select(int.Parse);

            //var pictureIds = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            auction.AuctionPictures = new List<AuctionPicture>();
            auction.AuctionPictures.AddRange(pictureID.Select(x => new AuctionPicture() { PictureID = x }).ToList());

            service.SaveAuction(auction);
            return RedirectToAction("Listing");
        }

        public ActionResult Edit(int ID)
        { 
            var auction = service.GetAuctionByID(ID);
            return PartialView(auction);
        }

        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            service.UpdateAuction(auction);
            return RedirectToAction("Listing");
        }

        public ActionResult Delete(int ID)
        { 
            var auction = service.GetAuctionByID(ID);
            return View(auction);
        }

        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            service.DeleteAuction(auction);
            return RedirectToAction("Listing");
        }

        public ActionResult Details(int ID)
        {
            var auction = service.GetAuctionByID(ID);
            return View(auction);
        }
    }
}