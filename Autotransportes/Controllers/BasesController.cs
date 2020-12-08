using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autotransportes.Models;

namespace Autotransportes.Controllers
{
    public class BasesController : Controller
    {
        private Entities db = new Entities();

        // GET: Bases
        public ActionResult Index()
        {
            return View(db.Bases.ToList());
        }

        // GET: Bases/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basis basis = db.Bases.Find(id);
            if (basis == null)
            {
                return HttpNotFound();
            }
            return View(basis);
        }

        // GET: Bases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BaseID,Ciudad,Estado,IsActive")] Basis basis)
        {
            if (ModelState.IsValid)
            {
                db.Bases.Add(basis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basis);
        }

        // GET: Bases/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basis basis = db.Bases.Find(id);
            if (basis == null)
            {
                return HttpNotFound();
            }
            return View(basis);
        }

        // POST: Bases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaseID,Ciudad,Estado,IsActive")] Basis basis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basis);
        }

        // GET: Bases/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basis basis = db.Bases.Find(id);
            if (basis == null)
            {
                return HttpNotFound();
            }
            return View(basis);
        }

        // POST: Bases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Basis basis = db.Bases.Find(id);
            db.Bases.Remove(basis);
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
