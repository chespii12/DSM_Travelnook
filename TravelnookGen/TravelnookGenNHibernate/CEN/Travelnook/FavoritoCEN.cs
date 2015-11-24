

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
 *      Definition of the class FavoritoCEN
 *
 */
public partial class FavoritoCEN
{
private IFavoritoCAD _IFavoritoCAD;

public FavoritoCEN()
{
        this._IFavoritoCAD = new FavoritoCAD ();
}

public FavoritoCEN(IFavoritoCAD _IFavoritoCAD)
{
        this._IFavoritoCAD = _IFavoritoCAD;
}

public IFavoritoCAD get_IFavoritoCAD ()
{
        return this._IFavoritoCAD;
}

public void EliminarFavorito (int id)
{
        _IFavoritoCAD.EliminarFavorito (id);
}

public void AnyadirRutaFavoritos (int p_Favorito_OID, string p_ruta_OID)
{
        //Call to FavoritoCAD

        _IFavoritoCAD.AnyadirRutaFavoritos (p_Favorito_OID, p_ruta_OID);
}
public void AnyadirSitioFavoritos (int p_Favorito_OID, string p_sitio_OID)
{
        //Call to FavoritoCAD

        _IFavoritoCAD.AnyadirSitioFavoritos (p_Favorito_OID, p_sitio_OID);
}
public System.Collections.Generic.IList<FavoritoEN> DevuelveFavoritos (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> list = null;

        list = _IFavoritoCAD.DevuelveFavoritos (first, size);
        return list;
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosFavoritos ()
{
        return _IFavoritoCAD.DevuelveSitiosFavoritos ();
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> DevuelveRutasFavoritas ()
{
        return _IFavoritoCAD.DevuelveRutasFavoritas ();
}
public int CrearFavorito (string p_usuario)
{
        FavoritoEN favoritoEN = null;
        int oid;

        //Initialized FavoritoEN
        favoritoEN = new FavoritoEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                favoritoEN.Usuario = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                favoritoEN.Usuario.NomUsu = p_usuario;
        }

        //Call to FavoritoCAD

        oid = _IFavoritoCAD.CrearFavorito (favoritoEN);
        return oid;
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> DevuelveEventosFavoritos ()
{
        return _IFavoritoCAD.DevuelveEventosFavoritos ();
}
public void AnyadirEventoFavoritos (int p_Favorito_OID, int p_evento_OID)
{
        //Call to FavoritoCAD

        _IFavoritoCAD.AnyadirEventoFavoritos (p_Favorito_OID, p_evento_OID);
}
public FavoritoEN DevuelveFavoritoPorId (int id)
{
        FavoritoEN favoritoEN = null;

        favoritoEN = _IFavoritoCAD.DevuelveFavoritoPorId (id);
        return favoritoEN;
}
}
}
