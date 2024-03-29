﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_ASP.NET_MVC.Models;

namespace Web_ASP.NET_MVC.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        ShopFashionContext db = new ShopFashionContext();
        // GET: Admin/Orders
        public ActionResult Index(int? page, string search)
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //dem so luong don dat hang
            var count = db.FSOrders.Count();
            ViewBag.message = count;

            ViewBag.CurrentFilter = search;
            var orders = from s in db.FSOrders select s;
            if (!string.IsNullOrEmpty(search))
            {
                orders = orders.Where(s => s.Status.ToString().Contains(search) || s.Paid.ToString().Contains(search));
            }
            orders = orders.OrderBy(c => c.OrderCode);
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetail = db.FSOrders.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            FSOrder order = db.FSOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                FSOrder order = db.FSOrders.SingleOrDefault(x => x.OrderCode == id);
                if (order != null)
                {
                    order.Status = true;
                    order.Paid = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public void ExportContentToExcel()
        {
            var gv = new GridView()
            {
                DataSource = db.FSOrders.OrderBy(x => x.OrderCode).ToList()
            };
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename=OrderListing_{0}.xls", DateTime.Now));
            Response.ContentType = "application/excel";
            var stw = new StringWriter();
            var htmlTw = new HtmlTextWriter(stw);
            gv.RenderControl(htmlTw);
            Response.Write(stw.ToString());
            Response.End();
        }
    }
}