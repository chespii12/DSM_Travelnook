using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelnookMVC.Models
{ //ksjdb
    public class Ruta
    {
        [ScaffoldColumn(false)]
        public string nombreRuta { get; set; } //id de ruta

        [ScaffoldColumn(false)]
        public IList<string> IdSitio { get; set; } //id de sitios, entidad relacionada

        [Display(Prompt = "Nombre de la ruta", Description = "Nombre de la ruta", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la ruta")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Provincia de la ruta", Description = "Provincia de la ruta", Name = "Provincia ")]
        [Required(ErrorMessage = "Debe indicar una provincia para la ruta")]
        //[DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [StringLength(maximumLength: 200, ErrorMessage = "La provincia no puede tener más de 200 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "Descripción de la ruta", Description = "Descripción de la ruta", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción")]
        [StringLength(maximumLength: 500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Puntuación de la ruta", Description = "Puntuación de la ruta", Name = "Puntuación ")]
        [Required(ErrorMessage = "Debe indicar una puntuación para el sitio")]
        [DataType(DataType.Currency, ErrorMessage = "La puntuación debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "La puntuación debe de ser entre 0 y 5")]
        public double Puntuacion { get; set; }

        [Display(Prompt = "Fecha de creacion de la ruta", Description = "Fecha de creacion de la ruta", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar una Fecha")]
        public Nullable<DateTime> Fecha { get; set; }
    }
}