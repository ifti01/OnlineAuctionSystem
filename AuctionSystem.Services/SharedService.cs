using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSystem.Database;
using AuctionSystem.Entities;

namespace AuctionSystem.Services
{
    public class SharedService
    {
        public int SavePicture(Picture picture)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Pictures.Add(picture);
            context.SaveChanges();

            return picture.ID;
        }
    }
}
