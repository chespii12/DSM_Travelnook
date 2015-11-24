

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
 *      Definition of the class FavoritosCEN
 *
 */
public partial class FavoritosCEN
{
private IFavoritosCAD _IFavoritosCAD;

public FavoritosCEN()
{
        this._IFavoritosCAD = new FavoritosCAD ();
}

public FavoritosCEN(IFavoritosCAD _IFavoritosCAD)
{
        this._IFavoritosCAD = _IFavoritosCAD;
}

public IFavoritosCAD get_IFavoritosCAD ()
{
        return this._IFavoritosCAD;
}

public void EliminarFavorito (int id)
{
        _IFavoritosCAD.EliminarFavorito (id);
}

public void AnyadirRutaFavoritos (int p_Favoritos_OID, string p_ruta_OID)
{
        //Call to FavoritosCAD

        _IFavoritosCAD.AnyadirRutaFavoritos (p_Favoritos_OID, p_ruta_OID);
}
public void AnyadirSitioFavoritos (int p_Favoritos_OID, string p_sitio_OID)
{
        //Call to FavoritosCAD

        _IFavoritosCAD.AnyadirSitioFavoritos (p_Favoritos_OID, p_sitio_OID);
}
public System.Collections.Generic.IList<FavoritosEN> DevuelveFavoritos (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> list = null;

        list = _IFavoritosCAD.DevuelveFavoritos (first, size);
        return list;
}
public void DevuelveSitiosFavoritos (int p_Favoritos_OID, System.Collections.Generic.IList<string> p_sitio_OID)
{
        //Call to FavoritosCAD

        _IFavoritosCAD.DevuelveSitiosFavoritos (p_Favoritos_OID, p_sitio_OID);
}
public void DevuelveRutasFavoritas (int p_Favoritos_OID, System.Collections.Generic.IList<string> p_ruta_OID)
{
        //Call to FavoritosCAD

        _IFavoritosCAD.DevuelveRutasFavoritas (p_Favoritos_OID, p_ruta_OID);
}
public int CrearFavorito (string p_usuario)
{
        FavoritosEN favoritosEN = null;
        int oid;

        //Initialized FavoritosEN
        favoritosEN = new FavoritosEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                favoritosEN.Usuario = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                favoritosEN.Usuario.Email = p_usuario;
        }

        //Call to FavoritosCAD

        oid = _IFavoritosCAD.CrearFavorito (favoritosEN);
        return oid;
}

public void DevuelveEventosFavoritos (int p_Favoritos_OID, System.Collections.Generic.IList<int> p_evento_OID)
{
        //Call to FavoritosCAD

        _IFavoritosCAD.DevuelveEventosFavoritos (p_Favoritos_OID, p_evento_OID);
}
public void AnyadirEventoFavoritos (int p_Favoritos_OID, int p_evento_OID)
{
        //Call to FavoritosCAD

        _IFavoritosCAD.AnyadirEventoFavoritos (p_Favoritos_OID, p_evento_OID);
}
public FavoritosEN DevuelveFavoritoPorId (int id)
{
        FavoritosEN favoritosEN = null;

        favoritosEN = _IFavoritosCAD.DevuelveFavoritoPorId (id);
        return favoritosEN;
}
}
}
