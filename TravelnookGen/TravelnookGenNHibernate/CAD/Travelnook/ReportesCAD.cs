
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
 * Clase Reportes:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class ReportesCAD : BasicCAD, IReportesCAD
{
public ReportesCAD() : base ()
{
}

public ReportesCAD(ISession sessionAux) : base (sessionAux)
{
}



public ReportesEN ReadOIDDefault (int id)
{
        ReportesEN reportesEN = null;

        try
        {
                SessionInitializeTransaction ();
                reportesEN = (ReportesEN)session.Get (typeof(ReportesEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reportesEN;
}

public System.Collections.Generic.IList<ReportesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReportesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReportesEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReportesEN>();
                        else
                                result = session.CreateCriteria (typeof(ReportesEN)).List<ReportesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }

        return result;
}

public int Crear (ReportesEN reportes)
{
        try
        {
                SessionInitializeTransaction ();
                if (reportes.Usuario != null) {
                        // Argumento OID y no colección.
                        reportes.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), reportes.Usuario.Email);

                        reportes.Usuario.Reportes
                        .Add (reportes);
                }
                if (reportes.Sitio != null) {
                        // Argumento OID y no colección.
                        reportes.Sitio = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), reportes.Sitio.Nombre);

                        reportes.Sitio.Reportes
                        .Add (reportes);
                }
                if (reportes.Ruta != null) {
                        // Argumento OID y no colección.
                        reportes.Ruta = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), reportes.Ruta.Nombre);

                        reportes.Ruta.Reportes
                        .Add (reportes);
                }
                if (reportes.Comentario != null) {
                        // Argumento OID y no colección.
                        reportes.Comentario = (TravelnookGenNHibernate.EN.Travelnook.ComentarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.ComentarioEN), reportes.Comentario.Id);

                        reportes.Comentario.Reportes
                        .Add (reportes);
                }
                if (reportes.Eventos != null) {
                        // Argumento OID y no colección.
                        reportes.Eventos = (TravelnookGenNHibernate.EN.Travelnook.EventoEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.EventoEN), reportes.Eventos.Id);

                        reportes.Eventos.Reportes
                        .Add (reportes);
                }
                if (reportes.Administrador != null) {
                        // Argumento OID y no colección.
                        reportes.Administrador = (TravelnookGenNHibernate.EN.Travelnook.AdministradorEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.AdministradorEN), reportes.Administrador.Email);

                        reportes.Administrador.Reportes
                        .Add (reportes);
                }

                session.Save (reportes);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reportes.Id;
}

public void Borrar (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ReportesEN reportesEN = (ReportesEN)session.Load (typeof(ReportesEN), id);
                session.Delete (reportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ReportesEN> MostrarReportes (int first, int size)
{
        System.Collections.Generic.IList<ReportesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReportesEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReportesEN>();
                else
                        result = session.CreateCriteria (typeof(ReportesEN)).List<ReportesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void MostrarReportesUsuario (int p_Reportes_OID, string p_usuario_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReportesEN reportesEN = null;
        try
        {
                SessionInitializeTransaction ();
                reportesEN = (ReportesEN)session.Load (typeof(ReportesEN), p_Reportes_OID);
                reportesEN.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), p_usuario_OID);

                reportesEN.Usuario.Reportes.Add (reportesEN);



                session.Update (reportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void MostrarReportesComentario (int p_Reportes_OID, int p_comentario_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReportesEN reportesEN = null;
        try
        {
                SessionInitializeTransaction ();
                reportesEN = (ReportesEN)session.Load (typeof(ReportesEN), p_Reportes_OID);
                reportesEN.Comentario = (TravelnookGenNHibernate.EN.Travelnook.ComentarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.ComentarioEN), p_comentario_OID);

                reportesEN.Comentario.Reportes.Add (reportesEN);



                session.Update (reportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void MostrarReportesRuta (int p_Reportes_OID, string p_ruta_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReportesEN reportesEN = null;
        try
        {
                SessionInitializeTransaction ();
                reportesEN = (ReportesEN)session.Load (typeof(ReportesEN), p_Reportes_OID);
                reportesEN.Ruta = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), p_ruta_OID);

                reportesEN.Ruta.Reportes.Add (reportesEN);



                session.Update (reportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void MostrarReportesEvento (int p_Reportes_OID, int p_eventos_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReportesEN reportesEN = null;
        try
        {
                SessionInitializeTransaction ();
                reportesEN = (ReportesEN)session.Load (typeof(ReportesEN), p_Reportes_OID);
                reportesEN.Eventos = (TravelnookGenNHibernate.EN.Travelnook.EventoEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.EventoEN), p_eventos_OID);

                reportesEN.Eventos.Reportes.Add (reportesEN);



                session.Update (reportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void MostrarReportesSitio (int p_Reportes_OID, string p_sitio_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ReportesEN reportesEN = null;
        try
        {
                SessionInitializeTransaction ();
                reportesEN = (ReportesEN)session.Load (typeof(ReportesEN), p_Reportes_OID);
                reportesEN.Sitio = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), p_sitio_OID);

                reportesEN.Sitio.Reportes.Add (reportesEN);



                session.Update (reportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ReportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
