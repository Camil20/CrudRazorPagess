using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Estado
    {
        public Estado()
        {
            Facturas = new HashSet<Factura>();
            Productos = new HashSet<Producto>();
        }

        public int EstadoId { get; set; }
        public string Nombres { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
