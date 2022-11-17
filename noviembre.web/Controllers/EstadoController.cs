using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace noviembre.web.Controllers
{
    public class EstadoController : Controller
    {
        public ActionResult Index()
        {
            List<Estado> estados = Estado.GetAll();
            return View(estados);
        }
        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult Guardar(string nombre)
        {
            Estado.Guardar(nombre);
            return RedirectToAction("Index");
        }
    }
}