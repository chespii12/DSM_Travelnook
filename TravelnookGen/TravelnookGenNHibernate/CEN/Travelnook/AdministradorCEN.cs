

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
/*
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public string New_ (string p_email, String p_contrasenya)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_email;

        administradorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public TravelnookGenNHibernate.EN.Travelnook.AdministradorEN DevuelveAdminPorEmail (string p_email)
{
        return _IAdministradorCAD.DevuelveAdminPorEmail (p_email);
}
}
}
