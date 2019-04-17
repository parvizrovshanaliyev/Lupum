using Lupum_Yolcu.DAL;
using Lupum_Yolcu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lupum_Yolcu.Controllers
{
    public class ProductsController : Controller
    {
        private readonly LupumContext _context;
        public ProductsController()
        {
            _context = new LupumContext();
        }
        // GET: Products
        public ActionResult Index()
        {
            var Product = _context.Products.Include("OrderItems").OrderByDescending(p=>p.Id).ToList();
            return View(Product);
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.Types = _context.Types.ToList();
            ViewBag.Networks = _context.Networks.ToList();
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Product product,string Status)
        {
            //return Content(product.Colors.Split(',').ToString());
            product.Status = true;
            if (string.IsNullOrEmpty(Status))
            {
                product.Status = false;
            }
            if (_context.Products.FirstOrDefault(p => p.Name == product.Name) != null)
            {
                ModelState.AddModelError("Name", "Bu adla bazada mehsul var");
            }
            if (ModelState.IsValid)
            {

                var colors = product.Colors.Split(',');
                foreach (var item in colors)
                {
                    var pcolor = new ProductColor
                    {
                        ProductId = product.Id,
                        Name = item
                    };

                    _context.ProductColors.Add(pcolor);

                }
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Types = _context.Types.ToList();
            ViewBag.Networks = _context.Networks.ToList();
            return View(product);
        }
        #endregion


        #region Edit
        public ActionResult Edit(int id)
        {
            Product product = _context.Products.Include("ProductNetworkPrices").FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound("product yok ya la");
            }
            ViewBag.Types = _context.Types.ToList();
            ViewBag.Networks = _context.Networks.ToList();
            return View(product);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, string Status,ProductNetworkPrice[] Prices)
        {
          
            product.Status = true;
            if (string.IsNullOrEmpty(Status))
            {
                product.Status = false;
            }
            if (_context.Products.FirstOrDefault(p => p.Name == product.Name && p.Id!=product.Id) != null)
            {
                ModelState.AddModelError("Name", "Bu adla bazada mehsul var");
            }
            if (Prices != null)
            {
                _context.ProductNetworkPrices.RemoveRange(_context.ProductNetworkPrices.Where(pnp => pnp.ProductId == product.Id));
                foreach (var item in Prices)
                {
                    item.ProductId = product.Id;
                    _context.ProductNetworkPrices.Add(item);
                }
                _context.SaveChanges();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    _context.ProductColors.RemoveRange(_context.ProductColors.Where(pnp => pnp.ProductId == product.Id));



                    var colors = product.Colors.Split(',');
                    foreach (var color in colors)
                    {
                        var pcolor = new ProductColor
                        {
                            ProductId = product.Id,
                            Name = color
                        };

                        _context.ProductColors.Add(pcolor);

                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "price bos gelir");
            ViewBag.ErrorMessage = "Email not found or matched";
            ViewBag.Types = _context.Types.ToList();
            ViewBag.Networks = _context.Networks.ToList();
            product.ProductNetworkPrices = _context.ProductNetworkPrices.Where(pi => pi.ProductId == product.Id).ToList();


            return View(product);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id) {
            Product product = _context.Products.Include("OrderItems").FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound("product yok ya la");
            }
            if (product.OrderItems.Count() != 0) return HttpNotFound("This Product have Order Items .You do not delete");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }

}