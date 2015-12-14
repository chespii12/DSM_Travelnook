using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerSitio
    {
        public Sitio ConvertENToModelUI(SitioEN en)
        {
            Sitio sit = new Sitio();
            sit.Nombre = en.Nombre;
            sit.NombreUsuario = en.Usuario.NomUsu;
            sit.Localizacion = en.Localizacion;
            sit.Provincia = en.Provincia;
            sit.TipoSitio = en.TipoSitio;
            sit.Videos = en.Videos;
            sit.Fecha = en.FechaCreacion;
            sit.Descripcion = en.Descripcion;
            sit.fotos = en.Fotos;
            sit.Puntuacion = en.PuntuacionMedia;
            IList<int> comentarios = new List<int>();
            foreach (ComentarioEN com in en.Comentarios)
            {
                comentarios.Add(com.Id);
            }
            sit.IdComentarios = comentarios;

            IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> actividades = new List<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum>();
            foreach (ActividadEN act in en.Actividades)
            {
                actividades.Add(act.Tipo);
            }
            sit.Actividades = actividades;
            return sit;


        }
        public IList<Sitio> ConvertListENToModel(IList<SitioEN> ens)
        {
            IList<Sitio> sits = new List<Sitio>();
            foreach (SitioEN en in ens)
            {
                sits.Add(ConvertENToModelUI(en));
            }
            return sits;
        }

    }
}