using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            return context.Categories.Include(c => c.Auctions).ToList();
            //return context.Categories.ToList();
        }

        public void SaveCategory(Category category)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Categories.Add(category);
            context.SaveChanges();

        }

        public Category GetCategoryByID(int ID)
        {

            AuctionSystemContext context = new AuctionSystemContext();

            return context.Categories.Include(x => x.Auctions).Where(x => x.ID == ID).First();

        }

        public void UpdateCategory(Category category)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Entry(category).State = EntityState.Modified;

            context.SaveChanges();

        }

        public void DeleteCategory(Category category)
        {
            AuctionSystemContext context = new AuctionSystemContext();

            context.Entry(category).State = EntityState.Deleted;

            context.SaveChanges();
        }
    }
}
