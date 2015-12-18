

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

public string New_ (string p_nomUsu, String p_contrasenya, string p_email)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.NomUsu = p_nomUsu;

        administradorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        administradorEN.Email = p_email;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Destroy (string nomUsu)
{
        _IAdministradorCAD.Destroy (nomUsu);
}

public AdministradorEN DevuelveAdminPorNombre (string nomUsu)
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.DevuelveAdminPorNombre (nomUsu);
        return administradorEN;
}
}
}
