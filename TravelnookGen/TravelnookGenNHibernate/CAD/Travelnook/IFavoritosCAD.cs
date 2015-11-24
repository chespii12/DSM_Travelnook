
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IFavoritosCAD
{
FavoritosEN ReadOIDDefault (int id);

void EliminarFavorito (int id);


void AnyadirRutaFavoritos (int p_Favoritos_OID, string p_ruta_OID);

void AnyadirSitioFavoritos (int p_Favoritos_OID, string p_sitio_OID);

System.Collections.Generic.IList<FavoritosEN> DevuelveFavoritos (int first, int size);


void DevuelveSitiosFavoritos (int p_Favoritos_OID, System.Collections.Generic.IList<string> p_sitio_OID);

void DevuelveRutasFavoritas (int p_Favoritos_OID, System.Collections.Generic.IList<string> p_ruta_OID);

int CrearFavorito (FavoritosEN favoritos);

void DevuelveEventosFavoritos (int p_Favoritos_OID, System.Collections.Generic.IList<int> p_evento_OID);

void AnyadirEventoFavoritos (int p_Favoritos_OID, int p_evento_OID);

FavoritosEN DevuelveFavoritoPorId (int id);
}
}
