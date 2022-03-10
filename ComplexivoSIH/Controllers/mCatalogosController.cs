using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Models;

namespace ComplexivoSIH.Controllers
{
    public class mCatalogosController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: mCatalogos
        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return View(await db.mCatalogo.Where(d => d.estado == true).ToListAsync());
            }
            else
            {
                if (id == 2)
                {
                    return View(await db.mCatalogo.Where(d => d.estado == false).ToListAsync());
                }
                else
                {
                    if (id == 1)
                    {
                        return View(await db.mCatalogo.ToListAsync());
                    }
                }
            }
            return View(await db.mCatalogo.Where(d => d.estado == true).ToListAsync());
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

        [HttpGet]
        public ActionResult InactivosAtr()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Parametros Inactivos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return Content("1");
        }
        [HttpPost]
        public ActionResult InactivosAtr(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return Content(id.ToString());
        }




        // GET: mCatalogos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Detalle de Maestro de Catálogos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "mcatalogo_id,catalogo,estado")] mCatalogo mCatalogo)
        {
            if (ModelState.IsValid)
            {
                db.mCatalogo.Add(mCatalogo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.mcatalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCatalogo.mcatalogo_id);
            return View(mCatalogo);
        }

        // GET: mCatalogos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "mcatalogo_id,catalogo,estado")] mCatalogo mCatalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mCatalogo).State = EntityState.Modified;
                await db .SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.mcatalogo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCatalogo.mcatalogo_id);
            return View(mCatalogo);
        }

        // GET: mCatalogos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            return View(mCatalogo);
        }

        // POST: mCatalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Maestro de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            using (var db = new SIHEntities())
            {
                var oCatalogo = await db.mCatalogo.FindAsync (id);
                oCatalogo.estado = false;
                db.Entry(oCatalogo).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
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
        public async Task<ActionResult> CreateCatalogo(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Creación de Atributos de Catálogos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            var view = new Catalogo { mcatalogo_id = mCatalogo.mcatalogo_id, };
            return View(view);
        }

        // POST: Catalogo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCatalogo(Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Catalogo.Add(catalogo);
                await db.SaveChangesAsync();
                return RedirectToAction(String.Format("Details/{0}", catalogo.mcatalogo_id));
            }

            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            return View(catalogo);
        }

        public async Task<ActionResult> EditCatalogo(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Edición Atributos de Catálogos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = await db.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            return View(catalogo);
        }

        // POST: Catalogo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCatalogo(Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(String.Format("Details/{0}", catalogo.mcatalogo_id));
            }
            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            return View(catalogo);
        }

        public async Task<ActionResult> DeleteCatalogo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = await db.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            catalogo.estado = false;
            db.Entry(catalogo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction(String.Format("Details/{0}", catalogo.mcatalogo_id));
            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            //return View(catalogo);
        }
    }
}
