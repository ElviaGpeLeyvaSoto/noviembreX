using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace noviembre.web.Controllers
{
    public class CiudadanoController : Controller
    {
        // GET: Ciudadano
        public ActionResult Index()
        {
            List<Ciudadano> ciudadanos = Ciudadano.GetAll();
            return View(ciudadanos);
            
        }
        public ActionResult Registro(int id)
        {
            Ciudadano ciudadano = Ciudadano.GetById(id);
            return View(ciudadano);
        }
        public ActionResult Guardar(int id,string nombre, string apellidoPaterno, string apellidoMaterno,string telefono , string direccion, string email)
        {
            Ciudadano.Guardar(id,nombre, apellidoPaterno, apellidoMaterno, telefono, direccion, email);

            return RedirectToAction("Index");
        }
    }
}