﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion { 
    public partial class MUsuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
    }
}

