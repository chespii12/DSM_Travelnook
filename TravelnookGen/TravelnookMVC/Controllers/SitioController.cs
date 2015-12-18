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

        public ActionResult Create()
        {
            Sitio sit = new Sitio();
            sit.NombreUsuario = User.Identity.Name;
            return View(sit);
        }

        //
        // POST: /Sitio/Create

        [HttpPost]
        public ActionResult Create(Sitio sit, HttpPostedFileBase imagenes, string Tipo_formulario)
        {
            string fileName = "", path = "";
            // Verify that the user selected a file
            if (imagenes != null && imagenes.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(imagenes.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads/"+ sit.Nombre ), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                imagenes.SaveAs(path);
            }

            try
            {
                fileName = "/Images/Uploads/"+ sit.Nombre + "/" + fileName;
                SitioCEN cen = new SitioCEN();
                DateTime fechaActual = DateTime.Today;
                //IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> TipoActividades = new List<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum>();
                
                TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum tipoaux= new TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum();
                tipoaux = (TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum),Tipo_formulario);

                IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> actividadesaux = new List<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum>();
               
                if (sit.camping == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "camping"));
                if (sit.deportes == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "deportes"));
                if (sit.deportes_acuaticos == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "deportes_acuaticos"));
                if (sit.gastronomia == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "gastronomia"));
                if (sit.ludicas == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "ludicas"));
                if (sit.ocio_nocturno == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "ocio_nocturno"));
                if (sit.senderismo == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "senderismo"));
                if (sit.culturales == true)
                    actividadesaux.Add((TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum)Enum.Parse(typeof(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum), "culturales"));

                cen.CrearSitio(sit.Nombre, sit.Provincia, sit.Descripcion, 1, sit.NombreUsuario, sit.Localizacion, fechaActual, 1, sit.Puntuacion, tipoaux, actividadesaux);

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
