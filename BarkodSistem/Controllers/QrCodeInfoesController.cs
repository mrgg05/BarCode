using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarkodSistem.Models;

namespace BarkodSistem.Controllers
{
    public class QrCodeInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QrCodeInfoes
        public ActionResult Index()
        {
            var qrCodeInfos = db.QrCodeInfos.Include(q => q.Product);
            return View(qrCodeInfos.ToList());
        }

        // GET: QrCodeInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QrCodeInfo qrCodeInfo = db.QrCodeInfos.Find(id);
            if (qrCodeInfo == null)
            {
                return HttpNotFound();
            }
            return View(qrCodeInfo);
        }

        // GET: QrCodeInfoes/Create
        public ActionResult Create()
        {
            ViewBag.ProID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: QrCodeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SKT,TETT,ProductionDate,ProductID")] QrCodeInfo qrCodeInfo)
        {
            if (ModelState.IsValid)
            {
                db.QrCodeInfos.Add(qrCodeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QrCodeInfoID = new SelectList(db.Products, "ProductID", "ProductName", qrCodeInfo.QrCodeInfoID);
            return View(qrCodeInfo);
        }

        // GET: QrCodeInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QrCodeInfo qrCodeInfo = db.QrCodeInfos.Find(id);
            if (qrCodeInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.QrCodeInfoID = new SelectList(db.Products, "ProductID", "ProductName", qrCodeInfo.QrCodeInfoID);
            return View(qrCodeInfo);
        }

        // POST: QrCodeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QrCodeInfoID,SKT,TETT,ProductionDate,ProductID")] QrCodeInfo qrCodeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qrCodeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QrCodeInfoID = new SelectList(db.Products, "ProductID", "ProductName", qrCodeInfo.QrCodeInfoID);
            return View(qrCodeInfo);
        }

        // GET: QrCodeInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QrCodeInfo qrCodeInfo = db.QrCodeInfos.Find(id);
            if (qrCodeInfo == null)
            {
                return HttpNotFound();
            }
            return View(qrCodeInfo);
        }

        // POST: QrCodeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QrCodeInfo qrCodeInfo = db.QrCodeInfos.Find(id);
            db.QrCodeInfos.Remove(qrCodeInfo);
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
