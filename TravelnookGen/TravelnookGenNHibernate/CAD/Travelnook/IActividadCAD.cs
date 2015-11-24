
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IActividadCAD
{
ActividadEN ReadOIDDefault (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo);

TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum New_ (ActividadEN actividad);

void Modify (ActividadEN actividad);


void Destroy (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo);
}
}
