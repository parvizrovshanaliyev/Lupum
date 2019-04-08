﻿using System;
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
    }
}