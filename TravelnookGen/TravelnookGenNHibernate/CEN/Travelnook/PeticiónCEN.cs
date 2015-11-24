

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
 *      Definition of the class PeticiónCEN
 *
 */
public partial class PeticiónCEN
{
private IPeticiónCAD _IPeticiónCAD;

public PeticiónCEN()
{
        this._IPeticiónCAD = new PeticiónCAD ();
}

public PeticiónCEN(IPeticiónCAD _IPeticiónCAD)
{
        this._IPeticiónCAD = _IPeticiónCAD;
}

public IPeticiónCAD get_IPeticiónCAD ()
{
        return this._IPeticiónCAD;
}

public int EnviarSolicitud (string p_solicitante, TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum p_estado, string p_solicitado)
{
        PeticiónEN peticiónEN = null;
        int oid;

        //Initialized PeticiónEN
        peticiónEN = new PeticiónEN ();

        if (p_solicitante != null) {
                // El argumento p_solicitante -> Property solicitante es oid = false
                // Lista de oids id
                peticiónEN.Solicitante = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                peticiónEN.Solicitante.Email = p_solicitante;
        }

        peticiónEN.Estado = p_estado;


        if (p_solicitado != null) {
                // El argumento p_solicitado -> Property solicitado es oid = false
                // Lista de oids id
                peticiónEN.Solicitado = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                peticiónEN.Solicitado.Email = p_solicitado;
        }

        //Call to PeticiónCAD

        oid = _IPeticiónCAD.EnviarSolicitud (peticiónEN);
        return oid;
}

public void CancelarSolicitud (int id)
{
        _IPeticiónCAD.CancelarSolicitud (id);
}

public System.Collections.Generic.IList<PeticiónEN> DevuelvePeticiones (int first, int size)
{
        System.Collections.Generic.IList<PeticiónEN> list = null;

        list = _IPeticiónCAD.DevuelvePeticiones (first, size);
        return list;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> DevuelvePeticionesPorSolicitante ()
{
        return _IPeticiónCAD.DevuelvePeticionesPorSolicitante ();
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> DevuelvePeticionesPorSolicitado ()
{
        return _IPeticiónCAD.DevuelvePeticionesPorSolicitado ();
}
}
}
