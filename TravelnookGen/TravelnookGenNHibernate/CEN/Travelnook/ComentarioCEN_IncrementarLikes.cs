
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
public partial class ComentarioCEN
{
public int IncrementarLikes (int p_oid)
{
        /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Comentario_incrementarLikes) ENABLED START*/

        // Write here your custom code...

        ComentarioCEN comentarioCEN = new ComentarioCEN ();
        ComentarioEN comentarioEN = comentarioCEN.DevuelveComentarioPorID (p_oid);

        return comentarioEN.Likes += 1;

        /*PROTECTED REGION END*/
}
}
}
