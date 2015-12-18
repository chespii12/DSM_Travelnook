
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
    public partial class RutaCEN
    {
        public void PuntuarRuta(string p_oid, int p_puntuacion)
        {
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Ruta_puntuarRuta) ENABLED START*/

            RutaEN rutaEN = new RutaEN();
            RutaCEN rutaCEN = new RutaCEN();

            rutaEN = rutaCEN.DevuelveRutaPorNombre(p_oid);
            rutaEN.Puntuacion += p_puntuacion;
            rutaEN.NumPuntuados++;
            float med = ((float)rutaEN.Puntuacion / (float)rutaEN.NumPuntuados);
            rutaEN.PuntuacionMedia = (int)Math.Round(med);

            /*PROTECTED REGION END*/
        }
    }
}
