

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int CrearComentario (string p_usuario, string p_descripción, int p_likes, int p_dislikes, Nullable<DateTime> p_fecha)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new TravelnookGenNHibernate.EN.Travelnook.UsuarioEN ();
                comentarioEN.Usuario.NomUsu = p_usuario;
        }

        comentarioEN.Descripción = p_descripción;

        comentarioEN.Likes = p_likes;

        comentarioEN.Dislikes = p_dislikes;

        comentarioEN.Fecha = p_fecha;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.CrearComentario (comentarioEN);
        return oid;
}

public void EliminarComentario (int id)
{
        _IComentarioCAD.EliminarComentario (id);
}

public ComentarioEN DevuelveComentarioPorID (int id)
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.DevuelveComentarioPorID (id);
        return comentarioEN;
}

public void AsignarSitio (int p_Comentario_OID, string p_sitio_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.AsignarSitio (p_Comentario_OID, p_sitio_OID);
}
public void AsignarRuta (int p_Comentario_OID, System.Collections.Generic.IList<string> p_ruta_OIDs)
{
        //Call to ComentarioCAD

        _IComentarioCAD.AsignarRuta (p_Comentario_OID, p_ruta_OIDs);
}
public void AsignarEvento (int p_Comentario_OID, int p_evento_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.AsignarEvento (p_Comentario_OID, p_evento_OID);
}
}
}
