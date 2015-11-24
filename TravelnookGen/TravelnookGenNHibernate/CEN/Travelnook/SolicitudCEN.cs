

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
 *      Definition of the class SolicitudCEN
 *
 */
public partial class SolicitudCEN
{
private ISolicitudCAD _ISolicitudCAD;

public SolicitudCEN()
{
        this._ISolicitudCAD = new SolicitudCAD ();
}

public SolicitudCEN(ISolicitudCAD _ISolicitudCAD)
{
        this._ISolicitudCAD = _ISolicitudCAD;
}

public ISolicitudCAD get_ISolicitudCAD ()
{
        return this._ISolicitudCAD;
}

public void CancelarSolicitud (int id)
{
        _ISolicitudCAD.CancelarSolicitud (id);
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudes (string p_solicitante, string p_solicitado)
{
        return _ISolicitudCAD.DevuelveSolicitudes (p_solicitante, p_solicitado);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudesRecibidas (string p_email)
{
        return _ISolicitudCAD.DevuelveSolicitudesRecibidas (p_email);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudesEnviadas (string p_email)
{
        return _ISolicitudCAD.DevuelveSolicitudesEnviadas (p_email);
}
public void AceptarSolicitud (int p_Solicitud_OID, TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum p_estado, Nullable<DateTime> p_fecha)
{
        SolicitudEN solicitudEN = null;

        //Initialized SolicitudEN
        solicitudEN = new SolicitudEN ();
        solicitudEN.Id = p_Solicitud_OID;
        solicitudEN.Estado = p_estado;
        solicitudEN.Fecha = p_fecha;
        //Call to SolicitudCAD

        _ISolicitudCAD.AceptarSolicitud (solicitudEN);
}

public SolicitudEN DevuelveSolicitudPorId (int id)
{
        SolicitudEN solicitudEN = null;

        solicitudEN = _ISolicitudCAD.DevuelveSolicitudPorId (id);
        return solicitudEN;
}

public int CrearSolicitud (string p_solicitante, TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum p_estado, Nullable<DateTime> p_fecha, string p_solicitado)
{
        SolicitudEN solicitudEN = null;
        int oid;

        //Initialized SolicitudEN
        solicitudEN = new SolicitudEN ();

        if (p_solicitante != null) {
                // El argumento p_solicitante -> Property solicitante es oid = false
                // Lista de oids id
                solicitudEN.Solicitante = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                solicitudEN.Solicitante.NomUsu = p_solicitante;
        }

        solicitudEN.Estado = p_estado;

        solicitudEN.Fecha = p_fecha;


        if (p_solicitado != null) {
                // El argumento p_solicitado -> Property solicitado es oid = false
                // Lista de oids id
                solicitudEN.Solicitado = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                solicitudEN.Solicitado.NomUsu = p_solicitado;
        }

        //Call to SolicitudCAD

        oid = _ISolicitudCAD.CrearSolicitud (solicitudEN);
        return oid;
}
}
}
