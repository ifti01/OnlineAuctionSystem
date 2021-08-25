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
        public ActionResult Index(int? categoryID,string searchTerm,int? pageNo)
        { 
            AuctionListingViewModel model = new AuctionListingViewModel();
            
            model.PageTitle = "Auction Page";
            model.PageDescription = "List of the Auctions";

            model.CategoryID = categoryID;
            model.searchTerm = searchTerm;
            model.pageNo = pageNo;

            model.Categories = categoriesService.GetAllCategories();

            return View(model);
        }
        public ActionResult Listing(int? categoryID, string searchTerm, int? pageNo)
        {
            var pageSize = 5;

            AuctionListingViewModel model = new AuctionListingViewModel();

            model.PageTitle = "Auction Page";
            model.PageDescription = "List of the Auctions";

            model.Auctions = service.SearchAuctions(categoryID,searchTerm,pageNo,pageSize);

            var totalAuctions = service.GetAuctionsCount();

            model.Pager = new Pager(totalAuctions, pageNo, pageSize);

            return PartialView(model);

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

            //check AuctionPictureID Posted back from Form
            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {
                var pictureID = model.AuctionPictures.Split(',').Select(int.Parse);

                //var pictureIds = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                auction.AuctionPictures = new List<AuctionPicture>();
                auction.AuctionPictures.AddRange(pictureID.Select(x => new AuctionPicture() {AuctionID =auction.ID,PictureID = x }).ToList());
            }
            service.SaveAuction(auction);
            return RedirectToAction("Listing");
        }

        public ActionResult Edit(int ID)
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();

            //var auctionservice = service.GetAuctionByID(ID);

            //model.ID = auctionservice.ID;
            //model.Title = auctionservice.Title;
            //model.Description = auctionservice.Description;
            //model.ActualAmount = auctionservice.ActualAmount;
            //model.StartingTime = auctionservice.StartingTime;
            //model.EndTime = auctionservice.EndTime;


            model.Categories = categoriesService.GetAllCategories();
            model.Auction = service.GetAuctionByID(ID);

            //model.AuctionPicturesList = auctionservice.AuctionPictures;

            
            return PartialView(model);

            
        }
        //service means AuctionService
        [HttpPost]
        public ActionResult Edit(CreateAuctionViewModel model)
        {
            //Auction auction = new Auction();

            var auction = service.GetAuctionByID(model.ID);

            //auction.ID = model.ID;

            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndTime = model.EndTime;
            

            //check AuctionPictureID Posted back from Form
            if (!string.IsNullOrEmpty(model.AuctionPictures))
            { 
                //var pictureID = model.AuctionPictures.Split(',').Select(int.Parse);

                var pictureIds = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                auction.AuctionPictures = new List<AuctionPicture>();
                auction.AuctionPictures.AddRange(pictureIds.Select(x => new AuctionPicture() { AuctionID = auction.ID, PictureID = x }).ToList());

            }

            //AuctionID = auction.ID,
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
            AuctionDetailsViewModel model = new AuctionDetailsViewModel();
            model.Auction = service.GetAuctionByID(ID);
            return View(model);
        }
    }
}