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
using Restaurante.Entities.IRepositories;

namespace Restaurante.MVC.Controllers
{
    public class BebidasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public BebidasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Ventas
        public ActionResult Index()
        {
            return View(_UnityOfWork.Bebidas.GetAll());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Venta venta = db.Ventas.Find(id);
            Bebida bebida = _UnityOfWork.Bebidas.Get(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,TipoPago,DetalleVenta,PedidoId")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                //db.Ventas.Add(venta);
                _UnityOfWork.Bebidas.Add(bebida);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bebida);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Venta venta = db.Ventas.Find(id);
            Bebida bebida = _UnityOfWork.Bebidas.Get(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }

            return View(bebida);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,TipoPago,DetalleVenta,PedidoId")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(venta).State = EntityState.Modified;
                _UnityOfWork.StateModified(bebida);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bebida);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Venta venta = db.Ventas.Find(id);
            Bebida bebida = _UnityOfWork.Bebidas.Get(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Venta venta = db.Ventas.Find(id);
            Bebida bebida = _UnityOfWork.Bebidas.Get(id);
            _UnityOfWork.Bebidas.Delete(bebida);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}