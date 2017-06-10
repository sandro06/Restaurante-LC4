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
    public class TipoCorreosController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: TipoCorreos
        public ActionResult Index()
        {
            var tipoCorreos = db.TipoCorreos.Include(t => t.Cliente);
            return View(tipoCorreos.ToList());
        }

        // GET: TipoCorreos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCorreo tipoCorreo = db.TipoCorreos.Find(id);
            if (tipoCorreo == null)
            {
                return HttpNotFound();
            }
            return View(tipoCorreo);
        }

        // GET: TipoCorreos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat");
            return View();
        }

        // POST: TipoCorreos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoCorreoId,Correo,ClienteId")] TipoCorreo tipoCorreo)
        {
            if (ModelState.IsValid)
            {
                db.TipoCorreos.Add(tipoCorreo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat", tipoCorreo.ClienteId);
            return View(tipoCorreo);
        }

        // GET: TipoCorreos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCorreo tipoCorreo = db.TipoCorreos.Find(id);
            if (tipoCorreo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat", tipoCorreo.ClienteId);
            return View(tipoCorreo);
        }

        // POST: TipoCorreos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoCorreoId,Correo,ClienteId")] TipoCorreo tipoCorreo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCorreo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat", tipoCorreo.ClienteId);
            return View(tipoCorreo);
        }

        // GET: TipoCorreos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCorreo tipoCorreo = db.TipoCorreos.Find(id);
            if (tipoCorreo == null)
            {
                return HttpNotFound();
            }
            return View(tipoCorreo);
        }

        // POST: TipoCorreos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCorreo tipoCorreo = db.TipoCorreos.Find(id);
            db.TipoCorreos.Remove(tipoCorreo);
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
