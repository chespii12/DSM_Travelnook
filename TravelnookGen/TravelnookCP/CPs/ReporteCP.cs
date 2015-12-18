using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelnookGenNHibernate.EN.Travelnook; // <- Apuntar a los respectivos paquetes de vuestro proyecto.
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;
using NHibernate;

namespace TravelnookCP.CPs
{
    public class ReporteCP : BasicCP
    {
        public ReporteCP() : base() { }

        public ReporteCP(ISession sessionAux)
            : base(sessionAux)
        {
        }
        public void ReporteSitio(string motivo, string sitio_nombre){
            SitioCEN sitioCEN = null;
            ReporteCEN reporteCEN = null;

            try
            {
                SessionInitializeTransaction();
                bool marcado = false;
                SitioCAD sitioCAD = new SitioCAD(session);
                ReporteCAD reporteCAD = new ReporteCAD(session);

                sitioCEN = new SitioCEN(sitioCAD);
                reporteCEN = new ReporteCEN(reporteCAD);

                int reporte_id= reporteCEN.CrearReporte(motivo, marcado);
                //arignar sitio ( reporte, sitio)
                ReporteEN reporte = reporteCAD.DevuelveReportePorId(reporte_id);
                reporteCEN.AsignarSitio(reporte_id, sitio_nombre);

                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

        }
        public void ReporteRuta(string motivo, string ruta_nombre)
        {
            RutaCEN rutaCEN = null;
            ReporteCEN reporteCEN = null;

            try
            {
                SessionInitializeTransaction();
                bool marcado = false;
                RutaCAD rutaCAD = new RutaCAD(session);
                ReporteCAD reporteCAD = new ReporteCAD(session);

                rutaCEN = new RutaCEN(rutaCAD);
                reporteCEN = new ReporteCEN(reporteCAD);

                int reporte_id = reporteCEN.CrearReporte(motivo, marcado);
                //arignar sitio ( reporte, sitio)
                ReporteEN reporte = reporteCAD.DevuelveReportePorId(reporte_id);
                reporteCEN.AsignarRuta(reporte_id, ruta_nombre);

                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

        }
        public void ReporteComentario(string motivo, int comentario_OID)
        {
            ComentarioCEN comentarioCEN = null;
            ReporteCEN reporteCEN = null;

            try
            {
                SessionInitializeTransaction();
                bool marcado = false;
                ComentarioCAD comentarioCAD = new ComentarioCAD(session);
                ReporteCAD reporteCAD = new ReporteCAD(session);

                comentarioCEN = new ComentarioCEN(comentarioCAD);
                reporteCEN = new ReporteCEN(reporteCAD);

                int reporte_id = reporteCEN.CrearReporte(motivo, marcado);
                //arignar sitio ( reporte, sitio)
                ReporteEN reporte = reporteCAD.DevuelveReportePorId(reporte_id);
                
                reporteCEN.AsignarComentario(reporte_id, comentario_OID);

                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

        }
        public void ReporteUsuario(string motivo, string usuario_OID)
        {
            UsuarioCEN usuarioCEN = null;
            ReporteCEN reporteCEN = null;

            try
            {
                SessionInitializeTransaction();
                bool marcado = false;
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                ReporteCAD reporteCAD = new ReporteCAD(session);

                usuarioCEN = new UsuarioCEN(usuarioCAD);
                reporteCEN = new ReporteCEN(reporteCAD);

                int reporte_id = reporteCEN.CrearReporte(motivo, marcado);
                ReporteEN reporte = reporteCAD.DevuelveReportePorId(reporte_id);

                reporteCEN.AsignarUsuario(reporte_id, usuario_OID);

                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

        }
    }
}
