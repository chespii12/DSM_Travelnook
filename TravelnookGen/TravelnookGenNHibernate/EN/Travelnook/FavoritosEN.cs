
using System;
// Definición clase FavoritosEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class FavoritosEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo ruta
 */
private TravelnookGenNHibernate.EN.Travelnook.RutaEN ruta;



/**
 *	Atributo sitio
 */
private TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio;



/**
 *	Atributo usuario
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario;



/**
 *	Atributo evento
 */
private TravelnookGenNHibernate.EN.Travelnook.EventoEN evento;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.RutaEN Ruta {
        get { return ruta; } set { ruta = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.SitioEN Sitio {
        get { return sitio; } set { sitio = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.EventoEN Evento {
        get { return evento; } set { evento = value;  }
}





public FavoritosEN()
{
}



public FavoritosEN(int id, TravelnookGenNHibernate.EN.Travelnook.RutaEN ruta, TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, TravelnookGenNHibernate.EN.Travelnook.EventoEN evento
                   )
{
        this.init (Id, ruta, sitio, usuario, evento);
}


public FavoritosEN(FavoritosEN favoritos)
{
        this.init (Id, favoritos.Ruta, favoritos.Sitio, favoritos.Usuario, favoritos.Evento);
}

private void init (int id, TravelnookGenNHibernate.EN.Travelnook.RutaEN ruta, TravelnookGenNHibernate.EN.Travelnook.SitioEN sitio, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN usuario, TravelnookGenNHibernate.EN.Travelnook.EventoEN evento)
{
        this.Id = id;


        this.Ruta = ruta;

        this.Sitio = sitio;

        this.Usuario = usuario;

        this.Evento = evento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritosEN t = obj as FavoritosEN;
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
