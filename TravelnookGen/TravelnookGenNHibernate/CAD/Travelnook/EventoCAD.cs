
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
 * Clase Evento:
 *
 */

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial class EventoCAD : BasicCAD, IEventoCAD
{
public EventoCAD() : base ()
{
}

public EventoCAD(ISession sessionAux) : base (sessionAux)
{
}



public EventoEN ReadOIDDefault (int id)
{
        EventoEN eventoEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoEN = (EventoEN)session.Get (typeof(EventoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoEN;
}

public System.Collections.Generic.IList<EventoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EventoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EventoEN>();
                        else
                                result = session.CreateCriteria (typeof(EventoEN)).List<EventoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }

        return result;
}

public int CrearEvento (EventoEN evento)
{
        try
        {
                SessionInitializeTransaction ();
                if (evento.Organizador != null) {
                        // Argumento OID y no colección.
                        evento.Organizador = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), evento.Organizador.NomUsu);

                        evento.Organizador.Evento
                        .Add (evento);
                }

                session.Save (evento);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evento.Id;
}

public void ModificarEvento (EventoEN evento)
{
        try
        {
                SessionInitializeTransaction ();
                EventoEN eventoEN = (EventoEN)session.Load (typeof(EventoEN), evento.Id);

                eventoEN.Titulo = evento.Titulo;


                eventoEN.Descripcion = evento.Descripcion;


                eventoEN.Asistentes = evento.Asistentes;


                eventoEN.Quizas = evento.Quizas;


                eventoEN.Rechazados = evento.Rechazados;

                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarEvento (int id)
{
        try
        {
                SessionInitializeTransaction ();
                EventoEN eventoEN = (EventoEN)session.Load (typeof(EventoEN), id);
                session.Delete (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void InvitarAmigos (int p_Evento_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        TravelnookGenNHibernate.EN.Travelnook.EventoEN eventoEN = null;
        try
        {
                SessionInitializeTransaction ();
                eventoEN = (EventoEN)session.Load (typeof(EventoEN), p_Evento_OID);
                TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuarioENAux = null;
                if (eventoEN.Usuario == null) {
                        eventoEN.Usuario = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                        usuarioENAux = (TravelnookGenNHibernate.EN.Travelnook.UsuarioEN)session.Load (typeof(TravelnookGenNHibernate.EN.Travelnook.UsuarioEN), item);
                        usuarioENAux.Invitado.Add (eventoEN);

                        eventoEN.Usuario.Add (usuarioENAux);
                }


                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> DevuelveEventoPorTitulo (string p_titulo)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventoEN self where FROM EventoEN as e where e.Titulo like '%'+:p_titulo+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventoENdevuelveEventoPorTituloHQL");
                query.SetParameter ("p_titulo", p_titulo);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> EventosPorMayorNumAsistentes (int first, int size)
{
        System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventoEN self where FROM EventoEN ev order by ev.Asistentes desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventoENEventosPorMayorNumAsistentesHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<EventoEN> MostrarEventos (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EventoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EventoEN>();
                else
                        result = session.CreateCriteria (typeof(EventoEN)).List<EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DevueleEventoPorId
//Con e: EventoEN
public EventoEN DevueleEventoPorId (int id)
{
        EventoEN eventoEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoEN = (EventoEN)session.Get (typeof(EventoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoEN;
}
}
}
