using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroDePersonas.Models.ViewModels
{
    public class PersonaViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
