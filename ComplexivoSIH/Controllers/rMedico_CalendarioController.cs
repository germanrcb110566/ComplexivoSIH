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
    public class rMedico_CalendarioController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: rMedico_Calendario
        public async Task<ActionResult> Index()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            var rMedico_Calendario = db.rMedico_Calendario.Include(r => r.mCalendario).Include(r => r.mPersona);
            return View(await rMedico_Calendario.ToListAsync());
        }

        // GET: rMedico_Calendario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rMedico_Calendario rMedico_Calendario = await db.rMedico_Calendario.FindAsync(id);
            if (rMedico_Calendario == null)
            {
                return HttpNotFound();
            }
            return View(rMedico_Calendario);
        }

        // GET: rMedico_Calendario/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            ViewBag.calendario_id = new SelectList(db.mCalendario, "calendario_id", "nombre");
            //ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion");
            ViewBag.medico_id = new SelectList(db.rRol_Persona.Include("mPersona").Where(x => x.rol_id == 15).Select(x => x.mPersona), "persona_id", "nombres");

            return View();
        }

        // POST: rMedico_Calendario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "registro_id,medico_id,calendario_id")] rMedico_Calendario rMedico_Calendario)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.rMedico_Calendario.Add(rMedico_Calendario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.calendario_id = new SelectList(db.mCalendario, "calendario_id", "nombre", rMedico_Calendario.calendario_id);
            ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion", rMedico_Calendario.medico_id);
            return View(rMedico_Calendario);
        }

        // GET: rMedico_Calendario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rMedico_Calendario rMedico_Calendario = await db.rMedico_Calendario.FindAsync(id);
            if (rMedico_Calendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.calendario_id = new SelectList(db.mCalendario, "calendario_id", "nombre", rMedico_Calendario.calendario_id);
            ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion", rMedico_Calendario.medico_id);
            return View(rMedico_Calendario);
        }

        // POST: rMedico_Calendario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "registro_id,medico_id,calendario_id")] rMedico_Calendario rMedico_Calendario)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Entry(rMedico_Calendario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.calendario_id = new SelectList(db.mCalendario, "calendario_id", "nombre", rMedico_Calendario.calendario_id);
            ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion", rMedico_Calendario.medico_id);
            return View(rMedico_Calendario);
        }

        // GET: rMedico_Calendario/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rMedico_Calendario rMedico_Calendario = await db.rMedico_Calendario.FindAsync(id);
            if (rMedico_Calendario == null)
            {
                return HttpNotFound();
            }
            return View(rMedico_Calendario);
        }

        // POST: rMedico_Calendario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Asignación de Calendarios a Médicos".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            rMedico_Calendario rMedico_Calendario = await db.rMedico_Calendario.FindAsync(id);
            db.rMedico_Calendario.Remove(rMedico_Calendario);
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
