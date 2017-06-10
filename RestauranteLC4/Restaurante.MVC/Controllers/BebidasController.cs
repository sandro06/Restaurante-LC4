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
    public class BebidasController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: Bebidas
        public ActionResult Index()
        {
            var bebidas = db.Bebidas.Include(b => b.TipoBebida);
            return View(bebidas.ToList());
        }

        // GET: Bebidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebida bebida = db.Bebidas.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // GET: Bebidas/Create
        public ActionResult Create()
        {
            ViewBag.TipoBebidaId = new SelectList(db.TipoBebidas, "TipoBebidaId", "Nombre");
            return View();
        }

        // POST: Bebidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BebidaId,Nombre,Precio,Imagen,Descripcion,TipoBebidaId")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                db.Bebidas.Add(bebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoBebidaId = new SelectList(db.TipoBebidas, "TipoBebidaId", "Nombre", bebida.TipoBebidaId);
            return View(bebida);
        }

        // GET: Bebidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebida bebida = db.Bebidas.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoBebidaId = new SelectList(db.TipoBebidas, "TipoBebidaId", "Nombre", bebida.TipoBebidaId);
            return View(bebida);
        }

        // POST: Bebidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BebidaId,Nombre,Precio,Imagen,Descripcion,TipoBebidaId")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoBebidaId = new SelectList(db.TipoBebidas, "TipoBebidaId", "Nombre", bebida.TipoBebidaId);
            return View(bebida);
        }

        // GET: Bebidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebida bebida = db.Bebidas.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // POST: Bebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bebida bebida = db.Bebidas.Find(id);
            db.Bebidas.Remove(bebida);
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
