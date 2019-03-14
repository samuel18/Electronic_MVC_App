using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicApp.Models;

namespace ElectronicApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search = "", string SortColumn="ProductName", string IconClass="fa-sort-desc", int PageNo = 1)
        {
            ViewBag.Search = search;
            ElectronicDBEntities db = new ElectronicDBEntities();
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }

            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }

            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }

            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }

            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }

            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();

                }

            }
            //Paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            Product product = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(product);

        }

        public ActionResult Create()
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            return View();

        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                product.Photo = base64String;

            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index","Products");

        }

        public ActionResult Edit(long id)
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();

            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product newProduct)
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == newProduct.ProductID).FirstOrDefault();
            existingProduct.ProductName = newProduct.ProductName;
            existingProduct.Price = newProduct.Price;
            existingProduct.DateOfPurchase = newProduct.DateOfPurchase;
            existingProduct.AvailabilityStatus = newProduct.AvailabilityStatus;
            existingProduct.CategoryID = newProduct.CategoryID;
            existingProduct.BrandID = newProduct.BrandID;
            existingProduct.Active = newProduct.Active;
            db.SaveChanges();

            return RedirectToAction("Index","Products");
        }

        public ActionResult Delete(long id)
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(long id, string x)
        {
            ElectronicDBEntities db = new ElectronicDBEntities();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }




    }
}