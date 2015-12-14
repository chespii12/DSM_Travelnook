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
    public class SitioController : BasicController
    {
        //
        // GET: /Sitio/

        public ActionResult Index()
        {
            SitioCEN cen = new SitioCEN();
            IEnumerable<SitioEN> listaCat = cen.DevuelveSitios(0, -1).ToList();
            return View(listaCat);
        }

        //
        // GET: /Sitio/Details/Guadalest   == Sitio.details(guadalest)

        public ActionResult Details(string id)
        {
            Sitio sit = null;
            SessionInitialize();
            SitioEN sitEN = new SitioCAD(session).DevuelveSitioPorNombre(id);
            sit = new AssemblerSitio().ConvertENToModelUI(sitEN);
            SessionClose();
            return View(sit);
        }

        //
        // GET: /Sitio/Create

        public ActionResult Create(string id)
        {
            Sitio sit = new Sitio();
            sit.Nombre = id;
            return View();
        }

        //
        // POST: /Sitio/Create

        [HttpPost]
        public ActionResult Create(Sitio sit, HttpPostedFileBase file)
        {
            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }

            try
            {
                fileName = "/Images/Uploads/" + fileName;
                SitioCEN cen = new SitioCEN();
                cen.CrearSitio(sit.Nombre, sit.Provincia, sit.Descripcion, 1, sit.NombreUsuario, sit.Localizacion, sit.Fecha, 1, sit.Puntuacion, sit.TipoSitio, sit.Actividades);

                return RedirectToAction("Details", new { id = sit.Nombre });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sitio/Edit/5

        public ActionResult Edit(string id)
        {
            Sitio sit = null;
            SessionInitialize();
            SitioEN sitEN = new SitioCAD(session).DevuelveSitioPorNombre(id);
            sit = new AssemblerSitio().ConvertENToModelUI(sitEN);
            SessionClose();
            return View(sit);
        }

        //
        // POST: /Sitio/Edit/5

        [HttpPost]
        public ActionResult Edit(Sitio sit, FormCollection collection)
        {
            try
            {
                SitioCEN cen = new SitioCEN();
                cen.ModificarSitio(sit.Nombre, sit.Provincia, sit.Descripcion, 1, sit.Localizacion, sit.Fecha, 1, sit.Puntuacion, sit.TipoSitio);

                return RedirectToAction("Details", new { id = sit.Nombre });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sitio/Delete/5

        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                int idCategoria = -1;
                SessionInitialize();
                SitioCAD sitCAD = new SitioCAD(session);
                SitioCEN cen = new SitioCEN(sitCAD);
                SitioEN sitEN = cen.DevuelveSitioPorNombre(id);
                Sitio sit = new AssemblerSitio().ConvertENToModelUI(sitEN);
                
                SessionClose();

                new SitioCEN().BorrarSitio(id);


                return RedirectToAction("PorCategoria", new { id = idCategoria });
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Sitio/Delete/5

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
