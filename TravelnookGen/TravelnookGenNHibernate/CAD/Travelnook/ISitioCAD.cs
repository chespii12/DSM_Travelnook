
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface ISitioCAD
{
SitioEN ReadOIDDefault (string nombre);

string CrearSitio (SitioEN sitio);

void BorrarSitio (string nombre);



void ModificarSitio (SitioEN sitio);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosOrdenadosPorFecha ();


TravelnookGenNHibernate.EN.Travelnook.SitioEN DevuelveSitioPorNombre (string p_nombre);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosPorTipo (TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipositio);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosPorActividad (System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> p_actividades);



System.Collections.Generic.IList<SitioEN> DevuelveSitios (int first, int size);
}
}
