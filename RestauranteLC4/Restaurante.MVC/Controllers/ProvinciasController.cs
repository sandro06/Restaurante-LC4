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
    public class ProvinciasController : Controller
    {

        public ProvinciasController()
        {
                
        }
        
        // GET: Provincias
        public ActionResult Index()
        {
            var provincias = _UnityOfWork.Provincias.Include(p => p.Departamento);
            return View(provincias.ToList());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(_UnityOfWork.Departamentos, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaId,Nombre,DepartamentoId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Provincias.Add(provincia);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(_UnityOfWork.Departamentos, "DepartamentoId", "Nombre", provincia.DepartamentoId);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(_UnityOfWork.Departamentos, "DepartamentoId", "Nombre", provincia.DepartamentoId);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaId,Nombre,DepartamentoId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(provincia).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(_UnityOfWork.Departamentos, "DepartamentoId", "Nombre", provincia.DepartamentoId);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = _UnityOfWork.Provincias.Find(id);
            _UnityOfWork.Provincias.Remove(provincia);
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

























































































































        //FIN DEL CODIGO } }




























































































































































































































































































































































        private RestauranteDbContext _UnityOfWork = new RestauranteDbContext();
    }
}
