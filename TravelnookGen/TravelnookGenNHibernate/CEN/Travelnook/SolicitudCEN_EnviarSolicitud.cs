
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
    public partial class SolicitudCEN
    {
        public int EnviarSolicitud(string mi_OID, TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum p_estado, Nullable<DateTime> p_fecha, string su_OID)
        {
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Solicitud_enviarSolicitud) ENABLED START*/

            // Write here your custom code...
            SolicitudCEN solicitud = new SolicitudCEN();

            int id = solicitud.CrearSolicitud(mi_OID, p_estado, p_fecha, su_OID);

            return id;
            /*PROTECTED REGION END*/
        }
    }
}
