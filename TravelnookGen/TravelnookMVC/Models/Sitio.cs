using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelnookMVC.Models
{
    public class Sitio
    {
        [ScaffoldColumn(false)]
        public int nombreSitio { get; set; } //id de sitio

        [ScaffoldColumn(false)]
        public string IdUsuario { get; set; } //id de usuario, entidad relacionada

        [ScaffoldColumn(false)]
        public string NombreUsuario { get; set; }

        [Display(Prompt = "Nombre del sitio", Description = "Nombre del sitio", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el sitio")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Provincia del sitio", Description = "Provincia del sitio", Name = "Provincia ")]
        [Required(ErrorMessage = "Debe indicar una provincia para el sitio")]
        //[DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [StringLength(maximumLength: 200, ErrorMessage = "La provincia no puede tener más de 200 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "Descripción del sitio", Description = "Descripción del sitio", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción")]
        [StringLength(maximumLength: 500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Puntuación del sitio", Description = "Puntuación del sitio", Name = "Puntuación ")]
        [Required(ErrorMessage = "Debe indicar una puntuación para el sitio")]
        [DataType(DataType.Currency, ErrorMessage = "La puntuación debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "La puntuación debe de ser entre 0 y 5")]
        public double Puntuacion { get; set; }

        [Display(Prompt = "Imagen del sitio", Description = "Imagen del sitio", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> Imagen { get; set; } 

        [Display(Prompt = "Video del sitio", Description = "Imagen del sitio", Name = "Video ")]
        [Required(ErrorMessage = "Debe indicar una imagen del sitio")]
        public IList<string> Video { get; set; }

        [Display(Prompt = "Localización del sitio", Description = "Localización del sitio", Name = "Localización ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del sitio")]
        public string Localización { get; set; }

        [Display(Prompt = "Fecha del sitio", Description = "Fecha del sitio", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar una Fecha")]
        public Nullable<DateTime> Fecha { get; set; }

        [Display(Prompt = "Tipo del sitio", Description = "Tipo del sitio", Name = "Tipo ")]
        [Required(ErrorMessage = "Debe indicar almenos un tipo")]
        public TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum TipoSitio { get; set; }

        [Display(Prompt = "Tipo del sitio", Description = "Tipo del sitio", Name = "Tipo ")]
        [Required(ErrorMessage = "Debe indicar almenos un tipo")]
        public IList<TravelnookGenNHibernate.EN.Travelnook.ActividadEN> Actividades { get; set; }
    }
}/*
[ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int IdCategoria { get; set; }

        [ScaffoldColumn(false)]
        public string NombreCategoria { get; set; }


        [Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Descripción del artículo", Description = "Descripción del artículo", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public string Imagen { get; set; }*/
