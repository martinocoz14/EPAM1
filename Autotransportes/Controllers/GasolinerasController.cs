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
    public class GasolinerasController : Controller
    {
        private Entities db = new Entities();

        // GET: Gasolineras
        public ActionResult Index()
        {
            return View(db.Gasolineras.ToList());
        }

        // GET: Gasolineras/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            if (gasolinera == null)
            {
                return HttpNotFound();
            }
            return View(gasolinera);
        }

        // GET: Gasolineras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gasolineras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GasolineraID,RazonSocial,Ubicacion,IsActive")] Gasolinera gasolinera)
        {
            if (ModelState.IsValid)
            {
                db.Gasolineras.Add(gasolinera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasolinera);
        }

        // GET: Gasolineras/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            if (gasolinera == null)
            {
                return HttpNotFound();
            }
            return View(gasolinera);
        }

        // POST: Gasolineras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GasolineraID,RazonSocial,Ubicacion,IsActive")] Gasolinera gasolinera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasolinera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasolinera);
        }

        // GET: Gasolineras/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            if (gasolinera == null)
            {
                return HttpNotFound();
            }
            return View(gasolinera);
        }

        // POST: Gasolineras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            db.Gasolineras.Remove(gasolinera);
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
