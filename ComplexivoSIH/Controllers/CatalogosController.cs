using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Helpers;
using ComplexivoSIH.Models;


namespace ComplexivoSIH.Controllers
{
    public class CatalogosController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: Catalogos
        public ActionResult Index(int? id)
        {
            int Id = 0;
            if (id != null) { 
            Id = Convert.ToInt32(id);
            if (Id == 0)
            {
                Id = Convert.ToInt32(Session["id"].ToString());    
            }
            }
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];

            CatalogoHelper catalogoHelper = new CatalogoHelper();

            


            if (id == null)
            {
                var listMCatalogos = catalogoHelper.GetMCatalogo();
                ViewBag.listMCatalogos = listMCatalogos;
                var catalogo = db.Catalogo;
                
                return View(catalogo.ToList());
            }
            else{
                var listMCatalogos = catalogoHelper.GetMCatalogo();
                ViewBag.listMCatalogos = listMCatalogos;
                var catalogo = db.Catalogo.Where(x => x.mcatalogo_id == Id );
                return View(catalogo.ToList());
            }
            
            
        }

        public ActionResult IndexP(int? id)
        {
            int Id = Convert.ToInt32(id);
            if (Session["id"] == null)
            {
                Session["id"] = id;
                return Content("1");
            }
            else
            {
                Session["id"] = null;
                return View();
            }
            
        }
       

        // GET: Catalogos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = db.Catalogo.Find(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            return View(catalogo);
        }

        // GET: Catalogos/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            ViewBag.catalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo");
            return View();
        }

        // POST: Catalogos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "catalogo_id,mcatalogo_id,nombre,descripcion,estado")] Catalogo catalogo)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Catalogo.Add(catalogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.catalogo_id);
            return View(catalogo);
        }

        // GET: Catalogos/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = db.Catalogo.Find(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.catalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.catalogo_id);
            return View(catalogo);
        }

        // POST: Catalogos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "catalogo_id,mcatalogo_id,nombre,descripcion,estado")] Catalogo catalogo)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Entry(catalogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.catalogo_id);
            return View(catalogo);
        }

        // GET: Catalogos/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = db.Catalogo.Find(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            return View(catalogo);
        }

        // POST: Catalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            Catalogo catalogo = db.Catalogo.Find(id);
            db.Catalogo.Remove(catalogo);
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
