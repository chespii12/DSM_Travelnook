using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TravelnookMVC.Models
{
    public class Evento /*creado porque lo necesitaba, pero añadid lo que querais o quitad lo que querais*/
    {
        
        [ScaffoldColumn(false)]
        public string Nombre { get; set; }

        /*[Display(Prompt = "Vídeos del sitio", Description = "Vídeos del sitio", Name = "Vídeos ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> Videos { get; set; }*/
       


    }
}
