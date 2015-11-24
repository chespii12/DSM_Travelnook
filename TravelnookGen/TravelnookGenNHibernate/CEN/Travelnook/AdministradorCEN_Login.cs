
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
public partial class AdministradorCEN
{
public bool Login (string p_email, String p_contrasenya)
{
        /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Administrador_login) ENABLED START*/

        // Write here your custom code...

        bool devuelve = false;

        AdministradorCEN adminCEN = new AdministradorCEN ();
        AdministradorEN adminEN = new AdministradorEN ();

        adminEN = adminCEN.DevuelveAdminPorEmail (p_email);

        if (adminEN != null) {
                if (Utils.Util.GetEncondeMD5 (p_contrasenya) == adminEN.Contrasenya) {
                        devuelve = true;
                }
                else{
                        devuelve = false;
                }
        }
        else{
                devuelve = false;
        }

        return devuelve;

        /*PROTECTED REGION END*/
}
}
}
