using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSystem.Database;
using AuctionSystem.Entities;

namespace AuctionSystem.Services
{
    public class CategoriesService
    {
        public List<Category> GetAllCategories()
        {
            AuctionSystemContext context = new AuctionSystemContext();

            return context.Categories.ToList();
        }
    }
}
