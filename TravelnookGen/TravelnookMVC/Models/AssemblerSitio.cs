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
            sit.Puntuacion = en.PuntuacionMedia;
            IList<Comentario> comentarios = new List<Comentario>();
            AssemblerComentario auxiliar= new AssemblerComentario();
            Comentario auxiliar2 = new Comentario();
            foreach (ComentarioEN com in en.Comentarios)
            {
                auxiliar2 = auxiliar.ConvertENToModelUI(com);
                //sit.Comentarios.Add(new AssemblerComentario (ConvertENToModelUI (com)));
                comentarios.Add(auxiliar2);
                //comentarios.Add(com.Id);
            }
            sit.Comentarios = comentarios;

            IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> actividades = new List<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum>();
            foreach (ActividadEN act in en.Actividades)
            {
                actividades.Add(act.Tipo);
            }
            sit.Actividades = actividades;
            IList<string> actividadesimprimir = new List<string>();
            foreach (ActividadEN act in en.Actividades)
            {
                string aux = Convert.ToString(act.Tipo);
                actividadesimprimir.Add(aux);
            }
            sit.Actividadesimprimir = actividadesimprimir;

            IList<string> fotosaux = new List<string>();
            foreach (string act in en.Fotos)
            {
              
                fotosaux.Add(act);
            }
            sit.fotos = fotosaux;
            IList<string> videosaux = new List<string>();
            foreach (string auxvid in en.Videos)
            {

                videosaux.Add(auxvid);
            }
            sit.Videos = videosaux;

            IList<Favorito> favoritos = new List<Favorito>();
            Favorito auxfav = new Favorito();
            foreach (FavoritoEN auxvid in en.Favorito)
            {

                favoritos.Add(auxfav);
            }
            sit.favoritos = favoritos;
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