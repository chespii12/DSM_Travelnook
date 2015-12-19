using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TravelnookMVC.Models
{
    public class Usuario
    {
        [ScaffoldColumn(false)]
        public IList<Sitio> sitios { get; set; }

        [ScaffoldColumn(false)]
        public IList<Ruta> rutas { get; set; }
        
        //PONER EVENTO
        //poner amigos
        //PONER PETICIONES
        

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Required]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public Nullable<DateTime> Fecha { get; set; }


        [Display(Name = "Foto de perfil")]
        public string Foto { get; set; }


    }
}