using System;
using System.Collections.Generic;

namespace PruebaDigitalBank.DAL.DataContext
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
    }
}
