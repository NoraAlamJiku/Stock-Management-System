using System;
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
    public class StockOutsController : Controller
    {
        private StockDbContext db = new StockDbContext();

        // GET: StockOuts
        public ActionResult Index()
        {
            var stockOuts = db.StockOuts.Include(s => s.Company).Include(s => s.Item);
            return View(stockOuts.ToList());
        }

        // GET: StockOuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockOut stockOut = db.StockOuts.Find(id);
            if (stockOut == null)
            {
                return HttpNotFound();
            }
            return View(stockOut);
        }

        // GET: StockOuts/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "CompanyName");
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");
            return View();
        }

        // POST: StockOuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,ItemId,Quentity")] StockOut stockOut)
        {
            if (ModelState.IsValid)
            {
                db.StockOuts.Add(stockOut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "CompanyName", stockOut.CompanyId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", stockOut.ItemId);
            return View(stockOut);
        }

        // GET: StockOuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockOut stockOut = db.StockOuts.Find(id);
            if (stockOut == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "CompanyName", stockOut.CompanyId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", stockOut.ItemId);
            return View(stockOut);
        }

        // POST: StockOuts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,ItemId,Quentity")] StockOut stockOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "CompanyName", stockOut.CompanyId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", stockOut.ItemId);
            return View(stockOut);
        }

        // GET: StockOuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockOut stockOut = db.StockOuts.Find(id);
            if (stockOut == null)
            {
                return HttpNotFound();
            }
            return View(stockOut);
        }

        // POST: StockOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockOut stockOut = db.StockOuts.Find(id);
            db.StockOuts.Remove(stockOut);
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
