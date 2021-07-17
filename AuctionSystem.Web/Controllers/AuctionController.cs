using AuctionSystem.Entities;
using AuctionSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionSystem.Web.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            AuctionServices service = new AuctionServices();

            var auctionList = service.GetAllAuction();

            return View(auctionList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionServices service = new AuctionServices();
            
            service.SaveAuction(auction);

            return View();
        }

        public ActionResult Edit(int ID)
        {
            AuctionServices service = new AuctionServices();

            var auction = service.GetAuctionByID(ID);

            return View(auction);
        }

        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionServices service = new AuctionServices();

            service.UpdateAuction(auction);

            return View(auction);
        }

        public ActionResult Delete(int ID)
        {
            AuctionServices service = new AuctionServices();

            var auction = service.GetAuctionByID(ID);

            return View(auction);
        }

        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            AuctionServices service = new AuctionServices();

            service.DeleteAuction(auction);

            return RedirectToAction("Index");
        }

    }
}