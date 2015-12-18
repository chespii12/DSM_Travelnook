using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TravelnookMVC.Models
{
    public class Comentario
    {

        [ScaffoldColumn(false)]
        public string Usuario { get; set; }

        [ScaffoldColumn(false)]
        public string Sitio { get; set; }

        [ScaffoldColumn(false)]
        public string Ruta { get; set; }

        [ScaffoldColumn(false)]
        public int IdComentario { get; set; } //falta el resto de campos??????

        [Display(Prompt = "Escribe aquí", Description = "Contenido ", Name = "Contenido: ")]
        [Required(ErrorMessage = "Debe Escribir en el cuadro de texto")]
        [StringLength(maximumLength: 300, ErrorMessage = "El comentario no puede tener más de 300 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Voto positivo", Description = "Voto positivo", Name = "Likes:  ")]
        public int likes { get; set; }

        [Display(Prompt = "Voto negativo", Description = "Voto negativo", Name = "Dislikes:  ")]
        public int dislikes { get; set; }

        [Display(Prompt = "Fecha de creación", Description = "Fecha de creación", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar una fecha para el comentario")]
        public Nullable<DateTime> Fecha { get; set; }

        [Display(Prompt = "Imágenes del sitio", Description = "Imágenes del sitio", Name = "Imágenes ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> fotos { get; set; }

        [Display(Prompt = "Vídeos del sitio", Description = "Vídeos del sitio", Name = "Vídeos ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> videos { get; set; }
    }
}
