using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMen.Models;

namespace TheMen.Controllers
{
    public class CategoryController : Controller
    {
        TheMenDbContext context = new TheMenDbContext();
        // GET: Category
        public ActionResult Index()
        {   
            return View();
        }
        public ActionResult ProductCategory(int id)
        {
            ProductCategoryModel ProductCategoryModelContext = new ProductCategoryModel();
            ProductCategoryModelContext.ListProductCategory = context.Product.Where(n => n.CategoryId == id).ToList();
            ProductCategoryModelContext.ListCategory = context.Category.ToList();
            return View(ProductCategoryModelContext);
        }
    }
}