
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string nomUsu);

string CrearUsuario (UsuarioEN usuario);

void BorrarUsuario (string nomUsu);


void ModificarPerfil (UsuarioEN usuario);



TravelnookGenNHibernate.EN.Travelnook.UsuarioEN DevuelveUsuarioPorEmail (string p_email);


UsuarioEN DevuelveUsuarioPorNomUsu (string nomUsu);


void AnyadirAmigo (string p_Usuario_OID, System.Collections.Generic.IList<string> p_amigos_OIDs);

void EliminarAmigo (string p_Usuario_OID, System.Collections.Generic.IList<string> p_amigos_OIDs);

System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> AmigosPorNomUsu (string p_nomUsu);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> AmigosPorEmail (string p_email);


System.Collections.Generic.IList<string> ConsultarAmigos ();


System.Collections.Generic.IList<UsuarioEN> MostrarUsuariosRegistrados (int first, int size);
}
}
