
using System;
// Definición clase PeticiónEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class PeticiónEN
{
/**
 *	Atributo solicitante
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN solicitante;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum estado;



/**
 *	Atributo fecha
 */
private System.Collections.Generic.IList<Nullable<DateTime> > fecha;



/**
 *	Atributo solicitado
 */
private TravelnookGenNHibernate.EN.Travelnook.UsuarioEN solicitado;






public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Solicitante {
        get { return solicitante; } set { solicitante = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<Nullable<DateTime> > Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual TravelnookGenNHibernate.EN.Travelnook.UsuarioEN Solicitado {
        get { return solicitado; } set { solicitado = value;  }
}





public PeticiónEN()
{
}



public PeticiónEN(int id, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN solicitante, TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum estado, System.Collections.Generic.IList<Nullable<DateTime> > fecha, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN solicitado
                  )
{
        this.init (Id, solicitante, estado, fecha, solicitado);
}


public PeticiónEN(PeticiónEN petición)
{
        this.init (Id, petición.Solicitante, petición.Estado, petición.Fecha, petición.Solicitado);
}

private void init (int id, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN solicitante, TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum estado, System.Collections.Generic.IList<Nullable<DateTime> > fecha, TravelnookGenNHibernate.EN.Travelnook.UsuarioEN solicitado)
{
        this.Id = id;


        this.Solicitante = solicitante;

        this.Estado = estado;

        this.Fecha = fecha;

        this.Solicitado = solicitado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeticiónEN t = obj as PeticiónEN;
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
