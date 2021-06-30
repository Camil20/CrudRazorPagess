using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
            Pagos = new HashSet<Pago>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int EstadoId { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
