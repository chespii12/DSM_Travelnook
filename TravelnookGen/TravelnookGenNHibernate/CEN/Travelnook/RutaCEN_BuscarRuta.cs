
using System;
using System.Text;
using System.Collections.Generic;
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
public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> BuscarRuta (string p_nombre, string p_provincia, int p_puntuacion)
{
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Ruta_buscarRuta) ENABLED START*/

            RutaCAD rutaCAD = new RutaCAD();
            IList<RutaEN> lista = new List<RutaEN>();
            Boolean prim = true;
            String sql = @"FROM RutaEN as ruta where";

            if (p_nombre != null && p_nombre != "")
            {
                if (prim == false) { sql += " AND"; }
                sql += " ruta.Nombre like '%' + :p_nombre + '%'";
                prim = false;
            }
    
            if (p_provincia != null && p_provincia != "")
            {
                if (prim == false) { sql += " AND"; }
                sql += " ruta.Provincia like '%' + :p_provincia + '%'";
                prim = false;
            }

            if (p_puntuacion > -1)
            {
                if (prim == false) { sql += " AND"; }
                sql += " ruta.PuntuacionMedia = :p_puntuacion";
                prim = false;
            }


            lista = rutaCAD.Filtro_Dinamico(sql, p_nombre, p_provincia, p_puntuacion);
            return lista;

            /*PROTECTED REGION END*/
        }
}
}
