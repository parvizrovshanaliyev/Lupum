using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
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


        #region Create User
        public ActionResult Create()
        {
            var Group= _context.Groups.ToList();
            return View(Group);
        }

       
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (_context.Users.FirstOrDefault(u => u.Email == user.Email) != null)
            {

                return RedirectToAction("create");
            }
            user.Status = false;
            user.Token = Crypto.Hash(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            _context.Users.Add(user);
            _context.SaveChanges();
            SendConfirm(user.Email,user.Token);
            return Content("");
        }
        #endregion

        #region Confirm User
        public ActionResult Confirm(string token)
        {
            User user = _context.Users.FirstOrDefault(u => u.Token == token);
            if (user == null) return HttpNotFound("Bele Bir User qokku");


            return View();
        }

        #endregion
        #region Send Confirm Email User

        private void SendConfirm(string email, string token)
        {

            var body = "<p>Invite to Lupum.az</p><p>Message:</p><p><a href='{0}'>Activate Lupum.az Profile</a></p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("resetlifewithcode@gmail.com");  // replace with valid value
            message.Subject = " Invite to Lupum.az ";
            message.Body = string.Format(body, "http://localhost:55989/Users/confirm?token=" + token);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "resetlifewithcode@gmail.com",  // replace with valid value
                    Password = "varint=str321123"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

        }
        #endregion


    }
}