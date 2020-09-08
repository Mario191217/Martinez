using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Martinez.Models;

namespace Martinez.Controllers
{
    public class TrabajoProyectoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: TrabajoProyectoes
        public ActionResult Index()
        {
            var trabajoProyectos = db.TrabajoProyectos.Include(t => t.Proyectos).Include(t => t.Trabajos);
            return View(trabajoProyectos.ToList());
        }

        // GET: TrabajoProyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajoProyecto trabajoProyecto = db.TrabajoProyectos.Find(id);
            if (trabajoProyecto == null)
            {
                return HttpNotFound();
            }
            return View(trabajoProyecto);
        }

        // GET: TrabajoProyectoes/Create
        public ActionResult Create()
        {
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto");
            ViewBag.IdTrabajo = new SelectList(db.Trabajos, "IdTrabajo", "Trabajo");
            return View();
        }

        // POST: TrabajoProyectoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTrabajoProyecto,IdTrabajo,IdProyecto")] TrabajoProyecto trabajoProyecto)
        {
            if (ModelState.IsValid)
            {
                db.TrabajoProyectos.Add(trabajoProyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", trabajoProyecto.IdProyecto);
            ViewBag.IdTrabajo = new SelectList(db.Trabajos, "IdTrabajo", "Trabajo", trabajoProyecto.IdTrabajo);
            return View(trabajoProyecto);
        }

        // GET: TrabajoProyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajoProyecto trabajoProyecto = db.TrabajoProyectos.Find(id);
            if (trabajoProyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", trabajoProyecto.IdProyecto);
            ViewBag.IdTrabajo = new SelectList(db.Trabajos, "IdTrabajo", "Trabajo", trabajoProyecto.IdTrabajo);
            return View(trabajoProyecto);
        }

        // POST: TrabajoProyectoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTrabajoProyecto,IdTrabajo,IdProyecto")] TrabajoProyecto trabajoProyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajoProyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", trabajoProyecto.IdProyecto);
            ViewBag.IdTrabajo = new SelectList(db.Trabajos, "IdTrabajo", "Trabajo", trabajoProyecto.IdTrabajo);
            return View(trabajoProyecto);
        }

        // GET: TrabajoProyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajoProyecto trabajoProyecto = db.TrabajoProyectos.Find(id);
            if (trabajoProyecto == null)
            {
                return HttpNotFound();
            }
            return View(trabajoProyecto);
        }

        // POST: TrabajoProyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrabajoProyecto trabajoProyecto = db.TrabajoProyectos.Find(id);
            db.TrabajoProyectos.Remove(trabajoProyecto);
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
