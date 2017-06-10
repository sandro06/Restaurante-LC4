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
    public class OrdenComprasController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();

        // GET: OrdenCompras
        public ActionResult Index()
        {
            var ordenesCompra = db.OrdenesCompra.Include(o => o.Sucursal);
            return View(ordenesCompra.ToList());
        }

        // GET: OrdenCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenesCompra.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public ActionResult Create()
        {
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre");
            return View();
        }

        // POST: OrdenCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenCompraId,Insumo,Cantidad,Precio,SucursalId")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.OrdenesCompra.Add(ordenCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre", ordenCompra.SucursalId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenesCompra.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre", ordenCompra.SucursalId);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdenCompraId,Insumo,Cantidad,Precio,SucursalId")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Nombre", ordenCompra.SucursalId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenesCompra.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenCompra ordenCompra = db.OrdenesCompra.Find(id);
            db.OrdenesCompra.Remove(ordenCompra);
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
