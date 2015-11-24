
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IEventoCAD
{
EventoEN ReadOIDDefault (int id);

int CrearEvento (EventoEN evento);

void ModificarEvento (EventoEN evento);


void BorrarEvento (int id);


void InvitarAmigos (int p_Evento_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> DevuelveEventoPorTitulo (string p_titulo);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> EventosPorMayorNumAsistentes (int first, int size);


System.Collections.Generic.IList<EventoEN> MostrarEventos (int first, int size);


EventoEN DevueleEventoPorId (int id);
}
}
