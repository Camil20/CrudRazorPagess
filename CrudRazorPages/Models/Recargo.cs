using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Recargo
    {
        public int IdRecargo { get; set; }
        public int? IdFactura { get; set; }
        public DateTime? FechaRecargo { get; set; }
        public decimal? MontoPendiente { get; set; }
        public decimal? MontoRecargo { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
    }
}
