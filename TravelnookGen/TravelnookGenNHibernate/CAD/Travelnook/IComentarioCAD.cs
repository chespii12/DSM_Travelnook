
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
}
}
