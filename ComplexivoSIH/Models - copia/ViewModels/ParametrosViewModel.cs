using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplexivoSIH.Models.ViewModels
{
    public class ParametrosViewModel
    {
        public int Parametro_id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="El {0} debe tener al menos {1} caracteres",MinimumLength =5)]
        public string Smtpserver { get; set; }

        [Required]
        public int Smtppuerto { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Correo Electrónico")]
        public string Correo_sistema { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Clave de Correo")]
        public string Clave_correo { get; set; }

        [Compare("Clave_correo",ErrorMessage ="Las Contraseñas no son iguales")]
        [Display(Name = "Confirmar Clave de Correo")]
        [DataType(DataType.Password)]
        public string Confirmar_Clave_correo { get; set; }

        public bool Estado { get; set; }
    }
}