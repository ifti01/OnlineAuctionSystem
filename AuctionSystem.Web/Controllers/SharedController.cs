using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSystem.Entities;
using AuctionSystem.Services;

namespace AuctionSystem.Web.Controllers
{
    public class SharedController : Controller
    {
        SharedService service = new SharedService();

        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();
            List<object> picturesJSON = new List<object>();

            var pictures = Request.Files;

            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);

                //create picName, and path(url)
                var path = Server.MapPath("~/Content/images/") + fileName;

                //var picUrl = "~/Content/images/" + fileName;

                // upload pic into images file
                picture.SaveAs(path);

                var dbPicture = new Picture(); //OBject of Picture Entity
                dbPicture.URL = fileName;

                int pictureID = service.SavePicture(dbPicture);

                picturesJSON.Add(new {ID = pictureID,URL = fileName});
            }
            //pictureURL = path
            result.Data = picturesJSON;

            return result ;
        }
    }
}