using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelnookMVC.Models
{
    public class Ruta
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

       

        [ScaffoldColumn(false)]
        public IList<string> Idsitios { get; set; }  //falta el resto de campos????

        [ScaffoldColumn(false)]
        public IList<string> Comentarios { get; set; } //falta el resto de campos??????

        [Display(Prompt = "Nombre de la ruta", Description = "Nombre de la ruta", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la ruta")]
        [StringLength(maximumLength: 30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción de la ruta", Description = "Descripción de la ruta", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para la ruta")]
        [StringLength(maximumLength: 300, ErrorMessage = "La descripción no puede tener más de 300 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Nombre de la provincia", Description = "Nombre de la provincia", Name = "Provincia ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la provincia")]
        [StringLength(maximumLength: 30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "Puntuación de la ruta", Description = "Puntuación de la ruta", Name = "Puntuación ")]
        [Required(ErrorMessage = "Debe puntuar la ruta")]
        [DataType(DataType.Currency, ErrorMessage = "La puntuacion debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "El precio debe ser mayor que cero y menor de 5")]
        public double Puntuacion { get; set; }

        [Display(Prompt = "Fecha de creación", Description = "Fecha de creación", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar una fecha para la ruta")]
        public Nullable<DateTime> Fecha { get; set; }


    }
}
