using Lupum_Yolcu.DAL;
using Lupum_Yolcu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lupum_Yolcu.Controllers
{
    public class NetworksController : Controller
    {
        private readonly LupumContext _context;
        public NetworksController()
        {
            _context = new LupumContext();
        }
        // GET: Networks
        public ActionResult Index()
        {
            return View(_context.Networks.Include("Markets").ToList());
        }


        #region Create network
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Network network)
        {
            if (ModelState.IsValid)
            {
                _context.Networks.Add(network);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(network);
        }
        #endregion
    }
}