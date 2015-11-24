using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelnookGenNHibernate.EN.Travelnook; // <- Apuntar a los respectivos paquetes de vuestro proyecto.
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;
using NHibernate;

namespace TravelnookCP.CPs
{
    public class VacioCP : BasicCP
    {

        public VacioCP() : base() { }

        public VacioCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public int TravelnookCP()
        {
            //IPedidoCAD _IPedidoCAD = null;
            //PedidoCEN pedidoCEN = null;
            //ArticuloCP articuloCP = null;
            int oid = -1;

            try
            {
                SessionInitializeTransaction();
               
                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            return oid;
        }
       
    }
}
