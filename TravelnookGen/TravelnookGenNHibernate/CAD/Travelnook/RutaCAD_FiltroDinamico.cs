using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelnookGenNHibernate.CEN.Travelnook;
using NHibernate;

namespace TravelnookGenNHibernate.CAD.Travelnook
{
    partial class RutaCAD
    {
        public System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> Filtro_Dinamico(string sql, string p_nombre, string p_provincia, int p_puntuacion)
        {
            System.Collections.Generic.IList<TravelnookGenNHibernate.EN.Travelnook.RutaEN> result;
            try
            {
                SessionInitializeTransaction();

                IQuery query = (IQuery)session.CreateQuery(sql);

                if (p_nombre != null && p_nombre != "")
                    query.SetParameter ("p_nombre", p_nombre);
                if (p_provincia != null && p_provincia != "")
                    query.SetParameter ("p_provincia", p_provincia);
                if (p_puntuacion != -1)
                    query.SetParameter("p_puntuacion", p_puntuacion);

                result = query.List<TravelnookGenNHibernate.EN.Travelnook.RutaEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is TravelnookGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new TravelnookGenNHibernate.Exceptions.DataLayerException("Error in RutaCAD_FiltroDinamico.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
