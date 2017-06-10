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
    public class EncuestasController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: Encuestas
        public ActionResult Index()
        {
            var encuestas = db.Encuestas.Include(e => e.Sucursal);
            return View(encuestas.ToList());
        }

        // GET: Encuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuesta encuesta = db.Encuestas.Find(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            return View(encuesta);
        }

        // GET: Encuestas/Create
        public ActionResult Create()
        {
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre");
            return View();
        }

        // POST: Encuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EncuestaId,Fecha,Resultado,SucursalId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                db.Encuestas.Add(encuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre", encuesta.SucursalId);
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuesta encuesta = db.Encuestas.Find(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre", encuesta.SucursalId);
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EncuestaId,Fecha,Resultado,SucursalId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre", encuesta.SucursalId);
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuesta encuesta = db.Encuestas.Find(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encuesta encuesta = db.Encuestas.Find(id);
            db.Encuestas.Remove(encuesta);
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
