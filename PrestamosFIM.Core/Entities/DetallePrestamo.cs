using System;
using System.Collections.Generic;

namespace PrestamosFIM.Core.Entities
{
    public partial class DetallePrestamo
    {
        public int IdPrestamoDetalle { get; set; }
        public int IdPrestamo { get; set; }
        public int IdActivo { get; set; }

        public virtual Activo IdActivoNavigation { get; set; }
        public virtual Prestamo IdPrestamoNavigation { get; set; }
    }
}
