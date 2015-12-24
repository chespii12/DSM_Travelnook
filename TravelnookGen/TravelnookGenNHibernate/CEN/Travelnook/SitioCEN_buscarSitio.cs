
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
public partial class SitioCEN
{
    public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.SitioEN> BuscarSitio(string p_nombre, string p_provincia, int p_puntuacion, TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum p_tipo, System.Collections.Generic.IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> p_actividades)
{
            /*PROTECTED REGION ID(TravelnookGenNHibernate.CEN.Travelnook_Sitio_buscarSitio) ENABLED START*/

            SitioCAD sitioCAD = new SitioCAD();
            IList<SitioEN> lista = new List<SitioEN>();
            IList<SitioEN> lista_final = new List<SitioEN>();
            Boolean prim = true;
            String sql = @"FROM SitioEN as sitio where";

            if (p_nombre != null && p_nombre != "")
            {
                if (prim == false) { sql += " AND"; }
                sql += " sitio.Nombre like '%' + :p_nombre + '%'";
                prim = false;
            }

            if (p_provincia != null && p_provincia != "")
            {
                if (prim == false) { sql += " AND"; }
                sql += " sitio.Provincia like '%' + :p_provincia + '%'";
                prim = false;
            }

            if (p_puntuacion > -1)
            {
                if (prim == false) { sql += " AND"; }
                sql += " sitio.PuntuacionMedia = :p_puntuacion";
                prim = false;
            }
            //System.Console.WriteLine("????????????????????" + sql);
            lista = sitioCAD.Filtro_Dinamico(sql, p_nombre, p_provincia, p_puntuacion);

            foreach (SitioEN sit in lista)
            {
                if (sit.TipoSitio == p_tipo)
                {
                    lista_final.Add(sit);
                }
            }
            foreach (SitioEN sit in lista)
            {
                foreach (ActividadEN acti in sit.Actividades)
                {
                    foreach (TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum p_acti in p_actividades)
                    {
                        if (acti.Tipo == p_acti)
                        {
                            if (!lista_final.Contains(sit))
                            {
                                lista_final.Add(sit);
                            }
                        }
                    }
                }

            }

            return lista_final;

            /*PROTECTED REGION END*/
        }
}
}
