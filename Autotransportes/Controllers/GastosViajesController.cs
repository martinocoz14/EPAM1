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
    public class GastosViajesController : Controller
    {
        private Entities db = new Entities();

        // GET: GastosViajes
        public ActionResult Index()
        {
            return View(db.GastosViajes.ToList());
        }

        // GET: GastosViajes/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GastosViaje gastosViaje = db.GastosViajes.Find(id);
            if (gastosViaje == null)
            {
                return HttpNotFound();
            }
            return View(gastosViaje);
        }

        // GET: GastosViajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GastosViajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ViajeID,NumeroFactura,MontoFactura,IsActive")] GastosViaje gastosViaje)
        {
            if (ModelState.IsValid)
            {
                db.GastosViajes.Add(gastosViaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gastosViaje);
        }

        // GET: GastosViajes/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GastosViaje gastosViaje = db.GastosViajes.Find(id);
            if (gastosViaje == null)
            {
                return HttpNotFound();
            }
            return View(gastosViaje);
        }

        // POST: GastosViajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ViajeID,NumeroFactura,MontoFactura,IsActive")] GastosViaje gastosViaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gastosViaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gastosViaje);
        }

        // GET: GastosViajes/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GastosViaje gastosViaje = db.GastosViajes.Find(id);
            if (gastosViaje == null)
            {
                return HttpNotFound();
            }
            return View(gastosViaje);
        }

        // POST: GastosViajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            GastosViaje gastosViaje = db.GastosViajes.Find(id);
            db.GastosViajes.Remove(gastosViaje);
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
