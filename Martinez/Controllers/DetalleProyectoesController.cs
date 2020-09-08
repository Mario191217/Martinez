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
    public class DetalleProyectoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: DetalleProyectoes
        public ActionResult Index()
        {
            var detalleProyectos = db.DetalleProyectos.Include(d => d.Articulos);
            return View(detalleProyectos.ToList());
        }

        // GET: DetalleProyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProyecto detalleProyecto = db.DetalleProyectos.Find(id);
            if (detalleProyecto == null)
            {
                return HttpNotFound();
            }
            return View(detalleProyecto);
        }

        // GET: DetalleProyectoes/Create
        public ActionResult Create()
        {
            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "Articulo");
            return View();
        }

        // POST: DetalleProyectoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalle,IdArticulo,Cantidad,PrecioUnitario,Total")] DetalleProyecto detalleProyecto)
        {
            if (ModelState.IsValid)
            {
                db.DetalleProyectos.Add(detalleProyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "Articulo", detalleProyecto.IdArticulo);
            return View(detalleProyecto);
        }

        // GET: DetalleProyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProyecto detalleProyecto = db.DetalleProyectos.Find(id);
            if (detalleProyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "Articulo", detalleProyecto.IdArticulo);
            return View(detalleProyecto);
        }

        // POST: DetalleProyectoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalle,IdArticulo,Cantidad,PrecioUnitario,Total")] DetalleProyecto detalleProyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleProyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "Articulo", detalleProyecto.IdArticulo);
            return View(detalleProyecto);
        }

        // GET: DetalleProyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProyecto detalleProyecto = db.DetalleProyectos.Find(id);
            if (detalleProyecto == null)
            {
                return HttpNotFound();
            }
            return View(detalleProyecto);
        }

        // POST: DetalleProyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleProyecto detalleProyecto = db.DetalleProyectos.Find(id);
            db.DetalleProyectos.Remove(detalleProyecto);
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
