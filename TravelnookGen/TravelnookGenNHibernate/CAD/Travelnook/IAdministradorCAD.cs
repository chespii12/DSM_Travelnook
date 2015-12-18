
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string nomUsu);


string New_ (AdministradorEN administrador);

void Destroy (string nomUsu);


AdministradorEN DevuelveAdminPorNombre (string nomUsu);
}
}
