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
using Restaurante.Persistence.Repositories;
using Restaurante.Entities.IRepositories;

namespace Restaurante.MVC.Controllers
{
    public class TipoBebidasController : Controller
    {

        private readonly IUnityOfWork _UnityOfWork;

        public TipoBebidasController()
        {
                
        }

        public TipoBebidasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            //return View(clientes.ToList());
            return View(_UnityOfWork.TipoBebidas.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            TipoBebida tipoBebida = _UnityOfWork.TipoBebidas.Get(id);
            if (tipoBebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoBebida);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,ApeMat,ApePat,Dni,Direccion,PedidoId,ReservaId")] TipoBebida tipoBebida)
        {
            if (ModelState.IsValid)
            {
                //db.Clientes.Add(cliente);
                _UnityOfWork.TipoBebidas.Add(tipoBebida);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoBebida);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            TipoBebida tipoBebida = _UnityOfWork.TipoBebidas.Get(id);
            if (tipoBebida == null)
            {
                return HttpNotFound();
            }

            return View(tipoBebida);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,ApeMat,ApePat,Dni,Direccion,PedidoId,ReservaId")] TipoBebida tipoBebida)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cliente).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoBebida);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoBebida);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            TipoBebida tipoBebida = _UnityOfWork.TipoBebidas.Get(id);
            if (tipoBebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoBebida);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Cliente cliente = db.Clientes.Find(id);
            TipoBebida tipoBebida = _UnityOfWork.TipoBebidas.Get(id);
            //db.Clientes.Remove(cliente);
            _UnityOfWork.TipoBebidas.Delete(tipoBebida);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

