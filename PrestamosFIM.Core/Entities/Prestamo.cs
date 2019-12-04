using System;
using System.Collections.Generic;

namespace PrestamosFIM.Core
{
    public partial class Prestamo
    {
        public int IdPrestamo { get; set; }
        public string CicloEscolar { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public string Grupo { get; set; }
        public string Carrera { get; set; }
        public string UidAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string TipoIdentificacion { get; set; }
        public string ResponsablePrestamo { get; set; }
    }
}
