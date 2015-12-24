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