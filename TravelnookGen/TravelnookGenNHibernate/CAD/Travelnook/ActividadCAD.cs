
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
 * Clase Actividad:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class ActividadCAD : BasicCAD, IActividadCAD
{
public ActividadCAD() : base ()
{
}

public ActividadCAD(ISession sessionAux) : base (sessionAux)
{
}



public ActividadEN ReadOIDDefault (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo)
{
        ActividadEN actividadEN = null;

        try
        {
                SessionInitializeTransaction ();
                actividadEN = (ActividadEN)session.Get (typeof(ActividadEN), tipo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ActividadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return actividadEN;
}

public System.Collections.Generic.IList<ActividadEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ActividadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ActividadEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ActividadEN>();
                        else
                                result = session.CreateCriteria (typeof(ActividadEN)).List<ActividadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ActividadCAD.", ex);
        }

        return result;
}

public TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum New_ (ActividadEN actividad)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (actividad);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ActividadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return actividad.Tipo;
}

public void Modify (ActividadEN actividad)
{
        try
        {
                SessionInitializeTransaction ();
                ActividadEN actividadEN = (ActividadEN)session.Load (typeof(ActividadEN), actividad.Tipo);
                session.Update (actividadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ActividadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo)
{
        try
        {
                SessionInitializeTransaction ();
                ActividadEN actividadEN = (ActividadEN)session.Load (typeof(ActividadEN), tipo);
                session.Delete (actividadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ActividadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
