using System;
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
    public class mPermisosController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: mPermisos
        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            var mPermisos = db.mPermisos.Include(m => m.Catalogo).Include(m => m.Catalogo1).Include(m => m.Catalogo2);
            if (id == null)
            {
                return View(await db.mPermisos.Where(d => d.estado == true).ToListAsync());
            }
            else
            {
                if (id == 2)
                {
                    return View(await db.mPermisos.Where(d => d.estado == false).ToListAsync());
                }
                else
                {
                    if (id == 1)
                    {
                        return View(await db.mPermisos.ToListAsync());
                    }
                }
            }
            return View(await db.mPermisos.Where(d => d.estado == true).ToListAsync());

            //return View(await mPermisos.ToListAsync());
        }
        [HttpGet]
        public ActionResult Inactivos()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Permisos Inactivos del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return Content("1");
        }
        [HttpPost]
        public ActionResult Inactivos(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Permisos  del Sistema".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return Content(id.ToString());
        }

        // GET: mPermisos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mPermisos mPermisos = await db.mPermisos.FindAsync(id);
            if (mPermisos == null)
            {
                return HttpNotFound();
            }
            return View(mPermisos);
        }

        // GET: mPermisos/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            //ViewBag.rol_id = new SelectList(db.Catalogo, "catalogo_id", "nombre");
            //ViewBag.modulo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre");
            //ViewBag.accion_id = new SelectList(db.Catalogo, "catalogo_id", "nombre");
            ViewBag.rol_id = new SelectList(db.Catalogo.Where(r => r.mcatalogo_id == 4), "catalogo_id", "nombre");
            ViewBag.modulo_id = new SelectList(db.Catalogo.Where(r => r.mcatalogo_id == 5), "catalogo_id", "nombre");
            ViewBag.accion_id = new SelectList(db.Catalogo.Where(r => r.mcatalogo_id == 3), "catalogo_id", "nombre");

            return View();
        }

        // POST: mPermisos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "permiso_id,rol_id,modulo_id,accion_id,estado")] mPermisos mPermisos)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                try
                {
                    db.mPermisos.Add(mPermisos);
                    await db.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    ViewBag.alerta = "danger";
                    ViewBag.error = ex.Message;
                }
                
                
                return RedirectToAction("Index");
            }

            ViewBag.rol_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mPermisos.rol_id);
            ViewBag.modulo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mPermisos.modulo_id);
            ViewBag.accion_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mPermisos.accion_id);
            return View(mPermisos);
        }

        // GET: mPermisos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mPermisos mPermisos = await db.mPermisos.FindAsync(id);
            if (mPermisos == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol_id = new SelectList(db.Catalogo.Where(r => r.mcatalogo_id==4), "catalogo_id", "nombre", mPermisos.rol_id);
            ViewBag.modulo_id = new SelectList(db.Catalogo.Where(r => r.mcatalogo_id == 5), "catalogo_id", "nombre", mPermisos.modulo_id);
            ViewBag.accion_id = new SelectList(db.Catalogo.Where(r => r.mcatalogo_id == 3), "catalogo_id", "nombre", mPermisos.accion_id);
            return View(mPermisos);
        }

        // POST: mPermisos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "permiso_id,rol_id,modulo_id,accion_id,estado")] mPermisos mPermisos)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Entry(mPermisos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rol_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mPermisos.rol_id);
            ViewBag.modulo_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mPermisos.modulo_id);
            ViewBag.accion_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mPermisos.accion_id);
            return View(mPermisos);
        }

        // GET: mPermisos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mPermisos mPermisos = await db.mPermisos.FindAsync(id);
            if (mPermisos == null)
            {
                return HttpNotFound();
            }
            return View(mPermisos);
        }

        // POST: mPermisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Opción de Permisos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            mPermisos mPermisos = await db.mPermisos.FindAsync(id);
            mPermisos.estado = false;
            db.Entry(mPermisos).State = EntityState.Modified;
            await db.SaveChangesAsync();

            //db.mPermisos.Remove(mPermisos);
            //await db.SaveChangesAsync();
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
