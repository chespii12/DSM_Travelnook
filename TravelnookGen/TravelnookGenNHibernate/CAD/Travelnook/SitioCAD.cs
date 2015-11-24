
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
 * Clase Sitio:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class SitioCAD : BasicCAD, ISitioCAD
{
public SitioCAD() : base ()
{
}

public SitioCAD(ISession sessionAux) : base (sessionAux)
{
}



public SitioEN ReadOIDDefault (string nombre)
{
        SitioEN sitioEN = null;

        try
        {
                SessionInitializeTransaction ();
                sitioEN = (SitioEN)session.Get (typeof(SitioEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sitioEN;
}

public System.Collections.Generic.IList<SitioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SitioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SitioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SitioEN>();
                        else
                                result = session.CreateCriteria (typeof(SitioEN)).List<SitioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }

        return result;
}

public string CrearSitio (SitioEN sitio)
{
        try
        {
                SessionInitializeTransaction ();
                if (sitio.Usuario != null) {
                        // Argumento OID y no colección.
                        sitio.Usuario = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), sitio.Usuario.NomUsu);

                        sitio.Usuario.Sitio
                        .Add (sitio);
                }
                if (sitio.Actividades != null) {
                        for (int i = 0; i < sitio.Actividades.Count; i++) {
                                sitio.Actividades [i] = (TravelnookGenNHibernate.EN.Travelnook.ActividadEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.ActividadEN), sitio.Actividades [i].Tipo);
                                sitio.Actividades [i].Sitio.Add (sitio);
                        }
                }

                session.Save (sitio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sitio.Nombre;
}

public void BorrarSitio (string nombre)
{
        try
        {
                SessionInitializeTransaction ();
                SitioEN sitioEN = (SitioEN)session.Load (typeof(SitioEN), nombre);
                session.Delete (sitioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void ModificarSitio (SitioEN sitio)
{
        try
        {
                SessionInitializeTransaction ();
                SitioEN sitioEN = (SitioEN)session.Load (typeof(SitioEN), sitio.Nombre);

                sitioEN.Provincia = sitio.Provincia;


                sitioEN.Descripcion = sitio.Descripcion;


                sitioEN.Puntuacion = sitio.Puntuacion;


                sitioEN.Localizacion = sitio.Localizacion;


                sitioEN.FechaCreacion = sitio.FechaCreacion;


                sitioEN.NumPuntuados = sitio.NumPuntuados;


                sitioEN.PuntuacionMedia = sitio.PuntuacionMedia;


                sitioEN.TipoSitio = sitio.TipoSitio;

                session.Update (sitioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosOrdenadosPorFecha ()
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SitioEN self where FROM SitioEN sitio order by sitio.FechaCreacion asc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SitioENDevuelveSitiosOrdenadosPorFechaHQL");

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public TravelnookGenNHibernate.EN.Travelnook.SitioEN DevuelveSitioPorNombre (string p_nombre)
{
        TravelnookGenNHibernate.EN.Travelnook.SitioEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SitioEN self where FROM SitioEN sitio where sitio.Nombre like :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SitioENDevuelveSitioPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);


                result = query.UniqueResult<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosPorTipo (TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipositio)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SitioEN self where FROM SitioEN sitio where sitio.TipoSitio like :p_tipositio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SitioENDevuelveSitiosPorTipoHQL");
                query.SetParameter ("p_tipositio", p_tipositio);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosPorActividad (System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> p_actividades)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SitioEN self where FROM SitioEN sitio where sitio.Actividades like  :p_actividades";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SitioENDevuelveSitiosPorActividadHQL");
                query.SetParameter ("p_actividades", p_actividades);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> BuscarSitio (string p_nombre, string p_provincia, TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipo, System.Collections.Generic.IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> p_actividades, int p_puntuacion)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SitioEN self where FROM SitioEN sitio where (:p_nombre is null or sitio.Nombre = :p_nombre) and (:p_provincia is null or sitio.Provincia = :p_provincia) and (:p_puntuacion = -1 or sitio.PuntuacionMedia = :p_puntuacion) and (:p_tipo = -1 or sitio.TipoSitio = :p_tipo) and (:p_actividades is null or sitio.Actividades = :p_actividades)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SitioENbuscarSitioHQL");
                query.SetParameter ("p_nombre", p_nombre);
                query.SetParameter ("p_provincia", p_provincia);
                query.SetParameter ("p_tipo", p_tipo);
                query.SetParameter ("p_actividades", p_actividades);
                query.SetParameter ("p_puntuacion", p_puntuacion);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in SitioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
