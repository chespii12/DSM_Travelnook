using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//jasdfasd
namespace TravelnookMVC.Models
{
    public class Evento
    {
        [ScaffoldColumn(false)]
        public string IdEvento { get; set; } //id de evento

        [ScaffoldColumn(false)]
        public string Organizador { get; set; } //organizador, relacion con usuario     

        [Display(Prompt = "Titulo del evento", Description = "Titulo del evento", Name = "Titulo ")]
        [Required(ErrorMessage = "Debe indicar un titulo para el evento")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Titulo { get; set; }

        [Display(Prompt = "Descripción del evento", Description = "Descripción del evento", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción")]
        [StringLength(maximumLength: 500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Invitados al evento", Description = "Puntuación de la ruta", Name = "Puntuación ")]
        public IList<string> Invitados { get; set; } //asistentes, relacion con usuario

        //PROVINCIA - FECHA?
    }
}