

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
 *      Definition of the class ReporteCEN
 *
 */
public partial class ReporteCEN
{
private IReporteCAD _IReporteCAD;

public ReporteCEN()
{
        this._IReporteCAD = new ReporteCAD ();
}

public ReporteCEN(IReporteCAD _IReporteCAD)
{
        this._IReporteCAD = _IReporteCAD;
}

public IReporteCAD get_IReporteCAD ()
{
        return this._IReporteCAD;
}

public int CrearReporte (string p_motivo, bool p_marcado)
{
        ReporteEN reporteEN = null;
        int oid;

        //Initialized ReporteEN
        reporteEN = new ReporteEN ();
        reporteEN.Motivo = p_motivo;

        reporteEN.Marcado = p_marcado;

        //Call to ReporteCAD

        oid = _IReporteCAD.CrearReporte (reporteEN);
        return oid;
}

public void BorrarReporte (int id)
{
        _IReporteCAD.BorrarReporte (id);
}

public System.Collections.Generic.IList<ReporteEN> MostrarReportes (int first, int size)
{
        System.Collections.Generic.IList<ReporteEN> list = null;

        list = _IReporteCAD.MostrarReportes (first, size);
        return list;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> MostrarReportesUsuario ()
{
        return _IReporteCAD.MostrarReportesUsuario ();
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> MostrarReportesComentario ()
{
        return _IReporteCAD.MostrarReportesComentario ();
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> MostrarReportesRuta ()
{
        return _IReporteCAD.MostrarReportesRuta ();
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> MostrarReportesEvento ()
{
        return _IReporteCAD.MostrarReportesEvento ();
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> MostrarReportesSitio ()
{
        return _IReporteCAD.MostrarReportesSitio ();
}
public ReporteEN DevuelveReportePorId (int id)
{
        ReporteEN reporteEN = null;

        reporteEN = _IReporteCAD.DevuelveReportePorId (id);
        return reporteEN;
}

public void AsignarSitio (int p_Reporte_OID, string p_sitio_OID)
{
        //Call to ReporteCAD

        _IReporteCAD.AsignarSitio (p_Reporte_OID, p_sitio_OID);
}
public void AsignarRuta (int p_Reporte_OID, string p_ruta_OID)
{
        //Call to ReporteCAD

        _IReporteCAD.AsignarRuta (p_Reporte_OID, p_ruta_OID);
}
public void AsignarEvento (int p_Reporte_OID, int p_evento_OID)
{
        //Call to ReporteCAD

        _IReporteCAD.AsignarEvento (p_Reporte_OID, p_evento_OID);
}
public void AsignarUsuario (int p_Reporte_OID, string p_usuario_OID)
{
        //Call to ReporteCAD

        _IReporteCAD.AsignarUsuario (p_Reporte_OID, p_usuario_OID);
}
public void AsignarComentario (int p_Reporte_OID, int p_comentario_OID)
{
        //Call to ReporteCAD

        _IReporteCAD.AsignarComentario (p_Reporte_OID, p_comentario_OID);
}
}
}
