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
    public class ViajesController : Controller
    {
        private Entities db = new Entities();

        // GET: Viajes
        public ActionResult Index()
        {
            return View(db.Viajes.ToList());
        }

        // GET: Viajes/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viajes.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // GET: Viajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ViajeID,SerialNumber,EmployeeID,RutaID,IsActive")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Viajes.Add(viaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viajes.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ViajeID,SerialNumber,EmployeeID,RutaID,IsActive")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viajes.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Viaje viaje = db.Viajes.Find(id);
            db.Viajes.Remove(viaje);
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
