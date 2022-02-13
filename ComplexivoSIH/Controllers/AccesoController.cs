using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Models;

namespace ComplexivoSIH.Controllers
{
    public class AccesoController : Controller
    {
        private mPersona per = new mPersona();
        private rRol_Persona rtper = new rRol_Persona();
        private mCatalogo mcat = new mCatalogo();
        private Catalogo cat = new Catalogo();
        private mAuditoria aud = new mAuditoria();

        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.acceso = "SOLICITUD DE CREDENCIALES";
            ViewBag.layout = "~/Views/Shared/_Layout.cshtml";
            ViewBag.error = null;
            Session["Layout"] = ViewBag.layout;
            if (Session["error"] == null)
            {
                ViewBag.msgmodulo = "Acceso al Sistema".ToUpper();
                ViewBag.error = "";
            }
            else
            {
                ViewBag.error = Session["error".ToUpper()];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string identificacion, string password)
        {
            try
            {
                string Mensaje = null;
                string Layout = null;
                mPersona oUser = FuncionesController.LeerPersona(ref Mensaje, identificacion);
                if (Mensaje.Substring(0, 4) != "0000")
                {
                    ViewBag.alerta = "danger";
                    ViewBag.error = Mensaje.Substring(4).ToUpper();
                    Session["error"] = ViewBag.error;
                    return View();
                }
                int Persona_Id = oUser.persona_id;         //Se obtiene el numero de Id de la Persona que esta accediendo
                string oRol = FuncionesController.ObtenerRol(ref Mensaje, identificacion, Persona_Id, ref Layout);
                if (Mensaje.Substring(0, 4) != "0000")
                {
                    ViewBag.alerta = "danger";
                    ViewBag.error = "Error: Persona no Tiene Asignado un ROL en e Sistema".ToUpper();
                    Session["error"] = ViewBag.error;
                    return View();
                }
                password = FuncionesController.EncryptKey(password,oUser.identificacion);
                if (oUser.clave == password)
                {
                    Session["Id_mPersona"] = oUser.persona_id;
                    Session["identificacion"] = oUser;
                    Session["Nombres"] = oUser.nombres;
                    Session["Rol"] = oRol;
                    ViewBag.alerta = "success";
                    ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
                    ViewBag.layout = Layout;
                    Session["Layout"] = ViewBag.layout;              
                    return Content(oRol);
                }
                else
                {
                    ViewBag.layout = Session["Layout"];
                    ViewBag.alerta = "danger";
                    ViewBag.error = "Error: Clave Ingresada NO es correcta".ToUpper();
                    Session["error"] = ViewBag.error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.layout = Session["Layout"];
                ViewBag.alerta = "danger";
                ViewBag.error = "Error: ".ToUpper() + ex.Message.ToUpper();
                Session["error"] = ViewBag.error;
            }
            return Content(ViewBag.layout);
            //return View();
        }


        public ActionResult Salir()
        {
            Session["identificacion"] = null;
            Session["Rol"] = null;
            Session["Nombres"] = null;
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            Session["Layout"] = ViewBag.layout;
            Session["error"] = "";
            return View();
        }
    }
}