
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IReporteCAD
{
ReporteEN ReadOIDDefault (int id);

int CrearReporte (ReporteEN reporte);


void BorrarReporte (int id);


System.Collections.Generic.IList<ReporteEN> MostrarReportes (int first, int size);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> MostrarReportesUsuario ();


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> MostrarReportesComentario ();


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> MostrarReportesRuta ();


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> MostrarReportesEvento ();


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> MostrarReportesSitio ();


ReporteEN DevuelveReportePorId (int id);


void AsignarSitio (int p_Reporte_OID, string p_sitio_OID);

void AsignarRuta (int p_Reporte_OID, string p_ruta_OID);

void AsignarEvento (int p_Reporte_OID, int p_evento_OID);

void AsignarUsuario (int p_Reporte_OID, string p_usuario_OID);

void AsignarComentario (int p_Reporte_OID, int p_comentario_OID);
}
}
