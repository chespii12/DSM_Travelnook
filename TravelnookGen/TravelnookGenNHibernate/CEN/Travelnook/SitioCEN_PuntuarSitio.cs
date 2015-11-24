
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
public partial class SitioCEN
{
public void PuntuarSitio (string p_oid, int p_puntuacion)
{
        /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Sitio_puntuarSitio) ENABLED START*/

        SitioEN sitioEN = new SitioEN ();
        SitioCEN sitioCEN = new SitioCEN ();

        sitioEN = sitioCEN.DevuelveSitioPorNombre (p_oid);
        sitioEN.Puntuacion += p_puntuacion;
        sitioEN.NumPuntuados++;
        float med = ((float)sitioEN.Puntuacion / (float)sitioEN.NumPuntuados);
        sitioEN.PuntuacionMedia = (int)Math.Round (med);

        /*PROTECTED REGION END*/
}
}
}
