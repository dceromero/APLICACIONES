﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class DescuentosController : Controller
    {
        // GET: Descuentos
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult Autorizaciones()
        {
             return View();
        }
        public ActionResult Autorizacion(long id)
        {
            return View(id);
        }
    }
}