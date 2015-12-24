using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.EN.Travelnook;
namespace TravelnookMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            SitioCEN cen = new SitioCEN();
            IEnumerable<SitioEN> listaCat = cen.DevuelveSitiosOrdenadosPorFecha().ToList();//cen.DevuelveSitios(0, -1).ToList();
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
