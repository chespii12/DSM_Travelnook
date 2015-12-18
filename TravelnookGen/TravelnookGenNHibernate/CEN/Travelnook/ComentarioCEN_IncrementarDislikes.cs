
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
        public int IncrementarDislikes(int p_oid)
        {
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Comentario_incrementarDislikes) ENABLED START*/

            // Write here your custom code...

            ComentarioCEN comentarioCEN = new ComentarioCEN();
            ComentarioEN comentarioEN = comentarioCEN.DevuelveComentarioPorID(p_oid);

            return comentarioEN.Dislikes += 1;

            /*PROTECTED REGION END*/
        }
    }
}
