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
    public class TipoBebidasController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: TipoBebidas
        public ActionResult Index()
        {
            return View(db.TipoBebidas.ToList());
        }

        // GET: TipoBebidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBebida tipoBebida = db.TipoBebidas.Find(id);
            if (tipoBebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoBebida);
        }

        // GET: TipoBebidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoBebidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoBebidaId,Nombre")] TipoBebida tipoBebida)
        {
            if (ModelState.IsValid)
            {
                db.TipoBebidas.Add(tipoBebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoBebida);
        }

        // GET: TipoBebidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBebida tipoBebida = db.TipoBebidas.Find(id);
            if (tipoBebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoBebida);
        }

        // POST: TipoBebidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoBebidaId,Nombre")] TipoBebida tipoBebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoBebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoBebida);
        }

        // GET: TipoBebidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBebida tipoBebida = db.TipoBebidas.Find(id);
            if (tipoBebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoBebida);
        }

        // POST: TipoBebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoBebida tipoBebida = db.TipoBebidas.Find(id);
            db.TipoBebidas.Remove(tipoBebida);
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
