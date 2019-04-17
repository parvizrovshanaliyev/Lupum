using Lupum_Yolcu.DAL;
using Lupum_Yolcu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lupum_Yolcu.Controllers
{
    public class OrdersController : Controller
    {
        private readonly LupumContext _context;
        public OrdersController()
        {
            _context = new LupumContext();
        }
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectMarket()
        {
            var markets = _context.Markets.Include("Network").Where(m => m.Status).ToList();
            return View(markets);
        }

        public ActionResult Create(int id)
        {
            Market market = _context.Markets.Find(id);
            if (market == null) return HttpNotFound("Bu magazaya sifaris verile bilmez");
            var products = _context.Products.Include("Type").Include("ProductNetworkPrices").Where(p => p.Status).ToList();
            return View(products);
        }
    }
} 
