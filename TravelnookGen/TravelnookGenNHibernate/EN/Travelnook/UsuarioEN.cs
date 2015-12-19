
using System;
// Definición clase UsuarioEN
namespace TravelnookGenNHibernate.EN.Travelnook
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nomUsu
 */
private string nomUsu;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo fechaNacimiento
 */
private Nullable<DateTime> fechaNacimiento;



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
 *	Atributo comentario
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentario;



/**
 *	Atributo solicitudAmistadSolicitante
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> solicitudAmistadSolicitante;



/**
 *	Atributo solicitudAmistadSolicitado
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> solicitudAmistadSolicitado;



/**
 *	Atributo amigos
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> amigos;



/**
 *	Atributo evento
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> evento;



/**
 *	Atributo invitado
 */
private System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> invitado;



/**
 *	Atributo foto_perfil
 */
private string foto_perfil;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string NomUsu {
        get { return nomUsu; } set { nomUsu = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual Nullable<DateTime> FechaNacimiento {
        get { return fechaNacimiento; } set { fechaNacimiento = value;  }
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



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> SolicitudAmistadSolicitante {
        get { return solicitudAmistadSolicitante; } set { solicitudAmistadSolicitante = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> SolicitudAmistadSolicitado {
        get { return solicitudAmistadSolicitado; } set { solicitudAmistadSolicitado = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> Amigos {
        get { return amigos; } set { amigos = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> Evento {
        get { return evento; } set { evento = value;  }
}



public virtual System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> Invitado {
        get { return invitado; } set { invitado = value;  }
}



public virtual string Foto_perfil {
        get { return foto_perfil; } set { foto_perfil = value;  }
}





public UsuarioEN()
{
        sitio = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SitioEN>();
        favorito = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN>();
        reporte = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ReporteEN>();
        comentario = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN>();
        solicitudAmistadSolicitante = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN>();
        solicitudAmistadSolicitado = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN>();
        amigos = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN>();
        evento = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.EventoEN>();
        invitado = new System.Collections.Generic.List<TravelnookGenNHibernate.EN.Travelnook.EventoEN>();
}



public UsuarioEN(string nomUsu, string email, string nombre, string apellidos, string localidad, string provincia, String contrasenya, Nullable<DateTime> fechaNacimiento, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentario, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> solicitudAmistadSolicitante, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> solicitudAmistadSolicitado, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> amigos, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> evento, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> invitado, string foto_perfil
                 )
{
        this.init (NomUsu, email, nombre, apellidos, localidad, provincia, contrasenya, fechaNacimiento, sitio, favorito, reporte, comentario, solicitudAmistadSolicitante, solicitudAmistadSolicitado, amigos, evento, invitado, foto_perfil);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (NomUsu, usuario.Email, usuario.Nombre, usuario.Apellidos, usuario.Localidad, usuario.Provincia, usuario.Contrasenya, usuario.FechaNacimiento, usuario.Sitio, usuario.Favorito, usuario.Reporte, usuario.Comentario, usuario.SolicitudAmistadSolicitante, usuario.SolicitudAmistadSolicitado, usuario.Amigos, usuario.Evento, usuario.Invitado, usuario.Foto_perfil);
}

private void init (string nomUsu, string email, string nombre, string apellidos, string localidad, string provincia, String contrasenya, Nullable<DateTime> fechaNacimiento, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> sitio, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.FavoritoEN> favorito, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ReporteEN> reporte, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.ComentarioEN> comentario, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> solicitudAmistadSolicitante, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SolicitudEN> solicitudAmistadSolicitado, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> amigos, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> evento, System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.EventoEN> invitado, string foto_perfil)
{
        this.NomUsu = nomUsu;


        this.Email = email;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Localidad = localidad;

        this.Provincia = provincia;

        this.Contrasenya = contrasenya;

        this.FechaNacimiento = fechaNacimiento;

        this.Sitio = sitio;

        this.Favorito = favorito;

        this.Reporte = reporte;

        this.Comentario = comentario;

        this.SolicitudAmistadSolicitante = solicitudAmistadSolicitante;

        this.SolicitudAmistadSolicitado = solicitudAmistadSolicitado;

        this.Amigos = amigos;

        this.Evento = evento;

        this.Invitado = invitado;

        this.Foto_perfil = foto_perfil;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
