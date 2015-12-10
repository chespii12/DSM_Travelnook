using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelnookGenNHibernate.EN.Travelnook;

namespace TravelnookMVC.Models
{
    public class AssemblerEvento
    {
        public Evento ConvertENToModelUI(EventoEN en)
        {
            Evento eve = new Evento();
            eve.Titulo = en.Titulo;
            eve.Descripcion = en.Descripcion;

            IList<string> invitados = new List<string>();

            foreach (UsuarioEN usu in en.Usuario)
            {
                invitados.Add(usu.NomUsu);
            }

            eve.Invitados = invitados;
            //provincia y fecha de creacion
            return eve;
        }

        public IList<Evento> ConvertListENToModel(IList<EventoEN> ens)
        {
            IList<Evento> eventos = new List<Evento>();
            foreach (EventoEN en in ens)
            {
                eventos.Add(ConvertENToModelUI(en));
            }
            return eventos;
        }
    }
}