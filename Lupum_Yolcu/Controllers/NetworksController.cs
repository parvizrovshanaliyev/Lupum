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

        #region Edit network
        public ActionResult Edit(int id)
        {
            Network network = _context.Networks.Find(id);

            if (network == null) return HttpNotFound("network qokku");    

            return View(network);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Network network)
        {
            if(_context.Networks.FirstOrDefault(n=>n.Name==network.Name && n.Id != network.Id) != null)
            {
                ModelState.AddModelError("Name", "Bu adla Network Bazada Movcuddur, ferqli ad daxil edin");
            }
            if (ModelState.IsValid)
            {
                _context.Entry(network).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(network);
        }
        #endregion
    }
}