
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
        public bool Login(string p_nomUsu, String p_contrasenya)
        {
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Usuario_login) ENABLED START*/

            // Write here your custom code...

            bool devuelve = false;

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = new UsuarioEN();

            usuarioEN = usuarioCEN.DevuelveUsuarioPorNomUsu(p_nomUsu);

            if (usuarioEN != null)
            {
                if (Utils.Util.GetEncondeMD5(p_contrasenya) == usuarioEN.Contrasenya)
                {
                    devuelve = true;
                }
                else
                {
                    devuelve = false;
                }
            }
            else
            {
                devuelve = false;
            }

            return devuelve;

            /*PROTECTED REGION END*/
        }
    }
}
