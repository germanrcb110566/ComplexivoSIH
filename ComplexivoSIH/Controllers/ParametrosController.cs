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
    public class ParametrosController : Controller
    {
        private SIHEntities db = new SIHEntities();

        // GET: Parametros
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(db.mParametros.Where(d => d.estado == true).ToList());
                
            }
            else
            {
                if (id == 2)
                {
                    return View(db.mParametros.Where(d=>d.estado==false).ToList());
                }
                else
                {
                    if (id == 1)
                    {
                        return View(db.mParametros.ToList());
                    }
                }
            }
            return View(db.mParametros.Where(d => d.estado == true).ToList());
        }

        [HttpGet]
        public ActionResult Inactivos()
        {
            return Content("1");
        }
        [HttpPost]
        public ActionResult Inactivos(int? id)
        {
            return Content(id.ToString());
        }

        // GET: Parametros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mParametros mParametros = db.mParametros.Find(id);
            if (mParametros == null)
            {
                return HttpNotFound();
            }
            return View(mParametros);
        }

        // GET: Parametros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parametros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "parametro_id,smtpserver,smtppuerto,correo_sistema,clave_correo,estado")] mParametros mParametros)
        {

            
            if (ModelState.IsValid)
            {
                mParametros.clave_correo = FuncionesController.EncryptKey(mParametros.clave_correo);
                mParametros.estado = true;
                db.mParametros.Add(mParametros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mParametros);
        }

        // GET: Parametros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mParametros mParametros = db.mParametros.Find(id);
            if (mParametros == null)
            {
                return HttpNotFound();
            }
            return View(mParametros);
        }

        // POST: Parametros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "parametro_id,smtpserver,smtppuerto,correo_sistema,clave_correo,estado")] mParametros mParametros)
        {
            if (!ModelState.IsValid)
            {
                return View(mParametros);
            }
            using (var db1 = new SIHEntities())
            {
                var oParametros = db1.mParametros.Find(mParametros.parametro_id);
                if (mParametros.clave_correo == null)
                {
                    mParametros.clave_correo = oParametros.clave_correo;
                }
                else
                {
                    mParametros.clave_correo = FuncionesController.EncryptKey(mParametros.clave_correo);
                }
            }

            db.Entry(mParametros).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        // GET: Parametros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mParametros mParametros = db.mParametros.Find(id);
            if (mParametros == null)
            {
                return HttpNotFound();
            }
            return View(mParametros);
        }

        // POST: Parametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new SIHEntities())
            {
                var oParametro = db.mParametros.Find(id);
                oParametro.estado = false;
                db.Entry(oParametro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

            //mParametros mParametros = db.mParametros.Find(id);
            //db.mParametros.Remove(mParametros);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Borrar(int? id)
        {
            using (var db = new SIHEntities())
            {
                var oParametro = db.mParametros.Find(id);
                oParametro.estado = false;
                db.Entry(oParametro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
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
