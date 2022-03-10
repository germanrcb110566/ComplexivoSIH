﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Models;

namespace ComplexivoSIH.Controllers
{
    public class mTratamientoesController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: mTratamientoes
        public async Task<ActionResult> Index()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            var mTratamiento = db.mTratamiento.Include(m => m.Catalogo).Where(x => x.Catalogo.catalogo_id == 10).Include(m => m.mCita);

            //var mTratamiento = db.mTratamiento.Include(m => m.Catalogo).Include(m => m.mCita);
            return View(await mTratamiento.ToListAsync());
        }

        // GET: mTratamientoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mTratamiento mTratamiento = await db.mTratamiento.FindAsync(id);
            if (mTratamiento == null)
            {
                return HttpNotFound();
            }
            return View(mTratamiento);
        }

        // GET: mTratamientoes/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            ViewBag.catalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre");
            ViewBag.cita_id = new SelectList(db.mCita, "cita_id", "motivo");
            return View();
        }

        // POST: mTratamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tratamiento_id,cita_id,catalogo_id,cantidad,prescripcion")] mTratamiento mTratamiento)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.mTratamiento.Add(mTratamiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.catalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mTratamiento.catalogo_id);
            ViewBag.cita_id = new SelectList(db.mCita, "cita_id", "motivo", mTratamiento.cita_id);
            return View(mTratamiento);
        }

        // GET: mTratamientoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mTratamiento mTratamiento = await db.mTratamiento.FindAsync(id);
            if (mTratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.catalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mTratamiento.catalogo_id);
            ViewBag.cita_id = new SelectList(db.mCita, "cita_id", "motivo", mTratamiento.cita_id);
            return View(mTratamiento);
        }

        // POST: mTratamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tratamiento_id,cita_id,catalogo_id,cantidad,prescripcion")] mTratamiento mTratamiento)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Entry(mTratamiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.catalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mTratamiento.catalogo_id);
            ViewBag.cita_id = new SelectList(db.mCita, "cita_id", "motivo", mTratamiento.cita_id);
            return View(mTratamiento);
        }

        // GET: mTratamientoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mTratamiento mTratamiento = await db.mTratamiento.FindAsync(id);
            if (mTratamiento == null)
            {
                return HttpNotFound();
            }
            return View(mTratamiento);
        }

        // POST: mTratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Tratamientos ".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            mTratamiento mTratamiento = await db.mTratamiento.FindAsync(id);
            db.mTratamiento.Remove(mTratamiento);
            await db.SaveChangesAsync();
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
