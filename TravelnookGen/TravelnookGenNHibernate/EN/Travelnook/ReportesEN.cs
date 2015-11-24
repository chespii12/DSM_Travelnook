
using System;
// Definición clase ReportesEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class ReportesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo motivo
 */
private string motivo;



/**
 *	Atributo usuario
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario;



/**
 *	Atributo sitio
 */
private TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio;



/**
 *	Atributo ruta
 */
private TravelnookGenNHibernate.EN.Travelnook.RutaEN ruta;



/**
 *	Atributo comentario
 */
private TravelnookGenNHibernate.EN.Travelnook.ComentarioEN comentario;



/**
 *	Atributo eventos
 */
private TravelnookGenNHibernate.EN.Travelnook.EventoEN eventos;



/**
 *	Atributo administrador
 */
private TravelnookGenNHibernate.EN.Travelnook.AdministradorEN administrador;



/**
 *	Atributo marcado
 */
private bool marcado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Motivo {
        get { return motivo; } set { motivo = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.SitioEN Sitio {
        get { return sitio; } set { sitio = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.RutaEN Ruta {
        get { return ruta; } set { ruta = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.ComentarioEN Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.EventoEN Eventos {
        get { return eventos; } set { eventos = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual bool Marcado {
        get { return marcado; } set { marcado = value;  }
}





public ReportesEN()
{
}



public ReportesEN(int id, string motivo, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio, TravelnookGenNHibernate.EN.Travelnook.RutaEN ruta, TravelnookGenNHibernate.EN.Travelnook.ComentarioEN comentario, TravelnookGenNHibernate.EN.Travelnook.EventoEN eventos, TravelnookGenNHibernate.EN.Travelnook.AdministradorEN administrador, bool marcado
                  )
{
        this.init (Id, motivo, usuario, sitio, ruta, comentario, eventos, administrador, marcado);
}


public ReportesEN(ReportesEN reportes)
{
        this.init (Id, reportes.Motivo, reportes.Usuario, reportes.Sitio, reportes.Ruta, reportes.Comentario, reportes.Eventos, reportes.Administrador, reportes.Marcado);
}

private void init (int id, string motivo, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio, TravelnookGenNHibernate.EN.Travelnook.RutaEN ruta, TravelnookGenNHibernate.EN.Travelnook.ComentarioEN comentario, TravelnookGenNHibernate.EN.Travelnook.EventoEN eventos, TravelnookGenNHibernate.EN.Travelnook.AdministradorEN administrador, bool marcado)
{
        this.Id = id;


        this.Motivo = motivo;

        this.Usuario = usuario;

        this.Sitio = sitio;

        this.Ruta = ruta;

        this.Comentario = comentario;

        this.Eventos = eventos;

        this.Administrador = administrador;

        this.Marcado = marcado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReportesEN t = obj as ReportesEN;
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
