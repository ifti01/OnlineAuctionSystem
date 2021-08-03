using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Entities
{
    public class Auction:BaseEntity
    {
        //Foreign Key
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }

        //NAV property
        public virtual List<AuctionPicture> AuctionPictures { get; set; }
    

    }
}
