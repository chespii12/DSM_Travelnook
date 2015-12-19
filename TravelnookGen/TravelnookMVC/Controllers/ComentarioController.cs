using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;
using TravelnookMVC.Models;
namespace TravelnookMVC.Controllers
{
    public class ComentarioController : BasicController
    {
        //
        // GET: /Comentario/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Comentario/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Comentario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comentario/Create

        [HttpPost]
        public ActionResult Create(Comentario com)  //funciona porque tienen los dos un campo llamado descripcion
        {
            try
            {
                ComentarioCEN comCEN = new ComentarioCEN();
                com.Usuario = User.Identity.Name;
                int aux = comCEN.CrearComentario(com.Usuario, com.Descripcion, 0, 0, DateTime.Today);
                comCEN.AsignarSitio(aux, com.Sitio);
                return RedirectToAction("Details", "Sitio", new { id = com.Sitio });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comentario/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Comentario/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comentario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Comentario/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
