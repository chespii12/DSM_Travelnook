
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IReportesCAD
{
ReportesEN ReadOIDDefault (int id);

int Crear (ReportesEN reportes);


void Borrar (int id);


System.Collections.Generic.IList<ReportesEN> MostrarReportes (int first, int size);


void MostrarReportesUsuario (int p_Reportes_OID, string p_usuario_OID);

void MostrarReportesComentario (int p_Reportes_OID, int p_comentario_OID);

void MostrarReportesRuta (int p_Reportes_OID, string p_ruta_OID);

void MostrarReportesEvento (int p_Reportes_OID, int p_eventos_OID);

void MostrarReportesSitio (int p_Reportes_OID, string p_sitio_OID);
}
}
