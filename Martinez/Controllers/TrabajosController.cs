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
    public class TrabajosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Trabajos
        public ActionResult Index()
        {
            var trabajos = db.Trabajos.Include(t => t.Clientes).Include(t => t.Empleados);
            return View(trabajos.ToList());
        }

        // GET: Trabajos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajos trabajos = db.Trabajos.Find(id);
            if (trabajos == null)
            {
                return HttpNotFound();
            }
            return View(trabajos);
        }

        // GET: Trabajos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente");
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            return View();
        }

        // POST: Trabajos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTrabajo,Trabajo,IdEmpleado,Comision,CostoTotal,MontoTotal,Rentabilidad,Ubicacion,IdCliente,Abono,Saldo,FechaRegistro,FechaFinalizacion,Terminado")] Trabajos trabajos)
        {
            if (ModelState.IsValid)
            {
                db.Trabajos.Add(trabajos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente", trabajos.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", trabajos.IdEmpleado);
            return View(trabajos);
        }

        // GET: Trabajos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajos trabajos = db.Trabajos.Find(id);
            if (trabajos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente", trabajos.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", trabajos.IdEmpleado);
            return View(trabajos);
        }

        // POST: Trabajos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTrabajo,Trabajo,IdEmpleado,Comision,CostoTotal,MontoTotal,Rentabilidad,Ubicacion,IdCliente,Abono,Saldo,FechaRegistro,FechaFinalizacion,Terminado")] Trabajos trabajos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente", trabajos.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", trabajos.IdEmpleado);
            return View(trabajos);
        }

        // GET: Trabajos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajos trabajos = db.Trabajos.Find(id);
            if (trabajos == null)
            {
                return HttpNotFound();
            }
            return View(trabajos);
        }

        // POST: Trabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajos trabajos = db.Trabajos.Find(id);
            db.Trabajos.Remove(trabajos);
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
