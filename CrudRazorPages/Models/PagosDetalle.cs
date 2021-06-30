using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class PagosDetalle
    {
        public int PagoDetalleId { get; set; }
        public int? PagoId { get; set; }
        public int? FacturaId { get; set; }
        public decimal? MontoPagado { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Pago Pago { get; set; }
    }
}
