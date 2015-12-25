
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
 * Clase Ruta:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class RutaCAD : BasicCAD, IRutaCAD
{
public RutaCAD() : base ()
{
}

public RutaCAD(ISession sessionAux) : base (sessionAux)
{
}



public RutaEN ReadOIDDefault (string nombre)
{
        RutaEN rutaEN = null;

        try
        {
                SessionInitializeTransaction ();
                rutaEN = (RutaEN)session.Get (typeof(RutaEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rutaEN;
}

public System.Collections.Generic.IList<RutaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RutaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RutaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RutaEN>();
                        else
                                result = session.CreateCriteria (typeof(RutaEN)).List<RutaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }

        return result;
}

public string CrearRuta (RutaEN ruta)
{
        try
        {
                SessionInitializeTransaction ();
                if (ruta.Sitio != null) {
                        for (int i = 0; i < ruta.Sitio.Count; i++) {
                                ruta.Sitio [i] = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), ruta.Sitio [i].Nombre);
                                ruta.Sitio [i].Ruta.Add (ruta);
                        }
                }
                if (ruta.Usuario != null) {
                        // Argumento OID y no colección.
                        ruta.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), ruta.Usuario.NomUsu);

                        ruta.Usuario.Ruta
                        .Add (ruta);
                }

                session.Save (ruta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ruta.Nombre;
}

public void EliminarRuta (string nombre)
{
        try
        {
                SessionInitializeTransaction ();
                RutaEN rutaEN = (RutaEN)session.Load (typeof(RutaEN), nombre);
                session.Delete (rutaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void ModificarRuta (RutaEN ruta)
{
        try
        {
                SessionInitializeTransaction ();
                RutaEN rutaEN = (RutaEN)session.Load (typeof(RutaEN), ruta.Nombre);

                rutaEN.Descripcion = ruta.Descripcion;


                rutaEN.Provincia = ruta.Provincia;


                rutaEN.Puntuacion = ruta.Puntuacion;


                rutaEN.NumPuntuados = ruta.NumPuntuados;


                rutaEN.FechaCreacion = ruta.FechaCreacion;


                rutaEN.PuntuacionMedia = ruta.PuntuacionMedia;

                session.Update (rutaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> DevuelveRutasOrdenadasPorFecha ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RutaEN self where FROM RutaEN ruta order by ruta.FechaCreacion desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RutaENDevuelveRutasOrdenadasPorFechaHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public TravelnookGenNHibernate.EN.Travelnook.RutaEN DevuelveRutaPorNombre (string p_nombre)
{
        TravelnookGenNHibernate.EN.Travelnook.RutaEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RutaEN self where FROM RutaEN as r where r.Nombre like '%'+ :p_nombre+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RutaENDevuelveRutaPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);


                result = query.UniqueResult<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<RutaEN> MostrarRutas (int first, int size)
{
        System.Collections.Generic.IList<RutaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RutaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RutaEN>();
                else
                        result = session.CreateCriteria (typeof(RutaEN)).List<RutaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in RutaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
