
using System;
// Definición clase EventoEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class EventoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo reporte
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo organizador
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN organizador;



/**
 *	Atributo favorito
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> usuario;



/**
 *	Atributo asistentes
 */
private int asistentes;



/**
 *	Atributo quizas
 */
private int quizas;



/**
 *	Atributo rechazados
 */
private int rechazados;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> Reporte {
        get { return reporte; } set { reporte = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Organizador {
        get { return organizador; } set { organizador = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> Favorito {
        get { return favorito; } set { favorito = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int Asistentes {
        get { return asistentes; } set { asistentes = value;  }
}



public virtual int Quizas {
        get { return quizas; } set { quizas = value;  }
}



public virtual int Rechazados {
        get { return rechazados; } set { rechazados = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}





public EventoEN()
{
        reporte = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ReporteEN>();
        favorito = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN>();
        usuario = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN>();
        comentarios = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN>();
}



public EventoEN(int id, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, string titulo, string descripcion, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN organizador, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> usuario, int asistentes, int quizas, int rechazados, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios
                )
{
        this.init (Id, reporte, titulo, descripcion, organizador, favorito, usuario, asistentes, quizas, rechazados, comentarios);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Reporte, evento.Titulo, evento.Descripcion, evento.Organizador, evento.Favorito, evento.Usuario, evento.Asistentes, evento.Quizas, evento.Rechazados, evento.Comentarios);
}

private void init (int id, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, string titulo, string descripcion, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN organizador, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> usuario, int asistentes, int quizas, int rechazados, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentarios)
{
        this.Id = id;


        this.Reporte = reporte;

        this.Titulo = titulo;

        this.Descripcion = descripcion;

        this.Organizador = organizador;

        this.Favorito = favorito;

        this.Usuario = usuario;

        this.Asistentes = asistentes;

        this.Quizas = quizas;

        this.Rechazados = rechazados;

        this.Comentarios = comentarios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EventoEN t = obj as EventoEN;
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
