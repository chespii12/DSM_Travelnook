

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
 *      Definition of the class ReportesCEN
 *
 */
public partial class ReportesCEN
{
private IReportesCAD _IReportesCAD;

public ReportesCEN()
{
        this._IReportesCAD = new ReportesCAD ();
}

public ReportesCEN(IReportesCAD _IReportesCAD)
{
        this._IReportesCAD = _IReportesCAD;
}

public IReportesCAD get_IReportesCAD ()
{
        return this._IReportesCAD;
}

public int Crear (string p_motivo, string p_usuario, string p_sitio, string p_ruta, int p_comentario, int p_eventos, string p_administrador, bool p_marcado)
{
        ReportesEN reportesEN = null;
        int oid;

        //Initialized ReportesEN
        reportesEN = new ReportesEN ();
        reportesEN.Motivo = p_motivo;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                reportesEN.Usuario = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                reportesEN.Usuario.Email = p_usuario;
        }


        if (p_sitio != null) {
                // El argumento p_sitio -> Property sitio es oid = false
                // Lista de oids id
                reportesEN.Sitio = new TravelnookGenNHibernate.EN.Travelnook.SitioEN ();
                reportesEN.Sitio.Nombre = p_sitio;
        }


        if (p_ruta != null) {
                // El argumento p_ruta -> Property ruta es oid = false
                // Lista de oids id
                reportesEN.Ruta = new TravelnookGenNHibernate.EN.Travelnook.RutaEN ();
                reportesEN.Ruta.Nombre = p_ruta;
        }


        if (p_comentario != -1) {
                // El argumento p_comentario -> Property comentario es oid = false
                // Lista de oids id
                reportesEN.Comentario = new TravelnookGenNHibernate.EN.Travelnook.ComentarioEN ();
                reportesEN.Comentario.Id = p_comentario;
        }


        if (p_eventos != -1) {
                // El argumento p_eventos -> Property eventos es oid = false
                // Lista de oids id
                reportesEN.Eventos = new TravelnookGenNHibernate.EN.Travelnook.EventoEN ();
                reportesEN.Eventos.Id = p_eventos;
        }


        if (p_administrador != null) {
                // El argumento p_administrador -> Property administrador es oid = false
                // Lista de oids id
                reportesEN.Administrador = new TravelnookGenNHibernate.EN.Travelnook.AdministradorEN ();
                reportesEN.Administrador.Email = p_administrador;
        }

        reportesEN.Marcado = p_marcado;

        //Call to ReportesCAD

        oid = _IReportesCAD.Crear (reportesEN);
        return oid;
}

public void Borrar (int id)
{
        _IReportesCAD.Borrar (id);
}

public System.Collections.Generic.IList<ReportesEN> MostrarReportes (int first, int size)
{
        System.Collections.Generic.IList<ReportesEN> list = null;

        list = _IReportesCAD.MostrarReportes (first, size);
        return list;
}
public void MostrarReportesUsuario (int p_Reportes_OID, string p_usuario_OID)
{
        //Call to ReportesCAD

        _IReportesCAD.MostrarReportesUsuario (p_Reportes_OID, p_usuario_OID);
}
public void MostrarReportesComentario (int p_Reportes_OID, int p_comentario_OID)
{
        //Call to ReportesCAD

        _IReportesCAD.MostrarReportesComentario (p_Reportes_OID, p_comentario_OID);
}
public void MostrarReportesRuta (int p_Reportes_OID, string p_ruta_OID)
{
        //Call to ReportesCAD

        _IReportesCAD.MostrarReportesRuta (p_Reportes_OID, p_ruta_OID);
}
public void MostrarReportesEvento (int p_Reportes_OID, int p_eventos_OID)
{
        //Call to ReportesCAD

        _IReportesCAD.MostrarReportesEvento (p_Reportes_OID, p_eventos_OID);
}
public void MostrarReportesSitio (int p_Reportes_OID, string p_sitio_OID)
{
        //Call to ReportesCAD

        _IReportesCAD.MostrarReportesSitio (p_Reportes_OID, p_sitio_OID);
}
}
}
