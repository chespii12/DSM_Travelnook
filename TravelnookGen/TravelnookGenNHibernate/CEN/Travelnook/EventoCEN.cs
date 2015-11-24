

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;

namespace TravelnookGenNHibernate.CEN.Travelnook
{
/*
 *      Definition of the class EventoCEN
 *
 */
public partial class EventoCEN
{
private IEventoCAD _IEventoCAD;

public EventoCEN()
{
        this._IEventoCAD = new EventoCAD ();
}

public EventoCEN(IEventoCAD _IEventoCAD)
{
        this._IEventoCAD = _IEventoCAD;
}

public IEventoCAD get_IEventoCAD ()
{
        return this._IEventoCAD;
}

public int CrearEvento (string p_titulo, string p_descripcion, string p_organizador, int p_asistentes, int p_quizas, int p_rechazados)
{
        EventoEN eventoEN = null;
        int oid;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Titulo = p_titulo;

        eventoEN.Descripcion = p_descripcion;


        if (p_organizador != null) {
                // El argumento p_organizador -> Property organizador es oid = false
                // Lista de oids id
                eventoEN.Organizador = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                eventoEN.Organizador.NomUsu = p_organizador;
        }

        eventoEN.Asistentes = p_asistentes;

        eventoEN.Quizas = p_quizas;

        eventoEN.Rechazados = p_rechazados;

        //Call to EventoCAD

        oid = _IEventoCAD.CrearEvento (eventoEN);
        return oid;
}

public void ModificarEvento (int p_Evento_OID, string p_titulo, string p_descripcion, int p_asistentes, int p_quizas, int p_rechazados)
{
        EventoEN eventoEN = null;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Id = p_Evento_OID;
        eventoEN.Titulo = p_titulo;
        eventoEN.Descripcion = p_descripcion;
        eventoEN.Asistentes = p_asistentes;
        eventoEN.Quizas = p_quizas;
        eventoEN.Rechazados = p_rechazados;
        //Call to EventoCAD

        _IEventoCAD.ModificarEvento (eventoEN);
}

public void BorrarEvento (int id)
{
        _IEventoCAD.BorrarEvento (id);
}

public void InvitarAmigos (int p_Evento_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        //Call to EventoCAD

        _IEventoCAD.InvitarAmigos (p_Evento_OID, p_usuario_OIDs);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> DevuelveEventoPorTitulo (string p_titulo)
{
        return _IEventoCAD.DevuelveEventoPorTitulo (p_titulo);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> EventosPorMayorNumAsistentes (int first, int size)
{
        return _IEventoCAD.EventosPorMayorNumAsistentes (first, size);
}
public System.Collections.Generic.IList<EventoEN> MostrarEventos (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> list = null;

        list = _IEventoCAD.MostrarEventos (first, size);
        return list;
}
public EventoEN DevueleEventoPorId (int id)
{
        EventoEN eventoEN = null;

        eventoEN = _IEventoCAD.DevueleEventoPorId (id);
        return eventoEN;
}
}
}
