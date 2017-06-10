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
    public class DepartamentosController : Controller
    {
        
        private readonly IUnityOfWork _UnityOfWork;
        public DepartamentosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        public DepartamentosController()
        {
                
        }
        // GET: Clientes
        public ActionResult Index()
        {
            return View(_UnityOfWork.Departamentos.GetAll());
            
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            //Departamento departamento = unityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
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
        public ActionResult Create([Bind(Include = "DepartamentoId,Nombre")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Departamentos.Add(departamento);
                //unityOfWork.Departamentos.Add(departamento);
                _UnityOfWork.SaveChanges();
                //unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }

            return View(departamento);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentoId,Nombre")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(departamento).State = EntityState.Modified;
                _UnityOfWork.StateModified(departamento);
                _UnityOfWork.SaveChanges();
                //unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Cliente cliente = db.Clientes.Find(id);
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            _UnityOfWork.Departamentos.Delete(departamento);
            //unityOfWork.Departamentos.Delete(departamento);
            _UnityOfWork.SaveChanges();
            //unityOfWork.SaveChanges();
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
