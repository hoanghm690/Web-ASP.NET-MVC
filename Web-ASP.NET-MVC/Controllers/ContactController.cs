﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_ASP.NET_MVC.Models;

namespace Web_ASP.NET_MVC.Controllers
{
    public class ContactController : Controller
    {
        ShopFashionContext db = new ShopFashionContext();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}