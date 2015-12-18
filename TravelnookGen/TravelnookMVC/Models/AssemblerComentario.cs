using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerComentario
    {
        public Comentario ConvertENToModelUI(ComentarioEN en)
        {
            Comentario com = new Comentario();
            com.IdComentario = en.Id;
            com.Usuario = en.Usuario.NomUsu;
            com.Descripcion= en.Descripción;
            com.Fecha = en.Fecha;
            com.likes = en.Likes;
            com.dislikes = en.Dislikes;
            com.fotos = en.Fotos;
            com.videos = en.Videos;
            

            return com;


        }
        public IList<Comentario> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<Comentario> comentarios = new List<Comentario>();
            foreach (ComentarioEN en in ens)
            {
                comentarios.Add(ConvertENToModelUI(en));
            }
            return comentarios;
        }

    }
}