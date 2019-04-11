using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lupum_Yolcu.DAL;
using Lupum_Yolcu.Models;

namespace Lupum_Yolcu.Controllers
{
    public class UsersController : Controller
    {
        private readonly LupumContext _context;
        public UsersController()
        {
            _context = new LupumContext();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(_context.Users.Include("Group").ToList());
        }
    }
}