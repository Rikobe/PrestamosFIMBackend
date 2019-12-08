using System;
using System.Collections.Generic;

namespace PrestamosFIM.Core.Entities
{
    public partial class Activo
    {
        //public Activo()
        //{
        //    DetallePrestamo = new HashSet<DetallePrestamo>();
        //}

        public int IdActivo { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreActivo { get; set; }

        //public virtual ICollection<DetallePrestamo> DetallePrestamo { get; set; }
    }
}
