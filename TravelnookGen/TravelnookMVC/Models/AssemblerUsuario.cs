using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerUsuario
    {
        public Usuario ConvertENToModelUI(UsuarioEN en)
        {
            Usuario usu = new Usuario();
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.UserName = en.NomUsu;
            usu.Provincia = en.Provincia;
            usu.Localidad = en.Localidad;
            usu.Foto = en.Foto_perfil;
            usu.Fecha = en.FechaNacimiento;
            usu.Email = en.Email;
            /*sit.Nombre = en.Nombre;
            sit.NombreUsuario = en.Usuario.NomUsu;
            sit.Localizacion = en.Localizacion;
            sit.Provincia = en.Provincia;
            sit.TipoSitio = en.TipoSitio;
            sit.Videos = en.Videos;
            sit.Fecha = en.FechaCreacion;
            sit.Descripcion = en.Descripcion;
            sit.fotos = en.Fotos;
            sit.Puntuacion = en.PuntuacionMedia;
            IList<Comentario> comentarios = new List<Comentario>();
            AssemblerComentario auxiliar = new AssemblerComentario();
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
            sit.Actividadesimprimir = actividadesimprimir;*/
            return usu;


        }
        public IList<Usuario> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<Usuario> sits = new List<Usuario>();
            foreach (UsuarioEN en in ens)
            {
                sits.Add(ConvertENToModelUI(en));
            }
            return sits;
        }

    }
}