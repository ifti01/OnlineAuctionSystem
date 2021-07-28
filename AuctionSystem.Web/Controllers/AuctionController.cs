﻿using AuctionSystem.Entities;
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
        AuctionServices service = new AuctionServices();

        // GET: Auction
        public ActionResult Index()
        {
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
            service.SaveAuction(auction);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult Details(int ID)
        {
            var auction = service.GetAuctionByID(ID);
            return View(auction);
        }
    }
}