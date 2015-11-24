
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface ISolicitudCAD
{
SolicitudEN ReadOIDDefault (int id);

void CancelarSolicitud (int id);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudes (string p_solicitante, string p_solicitado);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudesRecibidas (string p_email);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudesEnviadas (string p_email);


void AceptarSolicitud (SolicitudEN solicitud);


SolicitudEN DevuelveSolicitudPorId (int id);


int CrearSolicitud (SolicitudEN solicitud);
}
}
