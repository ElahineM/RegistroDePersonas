using System;

namespace RegistroDePersonas.Models.ViewModels
{
    public class ListPersonaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
    }
}
