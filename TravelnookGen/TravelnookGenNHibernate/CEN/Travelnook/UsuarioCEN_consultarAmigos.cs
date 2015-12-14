
using System;
using System.Text;

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
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> ConsultarAmigos (string p_nombre)
{
        /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Usuario_consultarAmigos_customized) START*/

        return _IUsuarioCAD.ConsultarAmigos (p_nombre);
        /*PROTECTED REGION END*/
}
}
}
