using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicApp.Models;

namespace ElectronicApp.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }
    }
}