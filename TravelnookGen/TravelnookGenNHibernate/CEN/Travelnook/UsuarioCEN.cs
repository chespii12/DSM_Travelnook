

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;

namespace TravelnookGenNHibernate.CEN.Travelnook
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string CrearUsuario (string p_email, string p_nombre, string p_apellidos, string p_nomUsu, string p_localidad, string p_provincia, String p_contrasenya, Nullable<DateTime> p_fechaNacimiento, string p_foto_perfil)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.NomUsu = p_nomUsu;

        usuarioEN.Localidad = p_localidad;

        usuarioEN.Provincia = p_provincia;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.FechaNacimiento = p_fechaNacimiento;

        usuarioEN.Foto_perfil = p_foto_perfil;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.CrearUsuario (usuarioEN);
        return oid;
}

public void BorrarUsuario (string nomUsu)
{
        _IUsuarioCAD.BorrarUsuario (nomUsu);
}

public void ModificarPerfil (string p_Usuario_OID, string p_email, string p_nombre, string p_apellidos, string p_localidad, string p_provincia, String p_contrasenya, Nullable<DateTime> p_fechaNacimiento, string p_foto_perfil)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.NomUsu = p_Usuario_OID;
        usuarioEN.Email = p_email;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Localidad = p_localidad;
        usuarioEN.Provincia = p_provincia;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuarioEN.FechaNacimiento = p_fechaNacimiento;
        usuarioEN.Foto_perfil = p_foto_perfil;
        //Call to UsuarioCAD

        _IUsuarioCAD.ModificarPerfil (usuarioEN);
}

public TravelnookGenNHibernate.EN.Travelnook.UsuarioEN DevuelveUsuarioPorEmail (string p_email)
{
        return _IUsuarioCAD.DevuelveUsuarioPorEmail (p_email);
}
public UsuarioEN DevuelveUsuarioPorNomUsu (string nomUsu)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.DevuelveUsuarioPorNomUsu (nomUsu);
        return usuarioEN;
}

public void AnyadirAmigo (string p_Usuario_OID, System.Collections.Generic.IList<string> p_amigos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AnyadirAmigo (p_Usuario_OID, p_amigos_OIDs);
}
public void EliminarAmigo (string p_Usuario_OID, System.Collections.Generic.IList<string> p_amigos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.EliminarAmigo (p_Usuario_OID, p_amigos_OIDs);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> AmigosPorNomUsu (string p_yo, string p_nomUsu)
{
        return _IUsuarioCAD.AmigosPorNomUsu (p_yo, p_nomUsu);
}
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.UsuarioEN> AmigosPorEmail (string p_yo, string p_email)
{
        return _IUsuarioCAD.AmigosPorEmail (p_yo, p_email);
}
public System.Collections.Generic.IList<UsuarioEN> MostrarUsuariosRegistrados (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.MostrarUsuariosRegistrados (first, size);
        return list;
}
}
}
