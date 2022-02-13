using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Models;

namespace ComplexivoSIH.Controllers
{
    public class mCatalogosController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: mCatalogos
        public ActionResult Index(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return View(db.mCatalogo.Where(d => d.estado == true).ToList());
            }
            else
            {
                if (id == 2)
                {
                    return View(db.mCatalogo.Where(d => d.estado == false).ToList());
                }
                else
                {
                    if (id == 1)
                    {
                        return View(db.mCatalogo.ToList());
                    }
                }
            }
            return View(db.mCatalogo.Where(d => d.estado == true).ToList());
        }

        
        [HttpGet]
        public ActionResult Inactivos()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Parametros Inactivos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return Content("1");
        }
        [HttpPost]
        public ActionResult Inactivos(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return Content(id.ToString());
        }




        // GET: mCatalogos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Detalle de Maestro de Catálogos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = db.mCatalogo.Find(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            return View(mCatalogo);
        }

        // GET: mCatalogos/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Creación de Maestro de Catálogos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            ViewBag.mcatalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre");
            return View();
        }

        // POST: mCatalogos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mcatalogo_id,catalogo,estado")] mCatalogo mCatalogo)
        {
            if (ModelState.IsValid)
            {
                db.mCatalogo.Add(mCatalogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mcatalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCatalogo.mcatalogo_id);
            return View(mCatalogo);
        }

        // GET: mCatalogos/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = db.mCatalogo.Find(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.mcatalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCatalogo.mcatalogo_id);
            return View(mCatalogo);
        }

        // POST: mCatalogos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mcatalogo_id,catalogo,estado")] mCatalogo mCatalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mCatalogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mcatalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCatalogo.mcatalogo_id);
            return View(mCatalogo);
        }

        // GET: mCatalogos/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = db.mCatalogo.Find(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            return View(mCatalogo);
        }

        // POST: mCatalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            using (var db = new SIHEntities())
            {
                var oCatalogo = db.mCatalogo.Find(id);
                oCatalogo.estado = false;
                db.Entry(oCatalogo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

            //mCatalogo mCatalogo = db.mCatalogo.Find(id);
            //db.mCatalogo.Remove(mCatalogo);
            //db.SaveChanges();
            //return RedirectToAction("Index");
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
