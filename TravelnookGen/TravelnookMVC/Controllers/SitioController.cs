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
            string aux = sit.Localizacion;
            if (aux != "") {    //si tiene coordenadas saco las dos
                sit.tieneLocalizacion = 1;
                string sinpar= aux.Trim(new Char[] { '(', ')' });  //borro los paréntesis
                string[] aux2 = sinpar.Split(',');
                sit.latitud = aux2[0];
                sit.longitud = aux2[1];
            }
            else //si no lo indico
            {
                sit.tieneLocalizacion = 0;
                sit.latitud = "40.268846";
                sit.longitud = "-3.934834";
            }
            
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
        public ActionResult Create(Sitio sit, IList<HttpPostedFileBase> imagenes, IList<HttpPostedFileBase> videos, string Tipo_formulario)
        {
            string fileName = "", path = "";
            IList<string> fotografias = new List<string>();
            IList<string> videosSitio = new List<string>();
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images/Uploads/" + sit.Nombre));
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Videos/Uploads/" + sit.Nombre));
            // Verify that the user selected a file
            foreach (HttpPostedFileBase aux in imagenes)    //para cada imagen
            {
                if (aux != null && aux.ContentLength > 0)
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(aux.FileName);
                    //Directory.CreateDirectory("~/Images/Uploads/" + sit.Nombre);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Images/Uploads/" + sit.Nombre), fileName);
                    //string pathDef = path.Replace(@"\\", @"\");
                    aux.SaveAs(path);
                    fotografias.Add("/Images/Uploads/" + sit.Nombre + "/" + fileName);
                }
            }
            foreach (HttpPostedFileBase aux2 in videos)    //para cada imagen
            {
                if (aux2 != null && aux2.ContentLength > 0)
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(aux2.FileName);
                    //Directory.CreateDirectory("~/Images/Uploads/" + sit.Nombre);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Videos/Uploads/" + sit.Nombre), fileName);
                    //string pathDef = path.Replace(@"\\", @"\");
                    aux2.SaveAs(path);
                    videosSitio.Add("/Videos/Uploads/" + sit.Nombre + "/" + fileName);
                }
            }

            try
            {
                fileName = "/Images/Uploads/"+ sit.Nombre + "/" + fileName;
                SitioCEN cen = new SitioCEN();
                DateTime fechaActual = DateTime.Today;                
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

                cen.CrearSitio(sit.Nombre, sit.Provincia, sit.Descripcion, 1, fotografias, sit.NombreUsuario, videosSitio, sit.Localizacion, fechaActual, 1, sit.Puntuacion, tipoaux, actividadesaux);

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
            foreach (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum aux in sit.Actividades)
            {
                string nombre = Convert.ToString(aux);
                if (nombre == "camping") sit.camping = true;
                else if (nombre == "deportes") sit.deportes = true;
                else if (nombre == "ocio_nocturno") sit.ocio_nocturno = true;
                else if (nombre == "deportes_acuaticos") sit.deportes_acuaticos = true;
                else if (nombre == "senderismo") sit.senderismo = true;
                else if (nombre == "ludicas") sit.ludicas = true;
                else if (nombre == "culturales") sit.culturales = true;
                else if (nombre == "gastronomia") sit.gastronomia = true;
            }
            string aux3 = sit.Localizacion;
            if (aux3 != "")
            {    //si tiene coordenadas saco las dos
                sit.tieneLocalizacion = 1;
                string sinpar = aux3.Trim(new Char[] { '(', ')' });  //borro los paréntesis
                string[] aux2 = sinpar.Split(',');
                sit.latitud = aux2[0];
                sit.longitud = aux2[1];
            }
            else //si no lo indico
            {
                sit.tieneLocalizacion = 0;
                sit.latitud = "40.268846";
                sit.longitud = "-3.934834";
            }
            return View(sit);
        }

        //
        // POST: /Sitio/Edit/5

        [HttpPost]
        public ActionResult Edit(Sitio sit, IList<HttpPostedFileBase> imagenes, IList<HttpPostedFileBase> videos, string Tipo_formulario)
        {
            try
            {
                 string fileName = "", path = "";
                IList<string> fotografias = new List<string>();
                IList<string> videosSitio = new List<string>();
                SessionInitialize();
                SitioEN sitEN = new SitioCAD(session).DevuelveSitioPorNombre(sit.Nombre);
                
                //System.IO.Directory.CreateDirectory(Server.MapPath("~/Images/Uploads/" + sit.Nombre)); si se puede cambiar el nombre descomentar
               // System.IO.Directory.CreateDirectory(Server.MapPath("~/Videos/Uploads/" + sit.Nombre));
                SitioCEN cen = new SitioCEN();
                foreach (HttpPostedFileBase aux in imagenes)    //para cada imagen
                {
                    if (aux != null && aux.ContentLength > 0)
                    {
                        // extract only the fielname
                        fileName = Path.GetFileName(aux.FileName);
                        //Directory.CreateDirectory("~/Images/Uploads/" + sit.Nombre);
                        // store the file inside ~/App_Data/uploads folder
                        path = Path.Combine(Server.MapPath("~/Images/Uploads/" + sit.Nombre), fileName);
                        //string pathDef = path.Replace(@"\\", @"\");
                        aux.SaveAs(path);
                        sitEN.Fotos.Add("/Images/Uploads/" + sit.Nombre + "/" + fileName);
                    }
                }
                foreach (HttpPostedFileBase aux2 in videos)    //para cada imagen
                {
                    if (aux2 != null && aux2.ContentLength > 0)
                    {
                        // extract only the fielname
                        fileName = Path.GetFileName(aux2.FileName);
                        //Directory.CreateDirectory("~/Images/Uploads/" + sit.Nombre);
                        // store the file inside ~/App_Data/uploads folder
                        path = Path.Combine(Server.MapPath("~/Videos/Uploads/" + sit.Nombre), fileName);
                        //string pathDef = path.Replace(@"\\", @"\");
                        aux2.SaveAs(path);
                        sitEN.Videos.Add("/Videos/Uploads/" + sit.Nombre + "/" + fileName);
                    }
                }
                SessionClose();
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
               //falta el unrelationer(arriba antes de sesionclose) y volver a relacionar
                cen.ModificarSitio(sit.Nombre, sit.Provincia, sit.Descripcion, sitEN.Puntuacion, sitEN.Fotos, sitEN.Videos, sit.Localizacion, sitEN.FechaCreacion, sitEN.NumPuntuados, sitEN.PuntuacionMedia, tipoaux);
                
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
        [HttpPost]
        public ActionResult SitioPorNombre(Sitio sitio)
        {
            try
            {
                string nameSitio = Request.Form["nombre"];
                SessionInitialize();
                SitioCAD sitCAD = new SitioCAD(session);
                SitioCEN cen = new SitioCEN(sitCAD);

                if (nameSitio != "")
                {
                    SitioEN sitEN = cen.DevuelveSitioPorNombre(nameSitio);
                    Sitio sit = new AssemblerSitio().ConvertENToModelUI(sitEN);
                    return View(sit);
                }
                else
                {
                    IList<SitioEN> lista = cen.DevuelveSitios(0, -1);
                    IList<Sitio> sit = new AssemblerSitio().ConvertListENToModel(lista);
                    return View(lista);
                }
            }
            catch
            {
                return View();
            }
        }
        public void SitioFavotiro(string id)
        {
            SessionInitialize();
            SitioCAD sitCAD = new SitioCAD(session);
            SitioCEN cen = new SitioCEN(sitCAD);
            SitioEN sitEN = cen.DevuelveSitioPorNombre(id);
            Sitio sit = new AssemblerSitio().ConvertENToModelUI(sitEN);

            SessionClose();

        }
    }
}
