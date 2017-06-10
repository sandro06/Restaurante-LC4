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
    public class DistritosController : Controller
    {
        public DistritosController()
        {

        }

        // GET: Distritos
        public ActionResult Index()
        {
            var distritos = _UnityOfWork.Distritos.Include(d => d.Provincia);
            return View(distritos.ToList());
        }

        // GET: Distritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distritos.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritos/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaId = new SelectList(_UnityOfWork.Provincias, "ProvinciaId", "Nombre");
            return View();
        }

        // POST: Distritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,Nombre,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Distritos.Add(distrito);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaId = new SelectList(_UnityOfWork.Provincias, "ProvinciaId", "Nombre", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distritos.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(_UnityOfWork.Provincias, "ProvinciaId", "Nombre", distrito.ProvinciaId);
            return View(distrito);
        }

        // POST: Distritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,Nombre,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(distrito).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(_UnityOfWork.Provincias, "ProvinciaId", "Nombre", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distritos.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = _UnityOfWork.Distritos.Find(id);
            _UnityOfWork.Distritos.Remove(distrito);
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






























































































































































































































        //Que paso papu?
    }
}
