
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
 * Clase Petición:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class PeticiónCAD : BasicCAD, IPeticiónCAD
{
public PeticiónCAD() : base ()
{
}

public PeticiónCAD(ISession sessionAux) : base (sessionAux)
{
}



public PeticiónEN ReadOIDDefault (int id)
{
        PeticiónEN peticiónEN = null;

        try
        {
                SessionInitializeTransaction ();
                peticiónEN = (PeticiónEN)session.Get (typeof(PeticiónEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peticiónEN;
}

public System.Collections.Generic.IList<PeticiónEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PeticiónEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PeticiónEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PeticiónEN>();
                        else
                                result = session.CreateCriteria (typeof(PeticiónEN)).List<PeticiónEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }

        return result;
}

public int EnviarSolicitud (PeticiónEN petición)
{
        try
        {
                SessionInitializeTransaction ();
                if (petición.Solicitante != null) {
                        // Argumento OID y no colección.
                        petición.Solicitante = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), petición.Solicitante.Email);

                        petición.Solicitante.SolicitudAmistadSolicitante
                        .Add (petición);
                }
                if (petición.Solicitado != null) {
                        // Argumento OID y no colección.
                        petición.Solicitado = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), petición.Solicitado.Email);

                        petición.Solicitado.SolicitudAmistadSolicitado
                        .Add (petición);
                }

                session.Save (petición);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return petición.Id;
}

public void CancelarSolicitud (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PeticiónEN peticiónEN = (PeticiónEN)session.Load (typeof(PeticiónEN), id);
                session.Delete (peticiónEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PeticiónEN> DevuelvePeticiones (int first, int size)
{
        System.Collections.Generic.IList<PeticiónEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PeticiónEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PeticiónEN>();
                else
                        result = session.CreateCriteria (typeof(PeticiónEN)).List<PeticiónEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> DevuelvePeticionesPorSolicitante ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticiónEN self where FROM Solicitud amistadEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticiónENdevuelvePeticionesPorSolicitanteHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> DevuelvePeticionesPorSolicitado ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticiónEN self where FROM Solicitud amistadEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticiónENdevuelvePeticionesPorSolicitadoHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in PeticiónCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
