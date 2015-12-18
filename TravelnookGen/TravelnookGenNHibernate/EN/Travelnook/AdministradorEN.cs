
using System;
// Definición clase AdministradorEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class AdministradorEN
{
/**
 *	Atributo nomUsu
 */
private string nomUsu;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo email
 */
private string email;






public virtual string NomUsu {
        get { return nomUsu; } set { nomUsu = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}





public AdministradorEN()
{
}



public AdministradorEN(string nomUsu, String contrasenya, string email
                       )
{
        this.init (NomUsu, contrasenya, email);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (NomUsu, administrador.Contrasenya, administrador.Email);
}

private void init (string nomUsu, String contrasenya, string email)
{
        this.NomUsu = nomUsu;


        this.Contrasenya = contrasenya;

        this.Email = email;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (NomUsu.Equals (t.NomUsu))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NomUsu.GetHashCode ();
        return hash;
}
}
}
