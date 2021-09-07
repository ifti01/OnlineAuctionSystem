﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required, MinLength(15), MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required, Range(10, 1000000)]
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }

        //NAV property
        public virtual List<AuctionPicture> AuctionPictures { get; set; }
    

    }
}
