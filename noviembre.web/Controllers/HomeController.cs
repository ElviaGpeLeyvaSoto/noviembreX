﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace noviembre.web.Controllers
{
    // Acciones de controlador
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bienvenida()
        {
            return View();
        }
    }
}