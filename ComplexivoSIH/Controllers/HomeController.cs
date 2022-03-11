﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComplexivoSIH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HeaderPDF()
        {
            return View("HeaderPDF");
        }

        public ActionResult FooterPDF()
        {
            return View("FooterPDF");
        }
        public ActionResult Index()
        {

            ViewBag.alerta = "info";
            ViewBag.acceso = "Acceso A:".ToUpper() + Session["Nombres"] + "........ASIGNADO EL ROL:" + Session["Rol"];
            ViewBag.layout = Session["Layout"];
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}