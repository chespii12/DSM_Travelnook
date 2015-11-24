using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;
using MvcApplication1.Models;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class ArticuloController : BasicController
    {
        //
        // GET: /Articulo/
        
        public ActionResult Index()
        {
            ArticuloCEN cen = new ArticuloCEN();
            IEnumerable<ArticuloEN> list = cen.ReadAll(0, -1).ToList(); 
            return View(list);
        }

        // GET: /Articulo/Categoria/5

        public ActionResult PorCategoria (int id)
        {
            SessionInitialize();
            ArticuloCAD cadArt = new ArticuloCAD(session);
            CategoriaCAD cadCat = new CategoriaCAD(session);
            ArticuloCEN cen = new ArticuloCEN(cadArt);
            IList<ArticuloEN> listArtEn = cen.DameArticulosPorCat(id);
            IEnumerable<Articulo> listArt = new AssemblerArticulo().ConvertListENToModel(listArtEn).ToList();
            CategoriaEN catEN = cadCat.ReadOIDDefault(id);

            ViewData["IdCategoria"] = id;
            if (catEN != null)
                ViewData["NombreCategoria"] = catEN.Nombre;
            
            SessionClose();
            return View(listArt);
        }



        //
        // GET: /Articulo/Details/5

        public ActionResult Details(int id)
        {
            Articulo art = null;
            SessionInitialize();
            ArticuloEN artEN = new ArticuloCAD(session).ReadOIDDefault(id);
            art = new AssemblerArticulo().ConvertENToModelUI(artEN);
            SessionClose();
            return View(art);
        }

        //
        // GET: /Articulo/Create

        public ActionResult Create(int id)
        {
            Articulo art = new Articulo();
            art.IdCategoria = id;
            return View(art);
        }

        //
        // POST: /Articulo/Create

        [HttpPost]
        public ActionResult Create(Articulo art, HttpPostedFileBase file)
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
                ArticuloCEN cen = new ArticuloCEN();
                cen.New_(art.Descripcion, art.Precio, art.IdCategoria, fileName, art.Nombre);

                return RedirectToAction("PorCategoria", new { id=art.IdCategoria});
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Articulo/Edit/5

        public ActionResult Edit(int id)
        {
            Articulo art = null;
            SessionInitialize();
            ArticuloEN artEN = new ArticuloCAD(session).ReadOIDDefault(id);
            art = new AssemblerArticulo().ConvertENToModelUI(artEN);
            SessionClose();
            return View(art);
        }

        //
        // POST: /Articulo/Edit/5

        [HttpPost]
        public ActionResult Edit(Articulo art)
        {
            try
            {
                ArticuloCEN cen = new ArticuloCEN();
                cen.Modify(art.id, art.Descripcion, art.Precio,art.Imagen, art.Nombre);

                return RedirectToAction("PorCategoria", new { id = art.IdCategoria });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Articulo/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int idCategoria = -1;
                SessionInitialize();
                ArticuloCAD artCAD = new ArticuloCAD(session);
                ArticuloCEN cen = new ArticuloCEN(artCAD);
                ArticuloEN artEN = cen.ReadOID(id);
                Articulo art = new AssemblerArticulo().ConvertENToModelUI(artEN);
                idCategoria = art.IdCategoria;
                SessionClose();

                new ArticuloCEN().Destroy(id);
                

                return RedirectToAction("PorCategoria", new {id=idCategoria});
            }
            catch
            {
                return View();
            }
            
        }

        //
        // POST: /Articulo/Delete/5

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
