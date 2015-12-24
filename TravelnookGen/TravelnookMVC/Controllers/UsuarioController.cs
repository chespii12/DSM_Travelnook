using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;
using TravelnookMVC.Models;
using System.IO;
namespace TravelnookMVC.Controllers
{
    public class UsuarioController : BasicController
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(string id)
        {
            Usuario usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).DevuelveUsuarioPorNomUsu(id);
            usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Usuario/Edit/5

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
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Usuario/Delete/5

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
        public ActionResult Favoritos(string id)
        {
            
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).DevuelveUsuarioPorNomUsu(id);
            //usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);
            IList<FavoritoEN> lista = new List<FavoritoEN>();
            foreach (FavoritoEN fav in usuEN.Favorito)
            {
                lista.Add(new FavoritoCAD(session).DevuelveFavoritoPorId(fav.Id));
            }
            
            SessionClose();
            return View(lista);
        }
    }
}
