
using System;
// Definición clase ComentarioEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo reportes
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reportes;



/**
 *	Atributo usuario
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario;



/**
 *	Atributo descripción
 */
private string descripción;



/**
 *	Atributo likes
 */
private int likes;



/**
 *	Atributo dislikes
 */
private int dislikes;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo fotos
 */
private System.Collections.Generic.IList<string> fotos;



/**
 *	Atributo videos
 */
private System.Collections.Generic.IList<string> videos;



/**
 *	Atributo sitio
 */
private TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio;



/**
 *	Atributo ruta
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> ruta;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> Reportes {
        get { return reportes; } set { reportes = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Descripción {
        get { return descripción; } set { descripción = value;  }
}



public virtual int Likes {
        get { return likes; } set { likes = value;  }
}



public virtual int Dislikes {
        get { return dislikes; } set { dislikes = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<string> Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual System.Collections.Generic.IList<string> Videos {
        get { return videos; } set { videos = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.SitioEN Sitio {
        get { return sitio; } set { sitio = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> Ruta {
        get { return ruta; } set { ruta = value;  }
}





public ComentarioEN()
{
        reportes = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ReporteEN>();
        ruta = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();
}



public ComentarioEN(int id, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reportes, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, string descripción, int likes, int dislikes, Nullable<DateTime> fecha, System.Collections.Generic.IList<string> fotos, System.Collections.Generic.IList<string> videos, TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> ruta
                    )
{
        this.init (Id, reportes, usuario, descripción, likes, dislikes, fecha, fotos, videos, sitio, ruta);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Reportes, comentario.Usuario, comentario.Descripción, comentario.Likes, comentario.Dislikes, comentario.Fecha, comentario.Fotos, comentario.Videos, comentario.Sitio, comentario.Ruta);
}

private void init (int id, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reportes, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, string descripción, int likes, int dislikes, Nullable<DateTime> fecha, System.Collections.Generic.IList<string> fotos, System.Collections.Generic.IList<string> videos, TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> ruta)
{
        this.Id = id;


        this.Reportes = reportes;

        this.Usuario = usuario;

        this.Descripción = descripción;

        this.Likes = likes;

        this.Dislikes = dislikes;

        this.Fecha = fecha;

        this.Fotos = fotos;

        this.Videos = videos;

        this.Sitio = sitio;

        this.Ruta = ruta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
