using AuctionSystem.Entities;
using AuctionSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;

namespace AuctionSystem.Web.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            AuctionServices service = new AuctionServices();

            var auctionList = service.GetAllAuction();

            if (Request.IsAjaxRequest())
            {
                return PartialView(auctionList);
            }
            else
            {
                return View(auctionList);
            }
            
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionServices service = new AuctionServices();
            
            service.SaveAuction(auction);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            AuctionServices service = new AuctionServices();

            var auction = service.GetAuctionByID(ID);

            return PartialView(auction);
        }

        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionServices service = new AuctionServices();

            service.UpdateAuction(auction);

            return RedirectToAction("Index");
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