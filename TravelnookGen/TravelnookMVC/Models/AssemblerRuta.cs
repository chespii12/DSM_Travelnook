using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerRuta
    {
        public Ruta ConvertENToModelUI(RutaEN en)
        {
            Ruta rut = new Ruta();
            rut.Nombre = en.Nombre;
            rut.Descripcion = en.Descripcion;
            rut.Provincia = en.Provincia;
            rut.Puntuacion = en.PuntuacionMedia;
            rut.Fecha = en.FechaCreacion;
            IList<string>sitios= new List<string>();
            foreach (SitioEN sit in en.Sitio)
            {
                sitios.Add(sit.Nombre);
            }
            rut.Idsitios = sitios;
            
            return rut;


        }
        public IList<Ruta> ConvertListENToModel (IList<RutaEN> ens){
            IList<Ruta> rutas = new List<Ruta>();
            foreach (RutaEN en in ens)
            {
                rutas.Add(ConvertENToModelUI(en));
            }
            return rutas;
        }
        
    }
}