using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploDSMGenNHibernate.CEN.EjemploDSM;
using EjemploDSMGenNHibernate.EN.EjemploDSM;
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            CategoriaCEN cen = new CategoriaCEN();
            IEnumerable<CategoriaEN> listaCat = cen.ReadAll(0, -1).ToList();

            return View(listaCat);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
