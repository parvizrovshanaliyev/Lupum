using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lupum_Yolcu.DAL;
using Lupum_Yolcu.Models;

namespace Lupum_Yolcu.Controllers
{
    public class GroupsController : Controller
    {
        private readonly LupumContext _context;
        public GroupsController()
        {
            _context = new LupumContext();
        }
        // GET: Groups
        public ActionResult Index()
        {
            var Groups = _context.Groups.Include("Users").ToList();
            return View(Groups);
        }


        ///create group
        ///
        #region create

        public ActionResult Create()
        {
            var Actions = _context.Actions.ToList();
            return View(Actions);
        }

        [HttpPost]
        public JsonResult Create(Models.Group Group)
        {
            if (Group == null)
            {
                return Json(new
                {
                    status = 402
                }, JsonRequestBehavior.AllowGet);
            }

            if (_context.Groups.FirstOrDefault(g => g.Name == Group.Name) != null)
            {

                return Json(new
                {
                    status = 404,
                    message = "This Group Exists",

                }, JsonRequestBehavior.AllowGet);
            }

            if (Group.Roles == null || Group.Roles.Count() == 0)
            {
                return Json(

                    new
                    {
                        status = 405,
                        message = "You must choose a permission!!!"
                    }, JsonRequestBehavior.AllowGet);
            }
            _context.Groups.Add(Group);
            _context.SaveChanges();
            return Json(new
            {
                status = 200
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        

        
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return HttpNotFound("Id gelmir");
            //}

            Models.Group grp = _context.Groups.Find(id);
            if (grp == null)
            {
                return HttpNotFound("bele bir group yoxdur");
            }

            if (_context.Users.Where(u=>u.GroupId == grp.Id).Count() != 0)
            {
                return HttpNotFound("bu groupa aid userler olduguna gore bu group siline bilmez");
            }

            _context.Groups.Remove(grp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Edit(int id)
        {
            Models.Group grp = _context.Groups.Include("Roles").FirstOrDefault(g=>g.Id==id);
            if (grp == null)
            {
                return HttpNotFound("bele bir group yoxdur");
            }
            ViewBag.Actions= _context.Actions.ToList();

            return View(grp);
        }


        [HttpPost]
        public JsonResult Edit(Models.Group Group,Models.Role[] Roles)
        {

            if (_context.Groups.FirstOrDefault(g => g.Name == Group.Name && g.Id!=Group.Id) != null)
            {

                return Json(new
                {
                    status = 404,
                    message = "This Group Exists",

                }, JsonRequestBehavior.AllowGet);
            }

            if (Roles == null ||Roles.Length == 0)
            {
                return Json(

                    new
                    {
                        status = 405,
                        message = "You must choose a permission!!!"
                    }, JsonRequestBehavior.AllowGet);
            }
            _context.Entry(Group).State = System.Data.Entity.EntityState.Modified;
           

            _context.Roles.RemoveRange(_context.Roles.Where(r => r.GroupId == Group.Id));
            _context.Roles.AddRange(Roles);
            _context.SaveChanges();
            
            return Json(
                new{status =200},JsonRequestBehavior.AllowGet);
        }
    }
}