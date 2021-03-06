﻿using Lupum_Yolcu.DAL;
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
            return View();
        }

        [HttpPost]
        public JsonResult Create(Product Product)
        {
            if (Product == null)
            {
                return Json(new
                {
                    status = 402,
                    message = "Product null ",
                }, JsonRequestBehavior.AllowGet);
            }

            if (_context.Products.FirstOrDefault(p => p.Name == Product.Name) != null)
            {
               
                return Json(new
                {
                   
                    status = 404,
                    message = "Bu adla bazada mehsul var",

                }, JsonRequestBehavior.AllowGet);
            }
            _context.Products.Add(Product);
            _context.SaveChanges();
            return Json(new {
                status = 200
            }, JsonRequestBehavior.AllowGet);
        }

            //[HttpPost,ValidateAntiForgeryToken]
            //public ActionResult Create(Product product,string Status)
            //{
            //    product.Status = true;
            //    if (string.IsNullOrEmpty(Status))
            //    {
            //        product.Status = false;
            //    }
            //    if (_context.Products.FirstOrDefault(p => p.Name == product.Name) != null)
            //    {
            //        ModelState.AddModelError("Name", "Bu adla bazada mehsul var");
            //    }
            //    if (ModelState.IsValid)
            //    {
            //        _context.Products.Add(product);
            //        _context.SaveChanges();
            //        //return RedirectToAction("Index");
            //    }
            //    ViewBag.Types = _context.Types.ToList();

            //    return View(product);
            //}
            #endregion
        }
}