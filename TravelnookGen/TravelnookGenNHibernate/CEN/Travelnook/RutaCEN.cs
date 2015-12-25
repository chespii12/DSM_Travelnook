

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
 *      Definition of the class RutaCEN
 *
 */
public partial class RutaCEN
{
private IRutaCAD _IRutaCAD;

public RutaCEN()
{
        this._IRutaCAD = new RutaCAD ();
}

public RutaCEN(IRutaCAD _IRutaCAD)
{
        this._IRutaCAD = _IRutaCAD;
}

public IRutaCAD get_IRutaCAD ()
{
        return this._IRutaCAD;
}

public string CrearRuta (string p_nombre, string p_descripcion, string p_provincia, System.Collections.Generic.IList<string> p_sitio, int p_puntuacion, int p_numPuntuados, Nullable<DateTime> p_fechaCreacion, int p_puntuacionMedia, string p_usuario)
{
        RutaEN rutaEN = null;
        string oid;

        //Initialized RutaEN
        rutaEN = new RutaEN ();
        rutaEN.Nombre = p_nombre;

        rutaEN.Descripcion = p_descripcion;

        rutaEN.Provincia = p_provincia;


        rutaEN.Sitio = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
        if (p_sitio != null) {
                foreach (string item in p_sitio) {
                        TravelnookGenNHibernate.EN.Travelnook.SitioEN en = new TravelnookGenNHibernate.EN.Travelnook.SitioEN ();
                        en.Nombre = item;
                        rutaEN.Sitio.Add (en);
                }
        }

        else{
                rutaEN.Sitio = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
        }

        rutaEN.Puntuacion = p_puntuacion;

        rutaEN.NumPuntuados = p_numPuntuados;

        rutaEN.FechaCreacion = p_fechaCreacion;

        rutaEN.PuntuacionMedia = p_puntuacionMedia;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids nombre
                rutaEN.Usuario = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                rutaEN.Usuario.NomUsu = p_usuario;
        }

        //Call to RutaCAD

        oid = _IRutaCAD.CrearRuta (rutaEN);
        return oid;
}

public void EliminarRuta (string nombre)
{
        _IRutaCAD.EliminarRuta (nombre);
}

public void ModificarRuta (string p_Ruta_OID, string p_descripcion, string p_provincia, int p_puntuacion, int p_numPuntuados, Nullable<DateTime> p_fechaCreacion, int p_puntuacionMedia)
{
        RutaEN rutaEN = null;

        //Initialized RutaEN
        rutaEN = new RutaEN ();
        rutaEN.Nombre = p_Ruta_OID;
        rutaEN.Descripcion = p_descripcion;
        rutaEN.Provincia = p_provincia;
        rutaEN.Puntuacion = p_puntuacion;
        rutaEN.NumPuntuados = p_numPuntuados;
        rutaEN.FechaCreacion = p_fechaCreacion;
        rutaEN.PuntuacionMedia = p_puntuacionMedia;
        //Call to RutaCAD

        _IRutaCAD.ModificarRuta (rutaEN);
}

public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> DevuelveRutasOrdenadasPorFecha ()
{
        return _IRutaCAD.DevuelveRutasOrdenadasPorFecha ();
}
public TravelnookGenNHibernate.EN.Travelnook.RutaEN DevuelveRutaPorNombre (string p_nombre)
{
        return _IRutaCAD.DevuelveRutaPorNombre (p_nombre);
}
public System.Collections.Generic.IList<RutaEN> MostrarRutas (int first, int size)
{
        System.Collections.Generic.IList<RutaEN> list = null;

        list = _IRutaCAD.MostrarRutas (first, size);
        return list;
}
}
}
