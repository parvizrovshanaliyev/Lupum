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
                ViewData["ErrorMessage"] = "Your Error Message";

                return Json(new
                {
                    status = 404,
                    message = "This Group Exists",

                }, JsonRequestBehavior.AllowGet);
            }

            if (Group.Roles == null || Group.Roles.Count()==0)
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
                status=200
            },JsonRequestBehavior.AllowGet);
        }
    }
}