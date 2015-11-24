

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
 *      Definition of the class ActividadCEN
 *
 */
public partial class ActividadCEN
{
private IActividadCAD _IActividadCAD;

public ActividadCEN()
{
        this._IActividadCAD = new ActividadCAD ();
}

public ActividadCEN(IActividadCAD _IActividadCAD)
{
        this._IActividadCAD = _IActividadCAD;
}

public IActividadCAD get_IActividadCAD ()
{
        return this._IActividadCAD;
}

public TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum New_ (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum p_tipo)
{
        ActividadEN actividadEN = null;

        TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum oid;
        //Initialized ActividadEN
        actividadEN = new ActividadEN ();
        actividadEN.Tipo = p_tipo;

        //Call to ActividadCAD

        oid = _IActividadCAD.New_ (actividadEN);
        return oid;
}

public void Modify (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum p_Actividad_OID)
{
        ActividadEN actividadEN = null;

        //Initialized ActividadEN
        actividadEN = new ActividadEN ();
        actividadEN.Tipo = p_Actividad_OID;
        //Call to ActividadCAD

        _IActividadCAD.Modify (actividadEN);
}

public void Destroy (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo)
{
        _IActividadCAD.Destroy (tipo);
}
}
}
