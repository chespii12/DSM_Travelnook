
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IPeticiónCAD
{
PeticiónEN ReadOIDDefault (int id);

int EnviarSolicitud (PeticiónEN petición);

void CancelarSolicitud (int id);


System.Collections.Generic.IList<PeticiónEN> DevuelvePeticiones (int first, int size);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> DevuelvePeticionesPorSolicitante ();


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.PeticiónEN> DevuelvePeticionesPorSolicitado ();
}
}
