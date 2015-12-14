
using System;
// Definición clase SitioEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class SitioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo ruta
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> ruta;



/**
 *	Atributo fotos
 */
private System.Collections.Generic.IList<string> fotos;



/**
 *	Atributo usuario
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario;



/**
 *	Atributo favorito
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito;



/**
 *	Atributo reporte
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte;



/**
 *	Atributo videos
 */
private System.Collections.Generic.IList<string> videos;



/**
 *	Atributo localizacion
 */
private string localizacion;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo numPuntuados
 */
private int numPuntuados;



/**
 *	Atributo puntuacionMedia
 */
private int puntuacionMedia;



/**
 *	Atributo tipoSitio
 */
private TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum tipoSitio;



/**
 *	Atributo actividades
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> actividades;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> Ruta {
        get { return ruta; } set { ruta = value;  }
}



public virtual System.Collections.Generic.IList<string> Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> Favorito {
        get { return favorito; } set { favorito = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> Reporte {
        get { return reporte; } set { reporte = value;  }
}



public virtual System.Collections.Generic.IList<string> Videos {
        get { return videos; } set { videos = value;  }
}



public virtual string Localizacion {
        get { return localizacion; } set { localizacion = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual int NumPuntuados {
        get { return numPuntuados; } set { numPuntuados = value;  }
}



public virtual int PuntuacionMedia {
        get { return puntuacionMedia; } set { puntuacionMedia = value;  }
}



public virtual TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum TipoSitio {
        get { return tipoSitio; } set { tipoSitio = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> Actividades {
        get { return actividades; } set { actividades = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}





public SitioEN()
{
        ruta = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
        favorito = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN>();
        reporte = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ReporteEN>();
        actividades = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ActividadEN>();
        comentarios = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN>();
}



public SitioEN(string nombre, string provincia, string descripcion, int puntuacion, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> ruta, System.Collections.Generic.IList<string> fotos, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, System.Collections.Generic.IList<string> videos, string localizacion, Nullable<DateTime> fechaCreacion, int numPuntuados, int puntuacionMedia, TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum tipoSitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> actividades, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios
               )
{
        this.init (Nombre, provincia, descripcion, puntuacion, ruta, fotos, usuario, favorito, reporte, videos, localizacion, fechaCreacion, numPuntuados, puntuacionMedia, tipoSitio, actividades, comentarios);
}


public SitioEN(SitioEN sitio)
{
        this.init (Nombre, sitio.Provincia, sitio.Descripcion, sitio.Puntuacion, sitio.Ruta, sitio.Fotos, sitio.Usuario, sitio.Favorito, sitio.Reporte, sitio.Videos, sitio.Localizacion, sitio.FechaCreacion, sitio.NumPuntuados, sitio.PuntuacionMedia, sitio.TipoSitio, sitio.Actividades, sitio.Comentarios);
}

private void init (string nombre, string provincia, string descripcion, int puntuacion, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> ruta, System.Collections.Generic.IList<string> fotos, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, System.Collections.Generic.IList<string> videos, string localizacion, Nullable<DateTime> fechaCreacion, int numPuntuados, int puntuacionMedia, TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum tipoSitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> actividades, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios)
{
        this.Nombre = nombre;


        this.Provincia = provincia;

        this.Descripcion = descripcion;

        this.Puntuacion = puntuacion;

        this.Ruta = ruta;

        this.Fotos = fotos;

        this.Usuario = usuario;

        this.Favorito = favorito;

        this.Reporte = reporte;

        this.Videos = videos;

        this.Localizacion = localizacion;

        this.FechaCreacion = fechaCreacion;

        this.NumPuntuados = numPuntuados;

        this.PuntuacionMedia = puntuacionMedia;

        this.TipoSitio = tipoSitio;

        this.Actividades = actividades;

        this.Comentarios = comentarios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SitioEN t = obj as SitioEN;
        if (t == null)
                return false;
        if (Nombre.Equals (t.Nombre))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nombre.GetHashCode ();
        return hash;
}
}
}
