
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IRutaCAD
{
RutaEN ReadOIDDefault (string nombre);

string CrearRuta (RutaEN ruta);

void EliminarRuta (string nombre);


void ModificarRuta (RutaEN ruta);



System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> DevuelveRutasOrdenadasPorFecha ();


TravelnookGenNHibernate.EN.Travelnook.RutaEN DevuelveRutaPorNombre (string p_nombre);


System.Collections.Generic.IList<RutaEN> MostrarRutas (int first, int size);
}
}
