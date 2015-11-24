
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email);


string New_ (AdministradorEN administrador);

TravelnookGenNHibernate.EN.Travelnook.AdministradorEN DevuelveAdminPorEmail (string p_email);
}
}
