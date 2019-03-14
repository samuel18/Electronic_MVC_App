using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicApp.Models;

namespace ElectronicApp.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}