
using System;
// Definición clase ActividadEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class ActividadEN
{
/**
 *	Atributo sitio
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio;



/**
 *	Atributo tipo
 */
private TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo;






public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> Sitio {
        get { return sitio; } set { sitio = value;  }
}



public virtual TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}





public ActividadEN()
{
        sitio = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
}



public ActividadEN(TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio
                   )
{
        this.init (Tipo, sitio);
}


public ActividadEN(ActividadEN actividad)
{
        this.init (Tipo, actividad.Sitio);
}

private void init (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum tipo, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio)
{
        this.Tipo = tipo;


        this.Sitio = sitio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ActividadEN t = obj as ActividadEN;
        if (t == null)
                return false;
        if (Tipo.Equals (t.Tipo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Tipo.GetHashCode ();
        return hash;
}
}
}
