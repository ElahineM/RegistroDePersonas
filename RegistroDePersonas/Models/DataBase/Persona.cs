using System;

#nullable disable

namespace RegistroDePersonas.Models.DataBase
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
    }
}
