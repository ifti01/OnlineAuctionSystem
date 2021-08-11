using AuctionSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSystem.Entities;
using AuctionSystem.Web.ViewModels;

namespace AuctionSystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();
        // GET: Auction
        public ActionResult Index()
        {
            CategoryListingViewModel model = new CategoryListingViewModel();

            model.PageTitle = "Category Page";
            model.PageDescription = "List of the Categories";

            return View(model);

        }

        public ActionResult Listing()
        {
            CategoryListingViewModel model = new CategoryListingViewModel();

            model.Categories = categoriesService.GetAllCategories();

            return View(model);

        }

        public ActionResult Create()
        {
            //CreateCategoryViewModel model = new CreateCategoryViewModel();

            //model.categories = categoriesservice.getallcategories();
            
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            Category category = new Category();

            category.Name = model.Name;
            category.Description = model.Description;
            
            categoriesService.SaveCategory(category);
            return RedirectToAction("Listing");
        }

        public ActionResult Edit(int ID)
        {
            CreateCategoryViewModel model = new CreateCategoryViewModel();

            model.Category = categoriesService.GetCategoryByID(ID);
            
            return PartialView(model);


        }
        //service means AuctionService
        [HttpPost]
        public ActionResult Edit(CreateCategoryViewModel model)
        {
            var category = categoriesService.GetCategoryByID(model.ID);

            category.Name = model.Name;
            category.Description = model.Description;

            categoriesService.UpdateCategory(category);
            return RedirectToAction("Listing");

        }


        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoriesService.DeleteCategory(category);
            return RedirectToAction("Listing");
        }

        public ActionResult Details(int ID)
        {
            CategoryDetailsViewModel model = new CategoryDetailsViewModel();
          
            model.Category = categoriesService.GetCategoryByID(ID);

            model.PageTitle = model.Category.Name;
            model.PageDescription = model.Category.Description;

            return View(model);
        }
    }
}
