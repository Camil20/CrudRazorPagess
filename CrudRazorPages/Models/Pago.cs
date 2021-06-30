using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Pago
    {
        public Pago()
        {
            PagosDetalles = new HashSet<PagosDetalle>();
        }

        public int PagoId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public string FormaPago { get; set; }
        public decimal? TotalPagado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<PagosDetalle> PagosDetalles { get; set; }
    }
}
