using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerArticulo
    {
        public Ruta ConvertENToModelUI(ArticuloEN en)
        {
            Ruta art = new Ruta();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Url;
            art.IdCategoria = en.Categoria.Id;
            art.NombreCategoria = en.Categoria.Nombre;
            return art;


        }
        public IList<Ruta> ConvertListENToModel (IList<ArticuloEN> ens){
            IList<Ruta> arts = new List<Ruta>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}