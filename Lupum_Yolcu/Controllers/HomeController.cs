using Lupum_Yolcu.Models;
using Lupum_Yolcu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace Lupum_Yolcu.Controllers
{
    public class HomeController : Controller
    {
        private readonly LupumContext _context;
        public HomeController()
        {
            _context = new LupumContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn( User user)
        {
            if(string.IsNullOrEmpty(user.Email)|| string.IsNullOrEmpty(user.Password))
            {

                Session["LoginError"] = "email or password not empty";
                return RedirectToAction("Index");

            }

            User lgn = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (lgn != null)
            {
                if (Crypto.VerifyHashedPassword(lgn.Password, user.Password))
                {
                    Session["Login"] = true;
                    Session["User"] = lgn;
                    return RedirectToAction("Index","Dashboard");

                }
            }

            Session["LoginError"] = "email or password wrong";
            return RedirectToAction("Index");
        }

        ///create admin
        ///

        public ActionResult CreateAdmin()
        {
            User user = new User
            {
                
                Email = "parviz@code.edu.az",
                Password = Crypto.HashPassword("123Abc"),
                GroupId=1,
                Fullname="ParvizRA",
                Status=true
            };


            _context.Users.Add(user);
            _context.SaveChanges();
            return Content(user.Password.ToString());
        }


    }
}