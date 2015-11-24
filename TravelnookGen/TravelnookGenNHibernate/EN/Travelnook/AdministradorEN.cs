
using System;
// Definición clase AdministradorEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class AdministradorEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo reporte
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> Reporte {
        get { return reporte; } set { reporte = value;  }
}





public AdministradorEN()
{
        reporte = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ReporteEN>();
}



public AdministradorEN(string email, String contrasenya, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte
                       )
{
        this.init (Email, contrasenya, reporte);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.Contrasenya, administrador.Reporte);
}

private void init (string email, String contrasenya, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte)
{
        this.Email = email;


        this.Contrasenya = contrasenya;

        this.Reporte = reporte;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
