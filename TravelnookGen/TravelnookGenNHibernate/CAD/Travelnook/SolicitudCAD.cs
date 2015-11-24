
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
 * Clase Solicitud:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class SolicitudCAD : BasicCAD, ISolicitudCAD
{
public SolicitudCAD() : base ()
{
}

public SolicitudCAD(ISession sessionAux) : base (sessionAux)
{
}



public SolicitudEN ReadOIDDefault (int id)
{
        SolicitudEN solicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitudEN = (SolicitudEN)session.Get (typeof(SolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SolicitudEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SolicitudEN>();
                        else
                                result = session.CreateCriteria (typeof(SolicitudEN)).List<SolicitudEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }

        return result;
}

public void CancelarSolicitud (int id)
{
        try
        {
                SessionInitializeTransaction ();
                SolicitudEN solicitudEN = (SolicitudEN)session.Load (typeof(SolicitudEN), id);
                session.Delete (solicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudes (string p_solicitante, string p_solicitado)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SolicitudEN self where FROM SolicitudEN s where s.Solicitante.Email like '%'+:p_solicitante+'%' AND s.Solicitado.Email like '%'+:p_solicitado+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SolicitudENdevuelveSolicitudesHQL");
                query.SetParameter ("p_solicitante", p_solicitante);
                query.SetParameter ("p_solicitado", p_solicitado);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudesRecibidas (string p_email)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SolicitudEN self where FROM SolicitudEN s where s.Solicitado.Email like '%'+:p_email+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SolicitudENdevuelveSolicitudesRecibidasHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> DevuelveSolicitudesEnviadas (string p_email)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SolicitudEN self where FROM SolicitudEN s where s.Solicitante.Email like '%'+:p_email+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SolicitudENdevuelveSolicitudesEnviadasHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AceptarSolicitud (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                SolicitudEN solicitudEN = (SolicitudEN)session.Load (typeof(SolicitudEN), solicitud.Id);

                solicitudEN.Estado = solicitud.Estado;


                solicitudEN.Fecha = solicitud.Fecha;

                session.Update (solicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: DevuelveSolicitudPorId
//Con e: SolicitudEN
public SolicitudEN DevuelveSolicitudPorId (int id)
{
        SolicitudEN solicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitudEN = (SolicitudEN)session.Get (typeof(SolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitudEN;
}

public int CrearSolicitud (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                if (solicitud.Solicitante != null) {
                        // Argumento OID y no colección.
                        solicitud.Solicitante = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), solicitud.Solicitante.NomUsu);

                        solicitud.Solicitante.SolicitudAmistadSolicitante
                        .Add (solicitud);
                }
                if (solicitud.Solicitado != null) {
                        // Argumento OID y no colección.
                        solicitud.Solicitado = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), solicitud.Solicitado.NomUsu);

                        solicitud.Solicitado.SolicitudAmistadSolicitado
                        .Add (solicitud);
                }

                session.Save (solicitud);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitud.Id;
}
}
}
