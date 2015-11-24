
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
 * Clase Favoritos:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class FavoritosCAD : BasicCAD, IFavoritosCAD
{
public FavoritosCAD() : base ()
{
}

public FavoritosCAD(ISession sessionAux) : base (sessionAux)
{
}



public FavoritosEN ReadOIDDefault (int id)
{
        FavoritosEN favoritosEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Get (typeof(FavoritosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritosEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritosEN)).List<FavoritosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }

        return result;
}

public void EliminarFavorito (int id)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosEN favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), id);
                session.Delete (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirRutaFavoritos (int p_Favoritos_OID, string p_ruta_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritosEN favoritosEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), p_Favoritos_OID);
                favoritosEN.Ruta = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), p_ruta_OID);

                favoritosEN.Ruta.Favorito.Add (favoritosEN);



                session.Update (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirSitioFavoritos (int p_Favoritos_OID, string p_sitio_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritosEN favoritosEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), p_Favoritos_OID);
                favoritosEN.Sitio = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), p_sitio_OID);

                favoritosEN.Sitio.Favorito.Add (favoritosEN);



                session.Update (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<FavoritosEN> DevuelveFavoritos (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritosEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritosEN)).List<FavoritosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void DevuelveSitiosFavoritos (int p_Favoritos_OID, System.Collections.Generic.IList<string> p_sitio_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritosEN favoritosEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), p_Favoritos_OID);
                TravelnookGenNHibernate.EN.Travelnook.SitioEN sitioENAux = null;
                if (favoritosEN.Sitio == null) {
                        favoritosEN.Sitio = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                }

                foreach (string item in p_sitio_OID) {
                        sitioENAux = new TravelnookGenNHibernate.EN.Travelnook.SitioEN ();
                        sitioENAux = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), item);
                        sitioENAux.Favorito.Add (favoritosEN);

                        favoritosEN.Sitio.Add (sitioENAux);
                }


                session.Update (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DevuelveRutasFavoritas (int p_Favoritos_OID, System.Collections.Generic.IList<string> p_ruta_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritosEN favoritosEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), p_Favoritos_OID);
                TravelnookGenNHibernate.EN.Travelnook.RutaEN rutaENAux = null;
                if (favoritosEN.Ruta == null) {
                        favoritosEN.Ruta = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
                }

                foreach (string item in p_ruta_OID) {
                        rutaENAux = new TravelnookGenNHibernate.EN.Travelnook.RutaEN ();
                        rutaENAux = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), item);
                        rutaENAux.Favorito.Add (favoritosEN);

                        favoritosEN.Ruta.Add (rutaENAux);
                }


                session.Update (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int CrearFavorito (FavoritosEN favoritos)
{
        try
        {
                SessionInitializeTransaction ();
                if (favoritos.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritos.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), favoritos.Usuario.Email);

                        favoritos.Usuario.Favorito
                        .Add (favoritos);
                }

                session.Save (favoritos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritos.Id;
}

public void DevuelveEventosFavoritos (int p_Favoritos_OID, System.Collections.Generic.IList<int> p_evento_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritosEN favoritosEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), p_Favoritos_OID);
                TravelnookGenNHibernate.EN.Travelnook.EventoEN eventoENAux = null;
                if (favoritosEN.Evento == null) {
                        favoritosEN.Evento = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.EventoEN>();
                }

                foreach (int item in p_evento_OID) {
                        eventoENAux = new TravelnookGenNHibernate.EN.Travelnook.EventoEN ();
                        eventoENAux = (TravelnookGenNHibernate.EN.Travelnook.EventoEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.EventoEN), item);
                        eventoENAux.Favorito.Add (favoritosEN);

                        favoritosEN.Evento.Add (eventoENAux);
                }


                session.Update (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirEventoFavoritos (int p_Favoritos_OID, int p_evento_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.FavoritosEN favoritosEN = null;
        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Load (typeof(FavoritosEN), p_Favoritos_OID);
                favoritosEN.Evento = (TravelnookGenNHibernate.EN.Travelnook.EventoEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.EventoEN), p_evento_OID);

                favoritosEN.Evento.Favorito.Add (favoritosEN);



                session.Update (favoritosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DevuelveFavoritoPorId
//Con e: FavoritosEN
public FavoritosEN DevuelveFavoritoPorId (int id)
{
        FavoritosEN favoritosEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Get (typeof(FavoritosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in FavoritosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritosEN;
}
}
}
