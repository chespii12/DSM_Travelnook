using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TravelnookMVC.Models
{
    public class Favorito
    {

        [ScaffoldColumn(false)]
        public string NombreUsuario { get; set; }


        

        /*[Display(Prompt = "Vídeos del sitio", Description = "Vídeos del sitio", Name = "Vídeos ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> Videos { get; set; }*/



    }
}
