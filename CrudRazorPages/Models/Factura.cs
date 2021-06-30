using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Factura
    {
        public Factura()
        {
            FacturasDetalles = new HashSet<FacturasDetalle>();
            PagosDetalles = new HashSet<PagosDetalle>();
            Recargos = new HashSet<Recargo>();
        }

        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<FacturasDetalle> FacturasDetalles { get; set; }
        public virtual ICollection<PagosDetalle> PagosDetalles { get; set; }
        public virtual ICollection<Recargo> Recargos { get; set; }
    }
}
