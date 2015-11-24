
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IFavoritoCAD
{
FavoritoEN ReadOIDDefault (int id);

void EliminarFavorito (int id);


void AnyadirRutaFavoritos (int p_Favorito_OID, string p_ruta_OID);

void AnyadirSitioFavoritos (int p_Favorito_OID, string p_sitio_OID);

System.Collections.Generic.IList<FavoritoEN> DevuelveFavoritos (int first, int size);


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosFavoritos ();


System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> DevuelveRutasFavoritas ();


int CrearFavorito (FavoritoEN favorito);

System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> DevuelveEventosFavoritos ();


void AnyadirEventoFavoritos (int p_Favorito_OID, int p_evento_OID);

FavoritoEN DevuelveFavoritoPorId (int id);
}
}
