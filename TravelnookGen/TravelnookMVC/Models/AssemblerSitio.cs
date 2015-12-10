using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerSitio
    {
        public Sitio ConvertENToModelUI(SitioEN en) {
            Sitio sit = new Sitio();
            sit.Nombre = en.Nombre;
            sit.Descripcion = en.Descripcion;
            sit.Provincia = en.Provincia;
            sit.Imagen = en.Fotos;
            sit.Video = en.Videos;
            sit.Puntuacion = en.PuntuacionMedia;
            sit.Fecha = en.FechaCreacion;
            sit.TipoSitio = en.TipoSitio;
            sit.Actividades = en.Actividades;
            sit.IdUsuario = en.Usuario.NomUsu;

            return sit;
        }

        public IList<Sitio> ConvertListENToModel(IList<SitioEN> ens)
        {
            IList<Sitio> sits = new List<Sitio>();
            foreach (SitioEN en in ens) {
                sits.Add(ConvertENToModelUI(en));
            }
            return sits;
        }
    }
}
/*
namespace MvcApplication1.Models
{
    public class AssemblerArticulo
    {
        public Articulo ConvertENToModelUI(ArticuloEN en)
        {
            Articulo art = new Articulo();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Url;
            art.IdCategoria = en.Categoria.Id;
            art.NombreCategoria = en.Categoria.Nombre;
            return art;


        }
        public IList<Articulo> ConvertListENToModel (IList<ArticuloEN> ens){
            IList<Articulo> arts = new List<Articulo>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}*/