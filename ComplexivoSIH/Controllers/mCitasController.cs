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
    public class mCitasController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: mCitas
        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];


            //var mCita = FuncionesController.Citas_Pendientes();
            //Select * from mCita where cita_id not in (select cita_id from mAtencion)



            var mCita = db.mCita.Include(m => m.Catalogo).Include(m => m.mPersona).Include(m => m.mPersona1);
            ViewBag.medico_id = new SelectList(db.rRol_Persona.Include("mPersona").Where(x => x.rol_id == 10).Select(x => x.mPersona), "persona_id", "nombres");
            if (id == null)
            {
                mCita = db.mCita.Where(d => d.estado == true).Include(m => m.Catalogo).Include(m => m.mPersona).Include(m => m.mPersona1);
                return View(await mCita.ToListAsync());
            }
            else
            {
                if (id == 2)
                {
                    mCita = db.mCita.Where(d => d.estado == false).Include(m => m.Catalogo).Include(m => m.mPersona).Include(m => m.mPersona1);
                    return View(await mCita.ToListAsync());

                }
                else
                {
                    if (id == 1)
                    {
                        mCita = db.mCita.Include(m => m.Catalogo).Include(m => m.mPersona).Include(m => m.mPersona1);
                        return View(await mCita.ToListAsync());
                    }
                }
            }
            mCita = db.mCita.Where(d => d.estado == true).Include(m => m.Catalogo).Include(m => m.mPersona).Include(m => m.mPersona1);
            return View(await mCita.ToListAsync());
        }

        public ActionResult Inactivos()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
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
        // GET: mCitas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCita mCita = await db.mCita.FindAsync(id);
            if (mCita == null)
            {
                return HttpNotFound();
            }
            return View(mCita);
        }

        // GET: mCitas/Create
        public ActionResult Create()
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            ViewBag.especialidad_id = new SelectList(db.Catalogo.Where(d => d.mcatalogo_id == 6), "catalogo_id", "nombre");
            //ViewBag.paciente_id = new SelectList(db.mPersona, "persona_id", "identificacion");
            ViewBag.paciente_id = new SelectList(db.rRol_Persona.Include("mPersona").Where(x => x.rol_id == 10).Select(x => x.mPersona), "persona_id", "nombres");
            //ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion");
            ViewBag.medico_id = new SelectList(db.rRol_Persona.Include("mPersona").Where(x => x.rol_id == 15).Select(x => x.mPersona), "persona_id", "nombres");
            return View();
        }

        // POST: mCitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cita_id,paciente_id,medico_id,especialidad_id,fecha,hora,motivo,estado")] mCita mCita)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.mCita.Add(mCita);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.especialidad_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCita.especialidad_id);
            ViewBag.paciente_id = new SelectList(db.mPersona, "persona_id", "identificacion", mCita.paciente_id);
            ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion", mCita.medico_id);
            return View(mCita);
        }

        // GET: mCitas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCita mCita = await db.mCita.FindAsync(id);
            if (mCita == null)
            {
                return HttpNotFound();
            }
            ViewBag.especialidad_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCita.especialidad_id);
            ViewBag.paciente_id = new SelectList(db.mPersona, "persona_id", "identificacion", mCita.paciente_id);
            ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion", mCita.medico_id);
            return View(mCita);
        }

        // POST: mCitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cita_id,paciente_id,medico_id,especialidad_id,fecha,hora,motivo,estado")] mCita mCita)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (ModelState.IsValid)
            {
                db.Entry(mCita).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.especialidad_id = new SelectList(db.Catalogo, "catalogo_id", "nombre", mCita.especialidad_id);
            ViewBag.paciente_id = new SelectList(db.mPersona, "persona_id", "identificacion", mCita.paciente_id);
            ViewBag.medico_id = new SelectList(db.mPersona, "persona_id", "identificacion", mCita.medico_id);
            return View(mCita);
        }

        // GET: mCitas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCita mCita = await db.mCita.FindAsync(id);
            if (mCita == null)
            {
                return HttpNotFound();
            }
            return View(mCita);
        }

        // POST: mCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.msgmodulo = "Visualizar Citas de Pacientes".ToUpper();
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            mCita mCita = await db.mCita.FindAsync(id);
            db.mCita.Remove(mCita);
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
