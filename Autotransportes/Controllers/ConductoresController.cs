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
    public class ConductoresController : Controller
    {
        private Entities db = new Entities();

        // GET: Conductores
        public ActionResult Index()
        {
            return View(db.Conductores.ToList());
        }

        // GET: Conductores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductore conductore = db.Conductores.Find(id);
            if (conductore == null)
            {
                return HttpNotFound();
            }
            return View(conductore);
        }

        // GET: Conductores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conductores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Nombre,Apellido,Direccion,Telefono,BaseID,IsActive")] Conductore conductore)
        {
            if (ModelState.IsValid)
            {
                db.Conductores.Add(conductore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conductore);
        }

        // GET: Conductores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductore conductore = db.Conductores.Find(id);
            if (conductore == null)
            {
                return HttpNotFound();
            }
            return View(conductore);
        }

        // POST: Conductores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Nombre,Apellido,Direccion,Telefono,BaseID,IsActive")] Conductore conductore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conductore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conductore);
        }

        // GET: Conductores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductore conductore = db.Conductores.Find(id);
            if (conductore == null)
            {
                return HttpNotFound();
            }
            return View(conductore);
        }

        // POST: Conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Conductore conductore = db.Conductores.Find(id);
            db.Conductores.Remove(conductore);
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
