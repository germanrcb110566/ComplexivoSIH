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
    public class mCalendariosController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: mCalendarios
        public async Task<ActionResult> Index(int? id )
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            //return View(await db.mCalendario.ToListAsync());
            if (id == null)
            {
                return View(await db.mCalendario.Where(d => d.estado == true).ToListAsync());
            }
            else
            {
                if (id == 2)
                {
                    return View(await db.mCalendario.Where(d => d.estado == false).ToListAsync());
                }
                else
                {
                    if (id == 1)
                    {
                        return View(await db.mCalendario.ToListAsync());
                    }
                }
            }
            return View(await db.mCalendario.Where(d => d.estado == true).ToListAsync());


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

        // GET: mCalendarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCalendario mCalendario = await db.mCalendario.FindAsync(id);
            if (mCalendario == null)
            {
                return HttpNotFound();
            }
            return View(mCalendario);
        }

        // GET: mCalendarios/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            return View();
        }

        // POST: mCalendarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "calendario_id,nombre,entre_semana,fin_de_semana,horario_desde_m,horario_hasta_m,horario_desde_v,horario_hasta_v,intervalo_citas,intervalo_fechas,estado")] mCalendario mCalendario)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.mCalendario.Add(mCalendario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mCalendario);
        }

        // GET: mCalendarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCalendario mCalendario = await db.mCalendario.FindAsync(id);
            if (mCalendario == null)
            {
                return HttpNotFound();
            }
            return View(mCalendario);
        }

        // POST: mCalendarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "calendario_id,nombre,entre_semana,fin_de_semana,horario_desde_m,horario_hasta_m,horario_desde_v,horario_hasta_v,intervalo_citas,intervalo_fechas,estado")] mCalendario mCalendario)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Entry(mCalendario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mCalendario);
        }

        // GET: mCalendarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCalendario mCalendario = await db.mCalendario.FindAsync(id);
            if (mCalendario == null)
            {
                return HttpNotFound();
            }
            return View(mCalendario);
        }

        // POST: mCalendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Maestro de Calendarios".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            mCalendario mCalendario = await db.mCalendario.FindAsync(id);
            db.mCalendario.Remove(mCalendario);
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
