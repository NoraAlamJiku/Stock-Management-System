﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockManagementDb.Models;

namespace StockManagementService.Controllers
{
    public class StockInsController : Controller
    {
        private StockDbContext db = new StockDbContext();

        // GET: StockIns
        public ActionResult Index()
        {
            var stockIns = db.StockIns.Include(s => s.Category).Include(s => s.Item);
            return View(stockIns.ToList());
        }

        // GET: StockIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIn stockIn = db.StockIns.Find(id);
            if (stockIn == null)
            {
                return HttpNotFound();
            }
            return View(stockIn);
        }

        // GET: StockIns/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "CategoryName");
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");
            return View();
        }

        // POST: StockIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,ItemId,StockInQuentity")] StockIn stockIn)
        {
            if (ModelState.IsValid)
            {
                db.StockIns.Add(stockIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "CategoryName", stockIn.CategoryId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", stockIn.ItemId);
            return View(stockIn);
        }

        // GET: StockIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIn stockIn = db.StockIns.Find(id);
            if (stockIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "CategoryName", stockIn.CategoryId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", stockIn.ItemId);
            return View(stockIn);
        }

        // POST: StockIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,ItemId,StockInQuentity")] StockIn stockIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "CategoryName", stockIn.CategoryId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", stockIn.ItemId);
            return View(stockIn);
        }

        // GET: StockIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIn stockIn = db.StockIns.Find(id);
            if (stockIn == null)
            {
                return HttpNotFound();
            }
            return View(stockIn);
        }

        // POST: StockIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockIn stockIn = db.StockIns.Find(id);
            db.StockIns.Remove(stockIn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
