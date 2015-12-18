
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
 * Clase Comentario:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class ComentarioCAD : BasicCAD, IComentarioCAD
{
public ComentarioCAD() : base ()
{
}

public ComentarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentarioEN ReadOIDDefault (int id)
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }

        return result;
}

public int CrearComentario (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Usuario != null) {
                        // Argumento OID y no colección.
                        comentario.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), comentario.Usuario.NomUsu);

                        comentario.Usuario.Comentario
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.Id;
}

public void EliminarComentario (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), id);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DevuelveComentarioPorID
//Con e: ComentarioEN
public ComentarioEN DevuelveComentarioPorID (int id)
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public void AsignarSitio (int p_Comentario_OID, string p_sitio_OID)
{
        TravelnookGenNHibernate.EN.Travelnook.ComentarioEN comentarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), p_Comentario_OID);
                comentarioEN.Sitio = (TravelnookGenNHibernate.EN.Travelnook.SitioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.SitioEN), p_sitio_OID);

                comentarioEN.Sitio.Comentarios.Add (comentarioEN);



                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarRuta (int p_Comentario_OID, System.Collections.Generic.IList<string> p_ruta_OIDs)
{
        TravelnookGenNHibernate.EN.Travelnook.ComentarioEN comentarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), p_Comentario_OID);
                TravelnookGenNHibernate.EN.Travelnook.RutaEN rutaENAux = null;
                if (comentarioEN.Ruta == null) {
                        comentarioEN.Ruta = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
                }

                foreach (string item in p_ruta_OIDs) {
                        rutaENAux = new TravelnookGenNHibernate.EN.Travelnook.RutaEN ();
                        rutaENAux = (TravelnookGenNHibernate.EN.Travelnook.RutaEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.RutaEN), item);
                        rutaENAux.Comentarios.Add (comentarioEN);

                        comentarioEN.Ruta.Add (rutaENAux);
                }


                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
