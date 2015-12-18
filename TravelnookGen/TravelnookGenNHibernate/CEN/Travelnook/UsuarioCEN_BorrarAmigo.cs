
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
        public void BorrarAmigo(string p_yo, string p_amigo)
        {
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Usuario_borrarAmigo) ENABLED START*/

            // Write here your custom code...
            UsuarioCEN usuCEN = new UsuarioCEN();

            IList<UsuarioEN> misamigos = new List<UsuarioEN>();
            IList<UsuarioEN> usuarios = new List<UsuarioEN>();
            IList<UsuarioEN> amigosdeaux = new List<UsuarioEN>();
            IList<string> paraborrar = new List<string>();
            bool borrado = false;
            misamigos = usuCEN.ConsultarAmigos(p_yo);
            foreach (UsuarioEN aux1 in misamigos)
            { //busco en mi lista de amigos al amigo que quiero borrar
                if (aux1.NomUsu == p_amigo)
                { //si esta en mi lista de amigos lo borro
                    paraborrar.Add(p_amigo);
                    usuCEN.EliminarAmigo(p_yo, paraborrar);
                    borrado = true;
                }
            }
            if (borrado == false)
            { //si no esta en mi lista de amigos, yo estoy en su lista
                paraborrar.Add(p_yo);
                usuCEN.EliminarAmigo(p_amigo, paraborrar);
            }

            /*PROTECTED REGION END*/
        }
    }
}
