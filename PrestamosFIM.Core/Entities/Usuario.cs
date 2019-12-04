using System;
using System.Collections.Generic;

namespace PrestamosFIM.Core
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
