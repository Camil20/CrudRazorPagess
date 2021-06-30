using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Producto
    {
        public Producto()
        {
            FacturasDetalles = new HashSet<FacturasDetalle>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<FacturasDetalle> FacturasDetalles { get; set; }
    }
}
