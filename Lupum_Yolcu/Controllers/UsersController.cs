﻿using System;
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

        ///create user
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
            return RedirectToAction("Index");
        }
        #endregion
        ///user confirm email register
        #region Confirm User
        public ActionResult Confirm(string token)
        {
            User user = _context.Users.FirstOrDefault(u => u.Token == token);
            if (user == null) return HttpNotFound("Bele Bir User qokku");


            return View(model:user.Token);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Confirm(User user)
        {
            User userDb = _context.Users.FirstOrDefault(u => u.Token == user.Token);
            if (user == null) return HttpNotFound("Bele Bir User qokku");
            if (userDb == null) return HttpNotFound("Yoxdu lan");
            userDb.Password = Crypto.HashPassword(user.Password);
            userDb.Fullname = user.Fullname;
            userDb.Token = null;
            userDb.Status = true;
            _context.SaveChanges();

            Session["Login"] = true;
            Session["User"] = userDb;
            return RedirectToAction("Index", "Dashboard");
        }
        #endregion
        ///send confirm email 
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
        ///delete user
        #region Delete User
        public ActionResult Delete(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null) return HttpNotFound("yoxdu lan");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        ///Edit User
        #region Edit User
        public ActionResult Edit(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null) return HttpNotFound("yoxdu lan");
            ViewBag.Groups = _context.Groups.ToList();
            return View(user);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string Status, int GroupId)
        {

            User user = _context.Users.Find(id);

            if (user == null) return HttpNotFound("yoxdu lan");

            if (string.IsNullOrEmpty(Status))
            {
                user.Status = false;
            }
            else
            {
                user.Status = true;
            }
            user.GroupId = GroupId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

    }
}