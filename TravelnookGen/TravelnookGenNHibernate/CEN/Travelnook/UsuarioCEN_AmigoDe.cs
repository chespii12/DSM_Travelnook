
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;

namespace TravelnookGenNHibernate.CEN.Travelnook
{
public partial class UsuarioCEN
{
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> AmigoDe (string p_oid)
{
        /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Usuario_amigoDe) ENABLED START*/

        // Write here your custom code...
        UsuarioCEN usuCEN= new UsuarioCEN();
        IList<UsuarioEN> misamigos = new List<UsuarioEN>();
        IList<UsuarioEN> usuarios = new List<UsuarioEN>();
        IList<UsuarioEN> amigosdeaux = new List<UsuarioEN>();

        misamigos = usuCEN.ConsultarAmigos(p_oid);
        usuarios = usuCEN.MostrarUsuariosRegistrados(0,-1);
        foreach (UsuarioEN aux in usuarios){
            if (aux.NomUsu != p_oid)    //si no es el usuario que llama al metodo
            {
                System.Console.Write(aux.NomUsu+"\n");
                amigosdeaux = usuCEN.ConsultarAmigos(aux.NomUsu);
                foreach (UsuarioEN aux2 in amigosdeaux)
                {
                    System.Console.Write("***"+aux2.NomUsu + "\n");
                    if (aux2.NomUsu == p_oid)
                        misamigos.Add(aux);
                }
            }

        }
        return misamigos;
        throw new NotImplementedException ("Method AmigoDe() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
