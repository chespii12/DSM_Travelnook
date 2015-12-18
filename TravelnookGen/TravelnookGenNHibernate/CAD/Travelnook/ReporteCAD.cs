
using System;
using System.Text;
using TravelnookGenNHibernate.CEN.Travelnook;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.Exceptions;

/*
 * Clase Reporte:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class ReporteCAD : BasicCAD, IReporteCAD
{
public ReporteCAD() : base ()
{
}

public ReporteCAD(ISession sessionAux) : base (sessionAux)
{
}



public ReporteEN ReadOIDDefault (int id)
{
        ReporteEN reporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Get (typeof(ReporteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reporteEN;
}

public System.Collections.Generic.IList<ReporteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReporteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReporteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReporteEN>();
                        else
                                result = session.CreateCriteria (typeof(ReporteEN)).List<ReporteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }

        return result;
}

public int CrearReporte (ReporteEN reporte)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (reporte);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reporte.Id;
}

public void BorrarReporte (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ReporteEN reporteEN = (ReporteEN)session.Load (typeof(ReporteEN), id);
                session.Delete (reporteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ReporteEN> MostrarReportes (int first, int size)
{
        System.Collections.Generic.IList<ReporteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReporteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReporteEN>();
                else
                        result = session.CreateCriteria (typeof(ReporteEN)).List<ReporteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> MostrarReportesUsuario ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReporteEN self where select (usuario) FROM ReporteEN as r inner join r.Usuario as usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReporteENmostrarReportesUsuarioHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> MostrarReportesComentario ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReporteEN self where select (comentario) FROM ReporteEN as r inner join r.Comentario as comentario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReporteENmostrarReportesComentarioHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> MostrarReportesRuta ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReporteEN self where select (ruta) FROM ReporteEN as r inner join r.Ruta as ruta";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReporteENmostrarReportesRutaHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> MostrarReportesEvento ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReporteEN self where select (evento) FROM ReporteEN as r inner join r.Evento as evento";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReporteENmostrarReportesEventoHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> MostrarReportesSitio ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReporteEN self where select (sitio) FROM ReporteEN as r inner join r.Sitio as sitio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReporteENmostrarReportesSitioHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DevuelveReportePorId
//Con e: ReporteEN
public ReporteEN DevuelveReportePorId (int id)
{
        ReporteEN reporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Get (typeof(ReporteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reporteEN;
}

public void AsignarSitio (int p_Reporte_OID, string p_sitio_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReporteEN reporteEN = null;
        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Load (typeof(ReporteEN), p_Reporte_OID);
                reporteEN.Sitio = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), p_sitio_OID);

                reporteEN.Sitio.Reporte.Add (reporteEN);



                session.Update (reporteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarRuta (int p_Reporte_OID, string p_ruta_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReporteEN reporteEN = null;
        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Load (typeof(ReporteEN), p_Reporte_OID);
                reporteEN.Ruta = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), p_ruta_OID);

                reporteEN.Ruta.Reporte.Add (reporteEN);



                session.Update (reporteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarEvento (int p_Reporte_OID, int p_evento_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReporteEN reporteEN = null;
        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Load (typeof(ReporteEN), p_Reporte_OID);
                reporteEN.Evento = (TravelnookGenNHibernate.EN.Travelnook.EventoEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.EventoEN), p_evento_OID);

                reporteEN.Evento.Reporte.Add (reporteEN);



                session.Update (reporteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarUsuario (int p_Reporte_OID, string p_usuario_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReporteEN reporteEN = null;
        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Load (typeof(ReporteEN), p_Reporte_OID);
                reporteEN.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), p_usuario_OID);

                reporteEN.Usuario.Reporte.Add (reporteEN);



                session.Update (reporteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarComentario (int p_Reporte_OID, int p_comentario_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReporteEN reporteEN = null;
        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Load (typeof(ReporteEN), p_Reporte_OID);
                reporteEN.Comentario = (TravelnookGenNHibernate.EN.Travelnook.ComentarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.ComentarioEN), p_comentario_OID);

                reporteEN.Comentario.Reportes.Add (reporteEN);



                session.Update (reporteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReporteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
