using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurante.Entities;
using Restaurante.Persistence;

namespace Restaurante.MVC.Controllers
{
    public class MeserosController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: Meseros
        public ActionResult Index()
        {
            return View(db.Meseros.ToList());
        }

        // GET: Meseros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesero mesero = db.Meseros.Find(id);
            if (mesero == null)
            {
                return HttpNotFound();
            }
            return View(mesero);
        }

        // GET: Meseros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meseros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeseroId,Nombre,CarnetSanidad,Sueldo,Fecha")] Mesero mesero)
        {
            if (ModelState.IsValid)
            {
                db.Meseros.Add(mesero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesero);
        }

        // GET: Meseros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesero mesero = db.Meseros.Find(id);
            if (mesero == null)
            {
                return HttpNotFound();
            }
            return View(mesero);
        }

        // POST: Meseros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeseroId,Nombre,CarnetSanidad,Sueldo,Fecha")] Mesero mesero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesero);
        }

        // GET: Meseros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesero mesero = db.Meseros.Find(id);
            if (mesero == null)
            {
                return HttpNotFound();
            }
            return View(mesero);
        }

        // POST: Meseros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesero mesero = db.Meseros.Find(id);
            db.Meseros.Remove(mesero);
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
