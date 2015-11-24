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
    public class UsuarioCP : BasicCP
    {
        public UsuarioCP() : base() { }

        public UsuarioCP(ISession sessionAux)
            : base(sessionAux)
        {
        }
        
        public void AceptarSolicitud(string mio_OID, string suyo_OID, int peticion_OID)
        {
            //cambiar Estado de petición
            //Añadir amigo "suyo_OID" a la lista de "mio_OID"
            //Añadir amigo "mio_OID" a la lista de "suyo_OID"
            SolicitudCEN solicitudCEN = null;
            UsuarioCEN usuarioCEN1 = null;
            UsuarioCEN usuarioCEN2 = null;
            try
            {
                SessionInitializeTransaction();
                SolicitudCAD solicitudCAD = new SolicitudCAD(session);
                UsuarioCAD usuarioCAD1 = new UsuarioCAD(session);
                UsuarioCAD usuarioCAD2 = new UsuarioCAD(session);

                solicitudCEN = new SolicitudCEN(solicitudCAD);
                usuarioCEN1 = new UsuarioCEN(usuarioCAD1);
                usuarioCEN2 = new UsuarioCEN(usuarioCAD2);
                               
                SolicitudEN solicitud = solicitudCAD.DevuelveSolicitudPorId(peticion_OID);
                solicitud.Estado = TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum.aceptada;//cambiar estado

                IList<string> listaAmigos1 = usuarioCAD1.ConsultarAmigos();
                listaAmigos1.Add(suyo_OID);                
                usuarioCAD1.AnyadirAmigo(mio_OID, listaAmigos1);

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
        }
    }
}
