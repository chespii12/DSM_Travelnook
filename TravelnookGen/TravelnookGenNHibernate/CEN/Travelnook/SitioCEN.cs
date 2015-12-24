

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
 *      Definition of the class SitioCEN
 *
 */
public partial class SitioCEN
{
private ISitioCAD _ISitioCAD;

public SitioCEN()
{
        this._ISitioCAD = new SitioCAD ();
}

public SitioCEN(ISitioCAD _ISitioCAD)
{
        this._ISitioCAD = _ISitioCAD;
}

public ISitioCAD get_ISitioCAD ()
{
        return this._ISitioCAD;
}

public string CrearSitio (string p_nombre, string p_provincia, string p_descripcion, int p_puntuacion, System.Collections.Generic.IList<string> p_fotos, string p_usuario, System.Collections.Generic.IList<string> p_videos, string p_localizacion, Nullable<DateTime> p_fechaCreacion, int p_numPuntuados, int p_puntuacionMedia, TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipoSitio, System.Collections.Generic.IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> p_actividades)
{
        SitioEN sitioEN = null;
        string oid;

        //Initialized SitioEN
        sitioEN = new SitioEN ();
        sitioEN.Nombre = p_nombre;

        sitioEN.Provincia = p_provincia;

        sitioEN.Descripcion = p_descripcion;

        sitioEN.Puntuacion = p_puntuacion;

        sitioEN.Fotos = p_fotos;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids nombre
                sitioEN.Usuario = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                sitioEN.Usuario.NomUsu = p_usuario;
        }

        sitioEN.Videos = p_videos;

        sitioEN.Localizacion = p_localizacion;

        sitioEN.FechaCreacion = p_fechaCreacion;

        sitioEN.NumPuntuados = p_numPuntuados;

        sitioEN.PuntuacionMedia = p_puntuacionMedia;

        sitioEN.TipoSitio = p_tipoSitio;


        sitioEN.Actividades = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ActividadEN>();
        if (p_actividades != null) {
                foreach (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum item in p_actividades) {
                        TravelnookGenNHibernate.EN.Travelnook.ActividadEN en = new TravelnookGenNHibernate.EN.Travelnook.ActividadEN ();
                        en.Tipo = item;
                        sitioEN.Actividades.Add (en);
                }
        }

        else{
                sitioEN.Actividades = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ActividadEN>();
        }

        //Call to SitioCAD

        oid = _ISitioCAD.CrearSitio (sitioEN);
        return oid;
}

public void BorrarSitio (string nombre)
{
        _ISitioCAD.BorrarSitio (nombre);
}

public void ModificarSitio (string p_Sitio_OID, string p_provincia, string p_descripcion, int p_puntuacion, System.Collections.Generic.IList<string> p_fotos, System.Collections.Generic.IList<string> p_videos, string p_localizacion, Nullable<DateTime> p_fechaCreacion, int p_numPuntuados, int p_puntuacionMedia, TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipoSitio)
{
        SitioEN sitioEN = null;

        //Initialized SitioEN
        sitioEN = new SitioEN ();
        sitioEN.Nombre = p_Sitio_OID;
        sitioEN.Provincia = p_provincia;
        sitioEN.Descripcion = p_descripcion;
        sitioEN.Puntuacion = p_puntuacion;
        sitioEN.Fotos = p_fotos;
        sitioEN.Videos = p_videos;
        sitioEN.Localizacion = p_localizacion;
        sitioEN.FechaCreacion = p_fechaCreacion;
        sitioEN.NumPuntuados = p_numPuntuados;
        sitioEN.PuntuacionMedia = p_puntuacionMedia;
        sitioEN.TipoSitio = p_tipoSitio;
        //Call to SitioCAD

        _ISitioCAD.ModificarSitio (sitioEN);
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosOrdenadosPorFecha ()
{
        return _ISitioCAD.DevuelveSitiosOrdenadosPorFecha ();
}
public TravelnookGenNHibernate.EN.Travelnook.SitioEN DevuelveSitioPorNombre (string p_nombre)
{
        return _ISitioCAD.DevuelveSitioPorNombre (p_nombre);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosPorTipo (TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipositio)
{
        return _ISitioCAD.DevuelveSitiosPorTipo (p_tipositio);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> DevuelveSitiosPorActividad (System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> p_actividades)
{
        return _ISitioCAD.DevuelveSitiosPorActividad (p_actividades);
}
public System.Collections.Generic.IList<SitioEN> DevuelveSitios (int first, int size)
{
        System.Collections.Generic.IList<SitioEN> list = null;

        list = _ISitioCAD.DevuelveSitios (first, size);
        return list;
}
public void BorrarActividades (string p_Sitio_OID, System.Collections.Generic.IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> p_actividades_OIDs)
{
        //Call to SitioCAD

        _ISitioCAD.BorrarActividades (p_Sitio_OID, p_actividades_OIDs);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> BusarSitiosPorNombre (string arg0)
{
        return _ISitioCAD.BusarSitiosPorNombre (arg0);
}
}
}
