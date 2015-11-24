
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
 * Clase Favorito:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class FavoritoCAD : BasicCAD, IFavoritoCAD
{
public FavoritoCAD() : base ()
{
}

public FavoritoCAD(ISession sessionAux) : base (sessionAux)
{
}



public FavoritoEN ReadOIDDefault (int id)
{
        FavoritoEN favoritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Get (typeof(FavoritoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoEN;
}

public System.Collections.Generic.IList<FavoritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoEN)).List<FavoritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }

        return result;
}

public void EliminarFavorito (int id)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoEN favoritoEN = (FavoritoEN)session.Load (typeof(FavoritoEN), id);
                session.Delete (favoritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirRutaFavoritos (int p_Favorito_OID, string p_ruta_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritoEN favoritoEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Load (typeof(FavoritoEN), p_Favorito_OID);
                favoritoEN.Ruta = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), p_ruta_OID);

                favoritoEN.Ruta.Favorito.Add (favoritoEN);



                session.Update (favoritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirSitioFavoritos (int p_Favorito_OID, string p_sitio_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritoEN favoritoEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Load (typeof(FavoritoEN), p_Favorito_OID);
                favoritoEN.Sitio = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), p_sitio_OID);

                favoritoEN.Sitio.Favorito.Add (favoritoEN);



                session.Update (favoritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<FavoritoEN> DevuelveFavoritos (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritoEN)).List<FavoritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosFavoritos ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FavoritoEN self where select (sitio) FROM FavoritoEN as fav inner join fav.Sitio as sitio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FavoritoENDevuelveSitiosFavoritosHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> DevuelveRutasFavoritas ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FavoritoEN self where select (ruta) FROM FavoritoEN as fav inner join fav.Ruta as ruta";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FavoritoENDevuelveRutasFavoritasHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int CrearFavorito (FavoritoEN favorito)
{
        try
        {
                SessionInitializeTransaction ();
                if (favorito.Usuario != null) {
                        // Argumento OID y no colección.
                        favorito.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), favorito.Usuario.NomUsu);

                        favorito.Usuario.Favorito
                        .Add (favorito);
                }

                session.Save (favorito);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favorito.Id;
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> DevuelveEventosFavoritos ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FavoritoEN self where select (evento) FROM FavoritoEN  as fav inner join fav.Evento as evento";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FavoritoENDevuelveEventosFavoritosHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnyadirEventoFavoritos (int p_Favorito_OID, int p_evento_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritoEN favoritoEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Load (typeof(FavoritoEN), p_Favorito_OID);
                favoritoEN.Evento = (TravelnookGenNHibernate.EN.Travelnook.EventoEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.EventoEN), p_evento_OID);

                favoritoEN.Evento.Favorito.Add (favoritoEN);



                session.Update (favoritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DevuelveFavoritoPorId
//Con e: FavoritoEN
public FavoritoEN DevuelveFavoritoPorId (int id)
{
        FavoritoEN favoritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Get (typeof(FavoritoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoEN;
}
}
}
