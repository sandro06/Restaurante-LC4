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

namespace Restaurante.MVC.Controllers
{
    public class EncuestasController : Controller
    {
        private RestauranteDbContext db = new RestauranteDbContext();
        private UnityOfWork unityOfWork;

        // GET: Clientes
        public ActionResult Index()
        {
            //return View(clientes.ToList());
            return View(unityOfWork.Encuestas.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Encuesta encuesta = unityOfWork.Encuestas.Get(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            return View(encuesta);
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
        public ActionResult Create([Bind(Include = "ClienteId,ApeMat,ApePat,Dni,Direccion,PedidoId,ReservaId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                //db.Clientes.Add(cliente);
                unityOfWork.Encuestas.Add(encuesta);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encuesta);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Encuesta encuesta = unityOfWork.Encuestas.Get(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }

            return View(encuesta);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,ApeMat,ApePat,Dni,Direccion,PedidoId,ReservaId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cliente).State = EntityState.Modified;
                unityOfWork.StateModified(encuesta);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encuesta);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Encuesta encuesta = unityOfWork.Encuestas.Get(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            return View(encuesta);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Cliente cliente = db.Clientes.Find(id);
            Encuesta encuesta = unityOfWork.Encuestas.Get(id);
            //db.Clientes.Remove(cliente);
            unityOfWork.Encuestas.Delete(encuesta);
            //db.SaveChanges();
            unityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
