
using System;
// Definición clase RutaEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class RutaEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo sitio
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio;



/**
 *	Atributo favorito
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito;



/**
 *	Atributo reporte
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo numPuntuados
 */
private int numPuntuados;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo puntuacionMedia
 */
private int puntuacionMedia;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> Sitio {
        get { return sitio; } set { sitio = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> Favorito {
        get { return favorito; } set { favorito = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> Reporte {
        get { return reporte; } set { reporte = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual int NumPuntuados {
        get { return numPuntuados; } set { numPuntuados = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual int PuntuacionMedia {
        get { return puntuacionMedia; } set { puntuacionMedia = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}





public RutaEN()
{
        sitio = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
        favorito = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN>();
        reporte = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ReporteEN>();
        comentarios = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN>();
}



public RutaEN(string nombre, string descripcion, string provincia, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, int puntuacion, int numPuntuados, Nullable<DateTime> fechaCreacion, int puntuacionMedia, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios
              )
{
        this.init (Nombre, descripcion, provincia, sitio, favorito, reporte, puntuacion, numPuntuados, fechaCreacion, puntuacionMedia, comentarios);
}


public RutaEN(RutaEN ruta)
{
        this.init (Nombre, ruta.Descripcion, ruta.Provincia, ruta.Sitio, ruta.Favorito, ruta.Reporte, ruta.Puntuacion, ruta.NumPuntuados, ruta.FechaCreacion, ruta.PuntuacionMedia, ruta.Comentarios);
}

private void init (string nombre, string descripcion, string provincia, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, int puntuacion, int numPuntuados, Nullable<DateTime> fechaCreacion, int puntuacionMedia, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios)
{
        this.Nombre = nombre;


        this.Descripcion = descripcion;

        this.Provincia = provincia;

        this.Sitio = sitio;

        this.Favorito = favorito;

        this.Reporte = reporte;

        this.Puntuacion = puntuacion;

        this.NumPuntuados = numPuntuados;

        this.FechaCreacion = fechaCreacion;

        this.PuntuacionMedia = puntuacionMedia;

        this.Comentarios = comentarios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RutaEN t = obj as RutaEN;
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
