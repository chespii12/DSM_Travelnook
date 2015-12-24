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
        public string NombreUsuario { get; set; }


        [ScaffoldColumn(false)]
        public string latitud { get; set; }
        [ScaffoldColumn(false)]
        public string longitud { get; set; }

        [ScaffoldColumn(false)]
        public int tieneLocalizacion { get; set; }

        [ScaffoldColumn(false)]
        public IList<Comentario> Comentarios { get; set; }

        [ScaffoldColumn(false)]
        public int esfav { get; set; }

        [Display(Prompt = "Nombre del sitio", Description = "Nombre del sitio", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el sitio")]
        [StringLength(maximumLength: 30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción del sitio", Description = "Descripción del sitio", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para el sitio")]
        [StringLength(maximumLength: 300, ErrorMessage = "La descripción no puede tener más de 300 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Nombre de la provincia", Description = "Nombre de la provincia", Name = "Provincia ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la provincia")]
        [StringLength(maximumLength: 30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "Tipo de sitio", Description = "Tipo de sitio", Name = "Actividades ")]
        [Required(ErrorMessage = "Debe indicar un tipo al sitio")]
        public IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> Actividades { get; set; }

        [Display(Prompt = "Tipo de sitio", Description = "Tipo de sitio", Name = "Actividades imprimir ")]
        public IList<string> Actividadesimprimir { get; set; }

        [Display(Prompt = "Tipo de sitio", Description = "Tipo de sitio", Name = "Tipo ")]
        [Required(ErrorMessage = "Debe indicar un tipo al sitio")]
        public TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum TipoSitio { get; set; }

        [Display(Prompt = "Puntuación de la ruta", Description = "Puntuación de la ruta", Name = "Puntuación ")]
        [Required(ErrorMessage = "Debe puntuar la ruta")]
        [DataType(DataType.Currency, ErrorMessage = "La puntuacion debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "El precio debe ser mayor que cero y menor de 5")]
        public int Puntuacion { get; set; }

        [Display(Prompt = "Localización del sitio", Description = "Localización del sitio", Name = "Localización ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la provincia")]
        //[StringLength(maximumLength: 100, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string Localizacion { get; set; }

        [Display(Prompt = "Fecha de creación", Description = "Fecha de creación", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar una fecha para el sitio")]
        public Nullable<DateTime> Fecha { get; set; }

        [Display(Prompt = "Imágenes del sitio", Description = "Imágenes del sitio", Name = "Imágenes ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> fotos { get; set; }

        [Display(Prompt = "Vídeos del sitio", Description = "Vídeos del sitio", Name = "Vídeos ")]
        //[Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public IList<string> Videos { get; set; }

        [Display( Name = "Senderismo ")]
        public bool senderismo { get; set; }

        [Display(Name = "Deportes acuáticos ")]
        public bool deportes_acuaticos { get; set; }

        [Display(Name = "Deportes ")]
        public bool deportes { get; set; }

        [Display(Name = "Gastronomía ")]
        public bool gastronomia { get; set; }

        [Display(Name = "Camping ")]
        public bool camping { get; set; }

        [Display(Name = "Lúdicas ")]
        public bool ludicas { get; set; }

        [Display(Name = "Ocio nocturno ")]
        public bool ocio_nocturno { get; set; }

        [Display(Name = "Culturales ")]
        public bool culturales { get; set; }



    }
}
