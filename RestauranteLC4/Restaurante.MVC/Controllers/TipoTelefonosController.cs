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
    public class TipoTelefonosController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: TipoTelefonos
        public ActionResult Index()
        {
            var tipoTelefonos = db.TipoTelefonos.Include(t => t.Cliente);
            return View(tipoTelefonos.ToList());
        }

        // GET: TipoTelefonos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTelefono tipoTelefono = db.TipoTelefonos.Find(id);
            if (tipoTelefono == null)
            {
                return HttpNotFound();
            }
            return View(tipoTelefono);
        }

        // GET: TipoTelefonos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat");
            return View();
        }

        // POST: TipoTelefonos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoTelefonoId,Numero,ClienteId")] TipoTelefono tipoTelefono)
        {
            if (ModelState.IsValid)
            {
                db.TipoTelefonos.Add(tipoTelefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat", tipoTelefono.ClienteId);
            return View(tipoTelefono);
        }

        // GET: TipoTelefonos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTelefono tipoTelefono = db.TipoTelefonos.Find(id);
            if (tipoTelefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat", tipoTelefono.ClienteId);
            return View(tipoTelefono);
        }

        // POST: TipoTelefonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoTelefonoId,Numero,ClienteId")] TipoTelefono tipoTelefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTelefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ApeMat", tipoTelefono.ClienteId);
            return View(tipoTelefono);
        }

        // GET: TipoTelefonos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTelefono tipoTelefono = db.TipoTelefonos.Find(id);
            if (tipoTelefono == null)
            {
                return HttpNotFound();
            }
            return View(tipoTelefono);
        }

        // POST: TipoTelefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTelefono tipoTelefono = db.TipoTelefonos.Find(id);
            db.TipoTelefonos.Remove(tipoTelefono);
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
