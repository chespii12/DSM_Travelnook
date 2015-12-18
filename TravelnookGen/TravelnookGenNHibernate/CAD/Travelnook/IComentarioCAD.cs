
using System;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id);

int CrearComentario (ComentarioEN comentario);

void EliminarComentario (int id);



ComentarioEN DevuelveComentarioPorID (int id);



void AsignarSitio (int p_Comentario_OID, string p_sitio_OID);

void AsignarRuta (int p_Comentario_OID, System.Collections.Generic.IList<string> p_ruta_OIDs);
}
}
