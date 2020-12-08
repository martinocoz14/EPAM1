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
    public class CamionesController : Controller
    {
        private Entities db = new Entities();

        // GET: Camiones
        public ActionResult Index()
        {
            return View(db.Camiones.ToList());
        }

        // GET: Camiones/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camione camione = db.Camiones.Find(id);
            if (camione == null)
            {
                return HttpNotFound();
            }
            return View(camione);
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNumber,Placa,Modelo,Year,IsActive")] Camione camione)
        {
            if (ModelState.IsValid)
            {
                db.Camiones.Add(camione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camione);
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camione camione = db.Camiones.Find(id);
            if (camione == null)
            {
                return HttpNotFound();
            }
            return View(camione);
        }

        // POST: Camiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNumber,Placa,Modelo,Year,IsActive")] Camione camione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camione);
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camione camione = db.Camiones.Find(id);
            if (camione == null)
            {
                return HttpNotFound();
            }
            return View(camione);
        }

        // POST: Camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Camione camione = db.Camiones.Find(id);
            db.Camiones.Remove(camione);
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
